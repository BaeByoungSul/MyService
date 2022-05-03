using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppService020
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Unsubscribe<string>(this, "serviceReturnValue");
            MessagingCenter.Subscribe<string>(this, "serviceReturnValue", (value) =>
            {
                Device.BeginInvokeOnMainThread(() => lblCounterValue.Text = value);

            });
        }

        private void btnStartStop_Clicked(object sender, EventArgs e)
        {
            if (Preferences.Get("MyTrackingServiceRunning", false) == false)
            {
                // 구독자에게 서비스 Start Message 보냄 
                MessagingCenter.Send<string>("Start", "myService");
                Preferences.Set("MyTrackingServiceRunning", true);
            }
            else
            {
                // 구독자에게 서비스 Stop Message 보냄 
                MessagingCenter.Send<string>("Stop", "myService");
                Preferences.Set("MyTrackingServiceRunning", false);
            }

            

            
        }
    }
}
