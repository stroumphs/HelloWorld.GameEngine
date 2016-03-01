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
    public class LobbyScene : GameScene
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


        public LobbyScene(EngineContext context, ITextureManager textureManage, IBus bus, IWorker worker, IConnectionFactory connectionFactory) :
            base(context, textureManage, bus)
        {
            _enableCache = false;
            _worker = worker;
            _connectionFactory = connectionFactory;
        }

        public override void Load()
        {
            base.Load();
            _bg = _textureManager.Load("lobby_bg");
        }

        protected override void AfterUpdate(int ms)
        {
            _container.Redraw();
            if (_resourceLoadCompleted && !_done)
            {
                _done = true;
            }
        }

        public void setPos(ImageButton2 btn, Vector2 pos)
        {
            btn.Pos = Layout.ValidPos(_context.ActualResolution, pos);
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();
            _resourceLoadCompleted = true;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFullScreen(_bg);
            base.Draw(canvas);
        }
    }
}