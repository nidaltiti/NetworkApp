// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NetworkApp
{
    [Register ("settings")]
    partial class settings
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton paypal_button { get; set; }

        [Action ("Paypal_button_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Paypal_button_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (paypal_button != null) {
                paypal_button.Dispose ();
                paypal_button = null;
            }
        }
    }
}