using Zero.Bus;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;

namespace HelloWorld.GameEngine
{
    public class SpashScene : GameScene
    {
        readonly IWorker _worker;
        readonly IConnectionFactory _connectionFactory;

        Texture _bg;
        Texture _loading;

        bool _resourceLoadComplted;
        private bool _done;
        private int _angle;

        public SpashScene(EngineContext context, ITextureManager textureManage, IBus bus, IWorker worker, IConnectionFactory connectionFactory) :
            base(context, textureManage, bus)
        {
            _enableCache = false;
            _worker = worker;
            _connectionFactory = connectionFactory;
        }

        public override void Load()
        {
            base.Load();
            _bg = _textureManager.Load("bg");
            var texture = _textureManager.Load("Loading");
            _loading = texture.CreateSub(0, 0, texture.Size.Y, texture.Size.X);

            var sprite = new SpriteAnimation(_loading, _loading.Size.X, _loading.Size.Y, 200, 6);
            sprite.Pos = Layout.CenterX(Size, sprite.Size, 420);
            Add(sprite);
            _bus.Publish("splash.loading");
        }

        protected override void AfterUpdate(int ms)
        {
            _container.Redraw();
            _angle++;
            if (_resourceLoadComplted && !_done)
            {
                _done = true;
                _worker.Run(() => _container.State = "spash-completed", 5 * 1000);
            }
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();
            _resourceLoadComplted = true;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFullScreen(_bg);
            base.Draw(canvas);
        }

    }
}