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
        private readonly ITextBoxContainer _textBoxContainer;

        Texture _bg;
        ImageButton2 _soundOn;
        ImageButton2 _soundOff;
        ImageButton2 _bgmOn;
        ImageButton2 _bgmOff;

        bool _resourceLoadCompleted;
        private bool _done;
        private Texture _defaultAvatar;


        public LobbyScene(EngineContext context, ITextBoxContainer textboxContainer, ITextureManager textureManage, IBus bus, IWorker worker, IConnectionFactory connectionFactory) :
            base(context, textureManage, bus)
        {
            _enableCache = false;
            _worker = worker;
            _connectionFactory = connectionFactory;
            _textBoxContainer = textboxContainer;
        }

        //private Dictionary<string, Tuple<Texture, Action<IComponent>, Vector2>> _innerData = new Dictionary<string, Tuple<Texture, Action<IComponent>, Vector2>>();

        //private void LoadImg(string name, Vector2 pos, TransformSWPos processPos)
        //{
        //    LoadSprite(name, pos, processPos, (c => { }));
        //}

        //private void LoadButton(string name, Vector2 pos, TransformSWPos processPos, Action<IComponent> act)
        //{
        //    LoadSprite(name + "_1", pos, processPos, act);
        //}

        //private void LoadSprite(string name, Vector2 pos, TransformSWPos processPos, Action<IComponent> act)
        //{
        //    var texture = _textureManager.Load(name);
        //    var actualPos = processPos(pos, texture.Size);
        //    _innerData.Add(name, Tuple.Create(texture, act, actualPos));
        //}

        delegate Vector2 TransformSWPos(Vector2 x, Vector2 y);

        public override void Load()
        {
            base.Load();
            _bg = _textureManager.Load("lobby_bg");

            TransformSWPos posFunc = (Vector2 x, Vector2 y) => Layout.TransformPos(_context.ActualResolution, x);
            TransformSWPos posCenterFunc = (Vector2 x, Vector2 y) => Layout.TransformPosCenter(_context.ActualResolution, x, y);

            var imgs = new Tuple<string, TransformSWPos, Vector2>[] {Tuple.Create("default_avatar", posFunc, new Vector2(105.0f, 170.0f)),
                Tuple.Create("avatar", posFunc, new Vector2(100.0f, 147.0f)),
                Tuple.Create("level_progress_full", posFunc, new Vector2(316.0f, 142.0f)),
                Tuple.Create("chest_1", posFunc, new Vector2(124.0f, 322.0f)),
                Tuple.Create("pannel_goldtip", posFunc, new Vector2(120.0f, 318.0f))};
            
            var btns = new Tuple<string, TransformSWPos, Vector2>[] {
                Tuple.Create("btn_char", posFunc, new Vector2(107.0f, 262.0f)),
                Tuple.Create("receive_gold", posFunc, new Vector2(118.0f, 379.0f)),
                Tuple.Create("btn_quest_levelup", posFunc, new Vector2(594.0f, 137.0f)),
                Tuple.Create("buy", posFunc, new Vector2(607.0f, 388.0f)),
                Tuple.Create("tutor", posFunc, new Vector2(780.0f, 100.0f)),
                Tuple.Create("rate", posFunc, new Vector2(780.0f, 186.0f)),
                Tuple.Create("laser", posFunc, new Vector2(780.0f, 307.0f)),
                Tuple.Create("fastjoin", posFunc, new Vector2(780.0f, 423.0f)), 
                //"shop", 
                //"quest", 
                //"backpack", 
                //"mail",
                //"friend", 
                //"upgrade", 
                //"giftcode", 
                //"vip", 
                //"lottery", 
                //"showup", 
                //"main_ranking", 
                //"settings"
            };

            foreach (var img in imgs)
            {
                var texture = _textureManager.Load(img.Item1);
                var actualPos = img.Item2(img.Item3, texture.Size);
                Add(new Image(texture) {Pos = actualPos});
            }
            

            var msgBox = new MessageBox(100, 100, _textBoxContainer, _textureManager, this);
            
            foreach (var btn in btns)
            {
                var texture = _textureManager.Load(btn.Item1 + "_1");
                var actualPos = btn.Item2(btn.Item3, texture.Size);
                var button = new ImageButton(texture) { Pos = actualPos };
                button.Clicked += c => {
                    _bus.Publish("button.clicked", btn.Item1);
                    msgBox.Prompt(btn.Item1, (d) => { });
                };
                    
                Add(button);
            }

            Add(msgBox);
        }

        //public override void Load()
        //{
        //    base.Load();
        //    _bg = _textureManager.Load("lobby_bg");
        //    _defaultAvatar = _textureManager.Load("default_avatar");
        //}

        protected override void AfterUpdate(int ms)
        {
            _container.Redraw();
            if (_resourceLoadCompleted && !_done)
            {
                _done = true;
            }
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();
            _resourceLoadCompleted = true;

            _bus.Subcribe("salary.response", c =>
            {
                var gold = (int) c;
            });

            _bus.Publish("salary.response", 10000);
            _bus.Subcribe("button.clicked", c =>
                {
                    var name = (string)c;
                    Console.WriteLine("Button " + name + " is clicked");
                });

            
            
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFullScreen(_bg);
            //canvas.Draw(0, 0, _bg);
            base.Draw(canvas);
        }
    }
}