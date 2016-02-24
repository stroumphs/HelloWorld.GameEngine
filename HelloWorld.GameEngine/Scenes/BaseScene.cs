using System;
using Zero.Bus;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;

namespace HelloWorld.GameEngine
{
    public class BaseScene : GameScene
    {
        const int LeftMenuWidth = 576;

        Texture _showMenuTexture;
        Texture _chatTexture;
        ImageButton _showMenu;
        ImageButton _chat;
        string _oldState;

        private Texture _bg;

        public BaseScene(EngineContext context, ITextureManager textureManager, IBus bus)
            : base(context, textureManager, bus)
        {

        }

        public override void Load()
        {
            base.Load();

            _bg = _textureManager.Load("bg");
            _showMenuTexture = _textureManager.Load("xoption");
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();

            _showMenu = new ImageButton(_showMenuTexture)
                {
                    Pos = new Vector2(0, _context.Resolution.Y - _showMenuTexture.Size.Y)
                };

            _showMenu.Clicked += c =>
            {
                _container.State = "show-menu";
                Console.WriteLine("ShowMenu.Clicked");
            };
            Add(_showMenu);
        }

        public override void UnActive()
        {
            Parent.Unmute(this);

            BringToFront();
            this.MoveToEase(new Vector2(LeftMenuWidth, 0), 200, Easing.SquareIn);
            DisableChildEvents = true;
            Tap += OnTap;
        }

        private void OnTap(IComponent c, Vector2 v)
        {
            _container.State = _oldState;
        }

        public override void Draw(ICanvas canvas)
        {
            if (_loadCompleted)
                base.Draw(canvas);
            else
            {
                canvas.Draw(0, 0, _bg);
            }
        }

        public override void Active()
        {
            Visible = true;

            DisableChildEvents = false;
            Tap -= OnTap;

            BringToFront();

            _oldState = _container.State;

            if (!GameMath.IsZero(Pos.X))
            {
                this.MoveToEase(Vector2.Zero, 200, Easing.SquareOut);
            }
        }
    }
}