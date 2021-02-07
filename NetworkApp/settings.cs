using Foundation;
using System;
using UIKit;
using Xamarin.Essentials;

namespace NetworkApp
{
    public partial class settings : UIViewController
    {
        static public settings sett = null;
        static public bool ischange = true;
        public settings (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {

            sett = this;

            ShwichAuto.On = save.Savegerlly ;
            base.ViewDidLoad();

            NSTimer Timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(0.1), delegate {
                if (ischange)
                {

                    ShwichAuto.On = save.Savegerlly;

                }



            });
            }
       
        partial void Paypal_button_TouchUpInside(UIButton sender)
        {
            NSUrl openUrl = new NSUrl("https://www.paypal.com/donate?hosted_button_id=9LJP5PTR5TXKW");
            UIApplication.SharedApplication.OpenUrl(openUrl);



        }
        partial void ShwichAutoChange(UISwitch sender)
        {
            save.Savegerlly = ShwichAuto.On;
          //  throw new NotImplementedException();
        }
       
    }
}