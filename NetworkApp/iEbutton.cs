
using System;
using UIKit;

using Mono.Data.Sqlite;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using GMImagePicker;

using Photos;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Text;
using System.Threading;
using Network_App;
using System.Linq;
using AssetsLibrary;
using Social;
using AVFoundation;
using AVKit;
using UIKit;
namespace NetworkApp
{
    class iEbutton
    {

        int number;
        UIImage uiimag;
        string text = string.Empty;
        public delegate void clicked(int number, string text, iEbutton iebutton);
        public event clicked click;
        bool isSlec = false;
        UIButton ebutton = new UIButton();

        AVPlayer player;
        bool isvideo = false;
        string localPath;
        string Extension;
      //  AVPlayerViewController playerController = new AVPlayerViewController();
      //  AVPlayerLayer avplayerLayer;
     //   AVAsset avasset;
        //AVPlayerItem avplayerItem;
     //   AVPlayerViewController avpvc = new AVPlayerViewController();

        byte[] _byte;
        byte[] _tumbbyte;

        public void whate_is_byte(byte[] img,int i) {
            _byte = img;
            //ebutton = new UIButton();
            //  ebutton.SetTitle(i.ToString(), UIControlState.Normal);
           number = i;

            UIImageView _UIImageView = new UIImageView();

            _UIImageView.Image = coVimage(img);


            if (Extension == "Video") { isvideo = true; } else { isvideo = false; }
            
            //if (_UIImageView.Image != null)
            //{

            //  //  uiimag = coVimage(img);


            //    //ebutton.SetImage(coVimage(img), UIControlState.Normal);
            //    //ebutton.TouchUpInside += Ebutton_TouchUpInside;

            //}
            //else
            //{

            //    isvideo = true;

            //  //  ebutton.TouchUpInside += Ebutton_TouchUpInside;

            //}
        }
        public byte[] retbyet() { return _byte; }
        public byte[] rettumblin() { return _tumbbyte; }

        public void creationimge()
        {
            //_byte = img;
            //ebutton = new UIButton();
            //  ebutton.SetTitle(i.ToString(), UIControlState.Normal);
         //   number = i;

          
           

                uiimag = coVimage(_byte);


                ebutton.SetImage(coVimage(_byte), UIControlState.Normal);
                ebutton.TouchUpInside += Ebutton_TouchUpInside;

          
          
            //  playerController.Player = player;

            //  playerController.View.Frame = new CGRect(55, 170, 310f, 200f);

            //Images.imG.PresentViewController(playerController, true, null);
            //  ebutton.AddSubview();
            //  ebutton.TouchUpInside += Ebutton_TouchUpInside;




            //  return ebutton;

            // 



        }
        public void booldelert()
        {
            if (isSlec == false) { isSlec = true; }
            else { isSlec = false; }
        }
        public bool BackboolSlect() { return isSlec; }
        public int buttonnumber() { return number; }
        private void Ebutton_TouchUpInside(object sender, EventArgs e)
        {
            if (click != null) { click(number, text, this); }
        }
        public void getText(string Etext) { text = Etext; }
        public string setText() { return text; }


        public void Frame(int x, int y, int size)
        {



            ebutton.Frame = new RectangleF(x, y, size, size);


            if (isvideo) {
                try
                {
                  //  avplayerLayer.Frame = ebutton.Frame;
                   // avplayerLayer.Bounds = ebutton.Bounds;
                }
                catch { }

            }




        }
        public UIButton RButton() { return ebutton; }
        public UIButton RButton1()
        {



            return ebutton;
        }
        public UIImage image() { return uiimag; }
        public UIImage coVimage(byte[] byt)
        {
            byte[] encodedDataAsBytes = byt;
            NSData data = NSData.FromArray(encodedDataAsBytes);
            var uiImage = UIImage.LoadFromData(data);
            return (uiImage);
        }
        public void dete()
        {

            Network_App.LibraryWords library = new Network_App.LibraryWords();


            Network_App.DataSql DataSql = new Network_App.DataSql();
            DataSql.process(library.File(2), library.DELETE(1), DataSql_Parameters(text));






        }

        private SqliteParameterCollection DataSql_Parameters(string data)
        {
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row, data);

            return ReturnParamter;

        }
   public     void creatFilemov(byte[] videoData)
        {



            //  change

            UIImageView tumbnil = new UIImageView();


            UIImageView playerbutton = new UIImageView();
            playerbutton.Frame = new CGRect(45,45,30,30);
            tumbnil.Frame = new CGRect(0, 0, 75, 75);

            playerbutton.Image = UIImage.FromBundle("player.png");

            tumbnil.Image = coVimage(videoData);

            //   avplayerLayer.BackgroundColor = UIColor.Black.CGColor;

            //  avpvc.Title = "this video";
          //  ebutton.SetImage(coVimage(videoData), UIControlState.Normal);
           ebutton.AddSubviews(tumbnil);
            //ebutton.Layer.AddSublayer(avplayerLayer);
            ebutton.AddSubviews(playerbutton);
                ebutton.TouchUpInside += Ebutton_TouchUpInside;
            //ebutton.AddSubviews(avplayerLayer)
        }
        public string _AVPlayer() { return localPath;



        }
        public void  localstring(string g) { localPath = g; }
        public bool _isvideor() { return isvideo; }

        public void ext(string g) { Extension = g; }



    }
   
}