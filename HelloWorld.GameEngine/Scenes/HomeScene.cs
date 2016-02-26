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
    public class HomeScene : BaseScene
    {
        readonly IFontFactory _factory;
        private readonly ITextBoxContainer _textBoxContainer;
        private readonly IGoogleAnalytic _analytic;
        Texture _bg;
        Texture _glow;

        readonly List<string> _games = new List<string> { "Poker", "Loc", "TLN", "Binh", "Tala", "TLNDL" };
        readonly List<Texture> _textures = new List<Texture>();
        readonly List<string> _users = new List<string>();
        private int _currentSlot = 0;
        Vector2[] _logoPos;

        TextBox _textBos;

        IFont[] _fonts = new IFont[10];
        private Texture _remoteTexture;
        private Texture _bgButton;
        private string _url;

        public HomeScene(EngineContext context, ITextureManager textureManager, IBus bus, IFontFactory factory, ITextBoxContainer textBoxContainer, IGoogleAnalytic analytic)
            : base(context, textureManager, bus)
        {
            _factory = factory;
            _textBoxContainer = textBoxContainer;
            _analytic = analytic;
        }

        public override void Load()
        {
            Console.WriteLine("Load home");
            base.Load();
            _bgButton = _textureManager.Load("inputbox");
            _bg = _textureManager.Load("bg");
            _glow = _textureManager.Load("avatar_holder");
            _textureManager.TryLoadUrl("http://sanhrong.com/_Resources/_Common/_i/temp/promotion_2013_12_11.png", out _remoteTexture);

            foreach (var game in _games)
            {
                _textures.Add(_textureManager.Load(game));
            }

            _users.Clear();
            OpenUrlStream("http://diendan.sanhrong.com/users.txt", s =>
                {
                    using (var reader = new StreamReader(s))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (string.IsNullOrEmpty(line)) continue;
                            _users.Add(line.Trim());
                        }
                    }
                });
            
        }
        private void OpenUrlStream(string url, Action<Stream> action)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    action(stream);
                }
            }
        }

        public override void LoadCompleted()
        {
            base.LoadCompleted();

            _bus.Subcribe<Welcome>(m => Platform.Toast("Proxy connected", true));
            _bus.Subcribe<LoginResponse>(m => Platform.Toast(string.Format("Login Response error = {0}", m.Error), true));
            _bus.Subcribe<ChannelListResponse>(m => Platform.Toast(string.Format("{$0} channels", m.Channels.Count)));

            var pos = new Vector2(960 - _bgButton.Size.X, 0);
            AddTest(ref pos, "Next", NextUser);
            AddTest(ref pos, "Previous", PreviousUser);

            var t = new TextBox(_textBoxContainer);
            t.Color = Color.White;
            t.Size = new Vector2(300, 50);
            t.Pos = new Vector2(10, 10);
            t.Text = "Not authenticated";

            AddTest(ref pos, "OpenWebView", () =>
            {
                Platform.WebView.Load("http://diendan.sanhrong.com/upload.html");
            });

            AddTest(ref pos, "Load Webview background", () =>
            {
                Platform.WebView.Load("http://diendan.sanhrong.com/upload.html", v => { Platform.Toast(v.Title, true); }, true);
            });

            Add(t);
        }

        private void PreviousUser()
        {
            _currentSlot--;

            if (_currentSlot < 0) _currentSlot = 0;

            var name = _users[_currentSlot];
            _url = "http://diendan.sanhrong.com/avatar.php?username=" + name;
        }

        private void NextUser()
        {
            _currentSlot++;
            if (_currentSlot >= _users.Count)
                _currentSlot = _users.Count - 1;

            var name = _users[_currentSlot];
            _url = "http://diendan.sanhrong.com/avatar.php?username=" + name;
        }

        void ShowTextBox()
        {
            _textBos.Active();
        }

        void SendLogin()
        {
            _bus.Send(new LoginRequest()
            {
                UserName = "v001",
                Password = "",
            });
            _bus.Send(new LoginRequest()
            {
                UserName = "v001",
                Password = "",
            });
        }

        void Setup()
        {
            Console.WriteLine("Connect 112");
            _bus.Publish("system.application", 112);
        }

        void SendChannelList()
        {
            _bus.Send(new ChannelListRequest () {
                Application = 105,
            });
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFullScreen(_bg);

            if (_remoteTexture != null) canvas.Draw(Size.X - _remoteTexture.Size.X, Size.Y - _remoteTexture.Size.Y, _remoteTexture);

            if (!string.IsNullOrEmpty(_url))
            {
                var avatar = Platform.Kernel.Get<IAvatarLoader>().Load(_url);
                if (avatar != null)
                {
                    canvas.Draw(400, 100, avatar, effect: Effect.AlphaBlend);
                    Font.Draw(canvas, 400, 50, _users[_currentSlot], Color.White);
                }
            }

            base.Draw(canvas);
        }

        #region Overrides of AbstractComponent

        protected override void AfterUpdate(int ms)
        {
            base.AfterUpdate(ms);
            Invalidate();
        }
        #endregion

        private void AddTest(ref Vector2 pos, string text, Action action)
        {
            var btn1 = new TextButton(_bgButton)
            {
                Text = text,
                Pos = pos += new Vector2(0, 50)
            };

        }
    }

    public class TextComponent : AbstractComponent
    {
        private string _text;
        private uint _color;

        public TextComponent() { }

        public TextComponent(IFont font, uint color)
        {
            Font = font;
            Color = color;
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value) return;
                _text = value;
                Size = Font.MeasureSize(value);
                Invalidate();
            }
        }

        public uint Color
        {
            get { return _color; }
            set
            {
                if (_color == value) return;
                _color = value;
                Invalidate();
            }
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Draw(new Quad(Vector2.Zero, Size), new Texture
            {
                Size = Size
            }, null, Zero.Games.Engine.Color.Black);
            Font.Draw(canvas, Vector2.Zero, Text, Color);
        }
    }

    public class TextButton : ImageButton
    {
        private string _text;
        private Vector2 _pad = new Vector2(5, 5);

        public TextButton(Texture bg) : base(bg) { }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value) return;

                _text = value;
                Invalidate();
            }
        }

        public override void Draw(ICanvas canvas)
        {
            base.Draw(canvas);
            if (!string.IsNullOrEmpty(Text))
                Font.Draw(canvas, _pad, Text, Color.Black);
        }
    }

    class TextField : AbstractComponent
    {
        private readonly Vector2 _baseLine;
        private readonly uint _color;
        private string _text;

        public TextField(IFont f, Vector2 baseLine, uint color)
        {
            Font = f;
            _baseLine = baseLine;
            _color = color;
            Font = f;

            var metric = Font.FontMetric;
            Pos = new Vector2(_baseLine.X, baseLine.Y - metric.Ascent);
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Size = new Vector2(Font.MeasureSize(_text).X, Font.FontMetric.MaxHeight);
            }
        }

        public override void Draw(ICanvas canvas)
        {
            Font.Draw(canvas, 0, 0, Text, _color);
        }
    }
}