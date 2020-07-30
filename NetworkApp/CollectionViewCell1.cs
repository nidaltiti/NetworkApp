using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Network_App
{
    public partial class CollectionViewCell1 : UICollectionViewCell
    {
       
           public static readonly NSString Key = new NSString("CollectionViewCell1");
       // public static readonly UINib Nib;

         CollectionViewCell1()
        {
           // Nib = UINib.FromName("CollectionViewCell1", NSBundle.MainBundle);
        }

        protected CollectionViewCell1(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


        public void set(int i) {
           setbuton(i); 
        }
         void setbuton(int i)
        {
           
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };
            
            ContentView.Layer.BorderColor = UIColor.Blue.CGColor;
            ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;
           
            ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            //  imageView = new UIImageView(UIImage.FromBundle("placeholder.png"));
            //  button.Center = ContentView.Center;
            //  button.Transform = CGAffineTransform.MakeScale(0.7f, 0.7f);

           
            local.UIbutton[i].Frame(0, 0, (75));
            ContentView.AddSubview(local.UIbutton[i].RButton());
            


        }
     
        public void BorderColor() {
            if (ContentView.Layer.BorderColor == UIColor.Blue.CGColor)
            {

                ContentView.Layer.BorderColor = UIColor.Red.CGColor;

            }
            else { ContentView.Layer.BorderColor = UIColor.Blue.CGColor; }

        }
    }
}