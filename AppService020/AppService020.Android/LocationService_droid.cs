using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppService020.Droid
{
    [Service]
    public class LocationService_droid : Service
    {
        int counter = 0;
        bool isRunningTimer = true;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
         
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                MessagingCenter.Send<string>(counter.ToString(), "serviceReturnValue");
                counter++;


                return isRunningTimer;
            });
            Log.Debug("MyService", "My Service Started");
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            Log.Debug("MyService", "My Service Stoped");

            StopSelf();
            counter = 0;
            isRunningTimer = false;
            base.OnDestroy();   
        }
  
    }
}