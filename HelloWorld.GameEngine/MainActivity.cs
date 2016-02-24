using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
//using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.OS;
//using AndroidRunner;
//using Com.Facebook;
//using Com.Facebook.Appevents;
//using Com.Facebook.Internal;
//using Com.Facebook.Login;
using Java.Security;
using Zero.Core;
using Zero.Core.Kernel;
using Zero.Core.Serialization;
using Zero.Games.Engine;
using Zero.Games.Engine.Components;
using Zero.Bus;

namespace HelloWorld.GameEngine
{
    [Activity(
        Label = "HelloWorld.GameEngine", 
        MainLauncher = true, 
        Icon = "@drawable/icon",
        WindowSoftInputMode=SoftInput.AdjustResize,
        ScreenOrientation = ScreenOrientation.Landscape,
        LaunchMode=LaunchMode.SingleTop,
        ConfigurationChanges=ConfigChanges.KeyboardHidden | ConfigChanges.Orientation)]
    
    //public class MainActivity : Activity
    //{
    //    int count = 1;

    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        base.OnCreate(bundle);

    //        // Set our view from the "main" layout resource
    //        SetContentView(Resource.Layout.Main);

    //        // Get our button from the layout resource,
    //        // and attach an event to it
    //        Button button = FindViewById<Button>(Resource.Id.MyButton);

    //        button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
    //    }
    //}

    public class MainActivity : GameActivity<Test>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppDomain.CurrentDomain.UnhandledException += (obj, ev) =>
            {
                var ex = (Exception)ev.ExceptionObject;
                Log.Debug("Error", ex.Message + "\r" + ex.StackTrace);
            };
            base.OnCreate(savedInstanceState);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            UploadableChromeClient.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override string BalancerAddress
        {
            get
            {
                return "123.30.174.185";
            }
        }
    }
}

