// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Network_App
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem tab1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tabview { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tab1 != null) {
                tab1.Dispose ();
                tab1 = null;
            }

            if (tabview != null) {
                tabview.Dispose ();
                tabview = null;
            }
        }
    }
}