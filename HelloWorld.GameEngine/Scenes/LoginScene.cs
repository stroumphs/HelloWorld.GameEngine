using Zero.Bus;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;
using Zero.Games.Engine.Tracking;

namespace HelloWorld.GameEngine
{
    public class LoginScene : GameScene
    {
        readonly ITextBoxContainer _textBoxContainer;
        readonly IFontFactory _fontFactory;

        private readonly IGoogleAnalytic _analytic;
        Texture _bg;
        TextBox _name;
        TextBox _password;

        public LoginScene(ITextBoxContainer textBoxContainer, EngineContext context, ITextureManager textureManager, IFontFactory fontFactory, IBus bus, IGoogleAnalytic analytic)
            : base(context, textureManager, bus)
        {
            _textBoxContainer = textBoxContainer;
            _fontFactory = fontFactory;
            _analytic = analytic;
        }

        public override void Load()
        {
            base.Load();

            var bigFont = _fontFactory.Create("Arial", 32);

            _bg = _textureManager.Load("bg");
            _name = new TextBox(_textBoxContainer)
            {
                Pos = new Vector2(240, 285),
                Size = new Vector2(480, 55),
                Font = bigFont,
            };
            _password = new TextBox(_textBoxContainer)
            {
                Pos = new Vector2(240, 365),
                Size = new Vector2(480, 55),
                IsPassword = true,
                Font = bigFont,
            };
            _name.ActiveChanged += OnActiveChanged;
            _password.ActiveChanged += OnActiveChanged;

            Add(_name);
            Add(_password);
        }

        void OnActiveChanged(ITextBox textbox, bool activated) { }

        public override void Draw(ICanvas canvas)
        {
            canvas.Draw(0, 0, _bg);
            base.Draw(canvas);
        }
    }
}