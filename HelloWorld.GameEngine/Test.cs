using System;
using System.Threading;
using Zero.Bus;
using Zero.Core;
using Zero.Core.Kernel;
using Zero.Core.Serialization;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;
using Zero.Games.Engine.Tracking;

namespace HelloWorld.GameEngine
{
    public class Test : Application
    {
        public override void Init(IComponentContainer c)
        {
            base.Init(c);

            var kernel = Container.Instance.Get<IKernel>();

            kernel.Configure(new InlineModule(
                b => b.Bind<IAvatarLoader, AvatarLoader>().InSingletonScope()));

            var loader = kernel.Get<IAvatarLoader>();
            var mask = "Images/avatar_holder.jpg";

            loader.Init(1024, 1024, 100, 100, 5, mask);
            var cs = kernel.Get<CompactSerializer>();

            new CoreMessages(cs);
            new BaseMessages(cs);

            c.Flow("start", "splash");
            c.Flow("splash-complted", "home");
            c.Flow("show-menu", "login");
            c.Flow("show-login", "login");

            c.Register<SpashScene>("splash", true);
            c.Register<HomeScene>("home", true);
            c.Register<LeftMenu>("left", true);
            c.Register<LoginScene>("login", true);
        }
    }

    class AnalyticsCenter
    {
        private readonly IGoogleAnalytic _googleAnalytic;

        public AnalyticsCenter(IGoogleAnalytic googleAnalytic, IBus bus)
        {
            _googleAnalytic = googleAnalytic;
            bus.Subcribe("system.scene.afterActive", (string t) => SceneActive(t));
        }

        private void SceneActive(string scene)
        {
            _googleAnalytic.PageView(new PageViewReq
            {
                page = scene,
                title = scene
            });
        }
    }

    static class BusExt
    {
        public static void Subcribe<T>(this IBus bus, string msg, Action<T> action)
        {
            bus.Subcribe(msg, obj =>
            {
                action((T)obj);
            });
        }
    }
}