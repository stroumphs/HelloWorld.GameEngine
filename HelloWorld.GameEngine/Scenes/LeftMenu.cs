using Zero.Bus;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;

namespace HelloWorld.GameEngine
{
    public class LeftMenu : GameScene
    {
        Texture _bg;
        ImageButton btn;

        ImageButton xxx;

        public LeftMenu(EngineContext context, ITextureManager textureManage, IBus bus) : base(context, textureManage, bus) { }

        public override void Load()
        {
            base.Load();
        }

        public override void Active()
        {
            base.Active();
        }

        public override void UnActive()
        {
            base.UnActive();
        }

        public override void Draw(ICanvas canvas)
        {
            base.Draw(canvas);
        }
    }
}