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
    [Register ("ViewWer")]
    partial class ViewWer
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem delete { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem settings_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ximage { get; set; }

        [Action ("Delete_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Delete_Activated (UIKit.UIBarButtonItem sender);

        [Action ("Settings_button_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Settings_button_Activated (UIKit.UIBarButtonItem sender);

        [Action ("UIBarButtonItem264_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem264_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (delete != null) {
                delete.Dispose ();
                delete = null;
            }

            if (settings_button != null) {
                settings_button.Dispose ();
                settings_button = null;
            }

            if (ximage != null) {
                ximage.Dispose ();
                ximage = null;
            }
        }
    }
}