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

namespace Network_App
{
    [Register ("Nettab")]
    partial class Nettab
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem nag { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBar tabconrol { get; set; }

        [Action ("Buttn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Buttn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttn != null) {
                buttn.Dispose ();
                buttn = null;
            }

            if (nag != null) {
                nag.Dispose ();
                nag = null;
            }

            if (tabconrol != null) {
                tabconrol.Dispose ();
                tabconrol = null;
            }
        }
    }
}