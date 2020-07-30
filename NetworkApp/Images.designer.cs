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
    [Register ("Images")]
    partial class Images
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uiv { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView viewcoll { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (uiv != null) {
                uiv.Dispose ();
                uiv = null;
            }

            if (viewcoll != null) {
                viewcoll.Dispose ();
                viewcoll = null;
            }
        }
    }
}