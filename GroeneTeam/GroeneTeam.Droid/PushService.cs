//using Android.App;
//using Android.Content;
//using Android.Util;
//using GroeneTeam.ServiceModels;
//using JemId.Basis.MonoDroid;
//using PushSharp.Client;

//[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")] //, ProtectionLevel = Android.Content.PM.Protection.Signature)]
//[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
//[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//// GET_ACCOUNTS is only needed for android versions 4.0.3 and below
//[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
//[assembly: UsesPermission(Name = "android.permission.INTERNET")]
//[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

//namespace GroeneTeam.Droid
//{
//    //You must subclass this!
//    [BroadcastReceiver(Permission = GCMConstants.PERMISSION_GCM_INTENTS)]
//    [IntentFilter(new string[] { GCMConstants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "@PACKAGE_NAME@" })]
//    [IntentFilter(new string[] { GCMConstants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "@PACKAGE_NAME@" })]
//    [IntentFilter(new string[] { GCMConstants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "@PACKAGE_NAME@" })]
//    public class PushHandlerBroadcastReceiver : PushHandlerBroadcastReceiverBase<PushHandlerService>
//    {
//        // Google API Console App Project ID
//        public static string[] SENDER_IDS = new string[] { "266105891503" };

//        public const string TAG = "jemidbv@gmail.com";
//    }

//    [Service] // Must use the service tag
//    public class PushHandlerService : PushHandlerServiceBase
//    {
//        public PushHandlerService()
//            : base(PushHandlerBroadcastReceiver.SENDER_IDS)
//        { }

//        protected override void OnRegistered(Context context, string registrationId)
//        {
//            Log.Verbose(PushHandlerBroadcastReceiver.TAG, "GCM Registered: " + registrationId);
//            //SessionManager.ServiceApi.RegisterDeviceAsync(registrationId, "Groene team");
//        }

//        protected override void OnUnRegistered(Context context, string registrationId)
//        {
//            Log.Verbose(PushHandlerBroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);
//            //SessionManager.ServiceApi.UnregisterDeviceAsync(registrationId, "Groene team");
//        }

//        protected override void OnMessage(Context context, Intent intent)
//        {
//            Log.Info(PushHandlerBroadcastReceiver.TAG, "GCM Message Received!");
//            //context.ShowPushNotification<MainActivity>(intent, Resource.Drawable.Icon, "Groene team");
//        }

//        protected override bool OnRecoverableError(Context context, string errorId)
//        {
//            Log.Warn(PushHandlerBroadcastReceiver.TAG, "Recoverable Error: " + errorId);
//            return base.OnRecoverableError(context, errorId);
//        }

//        protected override void OnError(Context context, string errorId)
//        {
//            Log.Error(PushHandlerBroadcastReceiver.TAG, "GCM Error: " + errorId);
//        }
//    }
//}