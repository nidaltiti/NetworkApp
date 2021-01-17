using Foundation;
using System;
using UIKit;

namespace NetworkApp
{
    public partial class settings : UIViewController
    {
        public settings (IntPtr handle) : base (handle)
        {
        }

        partial void Paypal_button_TouchUpInside(UIButton sender)
        {
            NSUrl openUrl = new NSUrl("https://www.paypal.com/donate?hosted_button_id=9LJP5PTR5TXKW");
            UIApplication.SharedApplication.OpenUrl(openUrl);
        }
    }
}