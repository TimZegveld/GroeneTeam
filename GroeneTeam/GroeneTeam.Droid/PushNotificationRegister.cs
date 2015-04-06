using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;
using GroeneTeam.Droid;
using PushSharp.Client;

namespace GroeneTeam
{
    public class PushNotificationRegister : IPushNotificationRegister
    {
        public void ExtractTokenAndRegister()
        {
            //if (!PushClient.IsRegistered())
            //    PushClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
        }
    }
}
