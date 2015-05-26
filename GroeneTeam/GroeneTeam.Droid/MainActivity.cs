using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PushSharp.Client;

namespace GroeneTeam.Droid
{
    [Activity(Label = "GroeneTeam", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!PushClient.IsRegistered(this))
                PushClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new GroeneTeam.App());
        }
    }
}

