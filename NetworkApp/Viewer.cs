using Foundation;
using System;
using UIKit;

namespace Network_App
{
    public partial class Viewer : UIViewController
    {
        UIImage uIImage;
        public Viewer (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //
            imageViewer.Image = uIImage;

        }
        public void getimge(UIImage xuIImage)
        {

            uIImage = xuIImage;

        }
    }
}