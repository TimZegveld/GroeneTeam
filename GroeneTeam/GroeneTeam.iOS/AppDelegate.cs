using System;
using System.Collections.Generic;
using System.Linq;
using JemId.Basis.MonoTouch;
using Foundation;
using UIKit;
using GroeneTeam.ServiceModels;

namespace GroeneTeam.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new GroeneTeam.App());

            UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Alert | UIRemoteNotificationType.Sound);

            return base.FinishedLaunching(app, options);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            this.RegistrerenVoorPushNotifications(deviceToken, Registreer);
        }

        private void Registreer(string deviceToken)
        {
            Console.WriteLine("Registreer: " + deviceToken);
            SessionManager.ServiceApi.RegisterDeviceAsync(deviceToken, Constants.AppName);
            SessionManager.ServiceApi.RegisterLogMessageAsync("Succesvol geregistreerd bij APNs", deviceToken, Constants.AppName);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Console.WriteLine("Failed to register for notifications: " + error.ToString());
            SessionManager.ServiceApi.RegisterLogMessageAsync("Fout bij registreren APNs: " + error.ToString(), string.Empty, Constants.AppName);
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            Console.WriteLine("Received Remote Notification!");
            SessionManager.ServiceApi.RegisterLogMessageAsync("Remote notification ontvangen", Functies.GeefDeviceToken(), Constants.AppName);
        }
    }
}
