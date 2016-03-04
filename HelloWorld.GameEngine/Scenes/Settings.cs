using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Zero.Bus;
using Zero.Core;
using Zero.Core.Kernel;
using Zero.Core.Serialization;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;
using Zero.Games.Engine.Inputs;
using Zero.Games.Engine.Tracking;
using Color = Zero.Games.Engine.Color;

namespace HelloWorld.GameEngine
{
    public class SettingsScene : GameScene
    {
        readonly IWorker _worker;
        readonly IConnectionFactory _connectionFactory;

        Texture _bg;
        ImageButton2 _soundOn;
        ImageButton2 _soundOff;
        ImageButton2 _bgmOn;
        ImageButton2 _bgmOff;

        bool _resourceLoadCompleted;
        private bool _done;
        

        public SettingsScene(EngineContext context, ITextureManager textureManage, IBus bus, IWorker worker, IConnectionFactory connectionFactory) :
            base(context, textureManage, bus)
        {
            _enableCache = false;
            _worker = worker;
            _connectionFactory = connectionFactory;
        }

        public override void Load()
        {
            base.Load();
            _bg = _textureManager.Load("settings_bg");
            
            _soundOn = new ImageButton2(_textureManager, "sound_on");
            _soundOff = new ImageButton2(_textureManager, "sound_off", false);
            RadioButton.create(new ImageButton2[2] { _soundOn, _soundOff });
            _bgmOn = new ImageButton2(_textureManager, "bgm_on");
            _bgmOff = new ImageButton2(_textureManager, "bgm_off", false);
            RadioButton.create(new ImageButton2[2] { _bgmOn, _bgmOff });
        }

        protected override void AfterUpdate(int ms)
        {
            _container.Redraw();
            if (_resourceLoadCompleted && !_done)
            {
                _done = true;
            }
        }

        public void setPos(ImageButton2 btn, Vector2 pos) {
            btn.Pos = Layout.TransformPos(_context.ActualResolution, pos);
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();
            _resourceLoadCompleted = true;
            setPos(_soundOn, new Vector2(593.0f, 257.0f));
            setPos(_soundOff, new Vector2(497.0f, 257.0f));
            setPos(_bgmOn, new Vector2(593.0f, 314.0f));
            setPos(_bgmOff, new Vector2(497.0f, 314.0f));

            Add(_soundOn);
            Add(_soundOff);
            Add(_bgmOn);
            Add(_bgmOff);
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFullScreen(_bg);
            base.Draw(canvas);
        }
    }
}