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
using NetworkApp;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using AVFoundation;
using System.Runtime.Remoting.Messaging;

namespace NetworkApp
{
    public partial class img : UICollectionViewController
    {
        public static img imG;
        int buttonnumber = 0;
        // bool n = true;
        NSTimer timer;
        int finshpluse = 0;
        //  int p_x = 1, p_y = 2, phone = 0;
        LibraryWords library = new LibraryWords();
        DataSql DataSql = new DataSql();
        // public static string Titile;
        //  public static Nettab click;
        static List<UIImage> uIImage = new List<UIImage>();
        List<UIImageView> ImageView = new List<UIImageView>();
        List<iEbutton> UIbutton = new List<iEbutton>();
        List<UIImage> Imagedata = new List<UIImage>();
        List<byte[]> byetdata = new List<byte[]>();
        List<string> endstring = new List<string>();
        List<string> UrlVideoString = new List<string>();
        bool _Select;
        public void is_Select() { _Select = false; }
        public img(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {

            reload();
            imG = this;
            // reload(0);
        }
        public override void LoadView()

        {
            // timer.Interval = 1;



            timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(0.1), delegate {






                if (finshpluse == 1) { finshpluse = 0; reload(); }
                //if (scoll.Frame.Height > scoll.Frame.Width) { phone = p_x; }

                //if (scoll.Frame.Height < scoll.Frame.Width) { phone = p_y; }

                //switch (phone) {

                //    case 1: { try
                //            {
                //                DataSql.process(library.File(2), library.SELECT(1), null);


                //                //  uIImage .Add( byeimge());

                //                //  setbutton();

                //                scoll.ContentSize = new CGSize(uiv.Frame.Width - 70, ImageView.Count * 15);
                //                putimage(50, 70, 14);
                //            } catch { } } break;

                //    case 2: { try {
                //                scoll.ContentSize = new CGSize(ImageView.Count + 20, ImageView.Count * 15);


                //                putimage(80, 90, 40);
                //            } catch { } } break;



                //  }


                //  phone = 0;



            });

            //* get delege form tab --Nettab--
            Nettab.bar.plusbutton += Bar_add_image;
            Nettab.bar.selectboutton += Bar_selectboutton;
            Nettab.bar.Ssender += Bar__sender;//*
            base.LoadView();
        }
        private void Bar__sender(object sender)
        {
            int row = 0, countred = 0;
            for (row = 0; row < UIbutton.Count; row++)
            {

                if (UIbutton[row].BackboolSlect())
                {
                    countred++;

                }


            }
            if (countred > 0) { alrtdo(); }

        }
        UIBarButtonItem secletbutton = new UIBarButtonItem();


        private void Bar_selectboutton(object sender)
        {

            // reload(0);
            if (_Select == false) { _alert(); _Select = true; }
            else
            {
                _Select = false;

                Nettab.bar.changebuttonclick();


                // ViewDidLoad();
            }

        }
        private void _alert()
        {

            var alert = UIAlertController.Create("", "", UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("Settings", UIAlertActionStyle.Default, (UIAlertAction obj) => {

                _Select = false;

            }));

            alert.AddAction(UIAlertAction.Create("Select", UIAlertActionStyle.Default, (UIAlertAction obj) => {
                _Select = true;
                Nettab.bar.changebuttonclick();
            }));

            /// end Select


            alert.AddAction(UIAlertAction.Create("Delete All", UIAlertActionStyle.Destructive, (UIAlertAction obj) => {
                alertsure("Delete All");
            }));
            ///  end delete

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (UIAlertAction obj) => {
                _Select = false;
            }));

            ///  end cancel

            this.PresentViewController(alert, true, null);


        }
        private void alrtdo()
        {

            var alert = UIAlertController.Create("", "", UIAlertControllerStyle.ActionSheet);


            alert.AddAction(UIAlertAction.Create("Save", UIAlertActionStyle.Default, (UIAlertAction obj) => {
                alertsure("Save");
                //foreach(iEbutton ep in UIbutton)
                //if(ep.BackboolSlect())
                //{
                //    var someImage = ep.image();
                //    someImage.SaveToPhotosAlbum((image, error) =>
                //    {
                //        var o = image as UIImage;
                //        Console.WriteLine("error:" + error);
                //    });
                //}
                //Nettab.bar.changebuttonclick();


                //ViewDidLoad();
            }));



            alert.AddAction(UIAlertAction.Create("Share", UIAlertActionStyle.Default, (UIAlertAction obj) => {
                sharebox();

                //  Nettab.bar.changebuttonclick();


                // ViewDidLoad();

                // Nettab.bar.changebuttonclick();


                ViewDidLoad();
            }));


            alert.AddAction(UIAlertAction.Create("Delete", UIAlertActionStyle.Destructive, (UIAlertAction obj) => { alertsure("Delete"); }));
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (UIAlertAction obj) => { ViewDidLoad(); }));
            this.PresentViewController(alert, true, null);
        }



        void saveFilesGarelly()
        {
            List<string> delfile = new List<string>();
            foreach (NetworkApp.iEbutton ep in UIbutton)
            {
                if (ep.BackboolSlect())
                {
                    if (ep._isvideor() == false)
                    {
                        var someImage = ep.image();
                        someImage.SaveToPhotosAlbum((image, error) =>
                        {
                            var o = image as UIImage;
                            Console.WriteLine("error:" + error);

                        });
                    }

                    else
                    {
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        string localFilename = ep.setText(); //same if I save the file as .mp4
                        var localPath = Path.Combine(documentsPath, localFilename);

                        File.WriteAllBytes(localPath, ep.retbyet());
                        ALAssetsLibrary lib = new ALAssetsLibrary();
                        lib.WriteVideoToSavedPhotosAlbum(NSUrl.FromFilename(localPath), (t, u) => { });

                        delfile.Add(localPath);

                    }
                }
            }

            Nettab.bar.changebuttonclick();







            ViewDidLoad();
            new Thread(() => { Thread.Sleep(1000); foreach (string d in delfile) { File.Delete(d); } });

            // foreach (string d in delfile) { File.Delete(d); }
        }

        void alertsure(string mess)
        {


            Action<UIAlertAction> okaction = null;
            Action<UIAlertAction> Cancelaction = null;

            switch (mess)
            {
                case "Save":
                    {
                        okaction = (UIAlertAction => { saveFilesGarelly(); });


                        Cancelaction = (UIAlertAction => {
                            //  Nettab.bar.changebuttonclick();


                            ViewDidLoad();
                        });

                    }
                    break;

                case "Delete All":
                    {
                        okaction = (UIAlertAction => {
                            DataSql.process(library.File(2), library.detleteAll(), null);
                            ViewDidLoad();
                            _Select = false;

                        });//end

                        Cancelaction = (UIAlertAction => { _Select = false; });



                    }
                    break;
                case "Delete":
                    {
                        okaction = (UIAlertAction => { DeleteSection(); });

                        Cancelaction = (UIAlertAction => {
                            //  Nettab.bar.changebuttonclick();


                            ViewDidLoad();
                        });



                    }
                    break;
            }










            var alert = UIAlertController.Create(string.Empty, "are you sure" + " " + mess, UIAlertControllerStyle.Alert);

            var ok = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, okaction);

            var Cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, Cancelaction);

            alert.AddAction(ok);
            alert.AddAction(Cancel);
            PresentViewController(alert, true, null);
        }
        void sharebox() // share  files   UIActivityViewController
        {
            List<NSObject> activityItems = new List<NSObject>();
            List<string> delfile = new List<string>();
            //   NSObject[] j = lis.ToArray<NSObject>();
            foreach (iEbutton ep in UIbutton)

                if (ep.BackboolSlect()) {


                    if (ep._isvideor())
                    {

                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        string localFilename = ep.setText(); //same if I save the file as .mp4
                        var localPath = Path.Combine(documentsPath, localFilename);

                        File.WriteAllBytes(localPath, ep.retbyet());



                        var url = NSUrl.FromFilename(localPath);

                        var videoToShare = url.Copy();

                        activityItems.Add(videoToShare);
                        delfile.Add(localPath);

                    }





                    else
                    {
                        activityItems.Add(ep.image());
                    }



                }

            //  _Select = false;

            //  var activityItems = lis.ToArray<NSObject>();
            //int i = 0;
            //while (i < lis.Count) { activityItems[i] = lis[i]; i++; }
            //  var imageToShare = UIbutton[0].image();
            // var activityItems = new NSObject[] { imageToShare};




            //var ii = NSUrl.FromFilename(local);

            //var imageToShare = ii.Copy();
            //var activityItems = new NSObject[] { imageToShare };







            var controller = new UIActivityViewController(activityItems.ToArray<NSObject>(), null);




            this.PresentViewController(controller, true, null);
            // new Thread(() => { Thread.Sleep(1000); foreach (string d in delfile) { File.Delete(d); } });

        }
        private void DeleteSection() // delete all bordercolor red
        {
            local _local = new local();
            int row = 0;
            for (row = 0; row < UIbutton.Count; row++)
            {

                if (UIbutton[row].BackboolSlect())
                    _local.remove(UIbutton[row].setText());


            }












            reload();
        }
        private void Bar_add_image(object sender, int d)
        {
            if (d == 1)
            {




                // ViewDidAppear(true);

                try
                {
                    image();
                }
                catch { }

            }


        }
        private void Btn_TouchUpInside(object sender, EventArgs e)
        {

        }
        private void image()
        {
            try
            {
                var picker = new GMImagePickerController();


                im = true;


                picker.Title = library.Tabs(1);
                picker.DisplaySelectionInfoToolbar = true;

                PresentViewControllerAsync(picker, true);
                picker.CustomSmartCollections = new[] { PHAssetCollectionSubtype.AlbumRegular, PHAssetCollectionSubtype.AlbumImported };
                picker.MediaTypes = new[] { PHAssetMediaType.Image, PHAssetMediaType.Video };
                // UIImage ui = new UIImage(PHAssetMediaType.Image.);
                picker.FinishedPickingAssets += Picker_FinishedPickingAssets;

                //  scoll.ContentSize = new CGSize(400, 800);
                //   uIImage.Clear();
                im = false;

                picker = null;
            }
            catch { }

        }
        public bool isSelect() { return _Select; }
        //puls button;
         bool im=true;
        MultiAssetEventArgs _multiAsset;




        void exration()
        {
           // Imagedata.Clear();
            int icount = _multiAsset.Assets.Count();
            string date = string.Empty;
            UIImageView imag = new UIImageView();
            iEbutton button = new iEbutton();
            string endex = string.Empty;
            PHImageManager imageManager = new PHImageManager();
           // bool isvideo = false;
            UIImage image1 = new UIImage();
          //  byetdata = new List<byte[]>();
            foreach (PHAsset asset in _multiAsset.Assets)
            {
                bool isvideo = false;

                AVPlayer avplayer = new AVPlayer();
                
                    if (asset.MediaType == PHAssetMediaType.Video)
                    {
                        isvideo = true;
                        // NSUrl videoUrl = null;

                        imageManager.RequestAvAsset(asset, null, (avsset, avaudio, NsD) =>
                        {

                            //   string UrlConvertString = null;

                            var videoUrl = ((AVFoundation.AVUrlAsset)avsset).Url;
                            string UrlConvertString = (videoUrl.AbsoluteString);

                            UrlVideoString.Add(UrlConvertString);


                        });
                    }

                    imageManager.RequestImageForAsset(asset,
                 new CGSize(asset.PixelWidth, asset.PixelHeight),
                 PHImageContentMode.Default,
                 null,
                 (image, info) =>
                 {

                     //  endex = image.AccessibilityPath.ToString();

                     //  endex = "jpg";

                     //

                     if (!isvideo)
                     {
                         //  im = false;

                         //byte[] myByteArray;
                         //using (NSData imageData = image.AsPNG())
                         //{
                         //    myByteArray = new Byte[imageData.Length];
                         //    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));


                         //}





                         //    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                         //    string localFilename = "text.jpg"; //same if I save the file as .mp4
                         //    var localPath = Path.Combine(documentsPath, localFilename);

                         //    File.WriteAllBytes(localPath, myByteArray);
                         //    byte[] n = File.ReadAllBytes(localPath);


                         //Imagedata.Add(image);

                         //string random = GeneratePassword(7);

                         // DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random + ".jpg", n, "jpg/png"));


                         //  DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random + ".jpg", n, "jpg/png"));
                         //node} 






                         byte[] myByteArray;
                         using (NSData imageData = image.AsPNG())
                         {
                             myByteArray = new Byte[imageData.Length];
                             System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));


                         }
                         //byetdata.Add(myByteArray);
                         //  byetdata.Add(myByteArray);

                         //node
                         string random = GeneratePassword(7);
                        // string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        // string localFilename = random+".jpg"; //same if I save the file as .mp4
                       //  var localPath = Path.Combine(documentsPath, localFilename);

                     //    File.WriteAllBytes(localPath, myByteArray);
                       //  byte[] n = File.ReadAllBytes(localPath);




                       
                         

                        // Imagedata.Add(image);
                           DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random + ".jpg", myByteArray, "jpg/png"));
                         //node
                        
                     }

                     isvideo = true;

                     // button.creation(i, image);

                     //  date = DateTime.Now.ToString("MMddHHmmss");
                     icount--;

                     Thread.Sleep(500);

                 });
                }
                //button.getText(date);
                //button.click += Button_TouchUpInside; ;
                // isvideo = false;

                //UIbutton.Add(button);
                //  lab.Text = ImageView.Count.ToString();

                // Imagedata.Add(image1);



              
            //nd foreach}
            _multiAsset = null;
            todatabese();
            finshpluse = 1;

        }
        private void Picker_FinishedPickingAssets(object sender, MultiAssetEventArgs args)
        {
            _multiAsset = args;

           

          

            // imgView.Image= pHAsset.Location

            //    uIImage. = pHAsset.Location();
            //   List<  UIImage> uIImage = new List<UIImage> ();
        

            //foreach (PHAsset asset in args.Assets)
            //{//
            //    string date = string.Empty;
            //    UIImageView imag = new UIImageView();
            //    iEbutton button = new iEbutton();
            //    string endex = string.Empty;


            //    UIImage image1 = new UIImage();

            //    AVPlayer avplayer = new AVPlayer();
            //    if (icount >= 0) {
            //        if (asset.MediaType == PHAssetMediaType.Video)
            //        {
            //            isvideo = true;
            //            // NSUrl videoUrl = null;

            //            imageManager.RequestAvAsset(asset, null, (avsset, avaudio, NsD) =>
            //            {

            //                //   string UrlConvertString = null;

            //                var videoUrl = ((AVFoundation.AVUrlAsset)avsset).Url;
            //                string UrlConvertString = (videoUrl.AbsoluteString);

            //                UrlVideoString.Add(UrlConvertString);


            //            });
            //        }

            //        imageManager.RequestImageForAsset(asset,
            //     new CGSize(asset.PixelWidth, asset.PixelHeight),
            //     PHImageContentMode.Default,
            //     null,
            //     (image, info) =>
            //     {

            //         //  endex = image.AccessibilityPath.ToString();

            //         //  endex = "jpg";

            //         //

            //         if (!isvideo)
            //         {
            //             im = image;



            //             //  Imagedata.Add(image);

            //             byte[] myByteArray;
            //             using (NSData imageData = image.AsPNG())
            //             {
            //                 myByteArray = new Byte[imageData.Length];
            //                 System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));


            //             }


            //             //node

            //             string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //             string localFilename = "text.jpg"; //same if I save the file as .mp4
            //             var localPath = Path.Combine(documentsPath, localFilename);

            //             File.WriteAllBytes(localPath, myByteArray);
            //             byte[] n = File.ReadAllBytes(localPath);




            //             string random = GeneratePassword(7);



            //             DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random + ".jpg", n, "jpg/png"));
            //             //node
            //         }



            //         // button.creation(i, image);

            //         //  date = DateTime.Now.ToString("MMddHHmmss");
            //         icount--;
            //         Thread.Sleep(500);
                   

            //    });
            //}
            //    //button.getText(date);
            //    //button.click += Button_TouchUpInside; ;
            //   // isvideo = false;

            //    //UIbutton.Add(button);
            //    //  lab.Text = ImageView.Count.ToString();

            //    // Imagedata.Add(image1);





            //}//end foreach

            // finshpluse = 1;

            //  imgView.Image = uIImage[uIImage.Count-1];



            //  scoll = new UIScrollView();
            //if (scoll.Frame.Height > scoll.Frame.Width )
            //{

            //    scoll.ContentSize = new CGSize(uiv.Frame.Width -70, ImageView.Count * 15);
            //    putimage(50,70,14);

            //}

            //else { scoll.ContentSize = new CGSize(ImageView.Count+20, ImageView.Count * 15);


            //    putimage(80, 90, 40);



            //}
            exration();

            
          //  im = false;
            //finshpluse = 1;
            //todatabese();
            ;
        }
        void todatabesevideo()
        { }
        void todatabese()
        {
            List<byte[]> Imagebyeds = new List<byte[]>();
            List<string> strimg = new List<string>();
            foreach (UIImage image1 in Imagedata)
            {
                DataSql = new DataSql();
              
                Byte[] myByteArray;
                using (NSData imageData = image1.AsPNG())
                {
                    myByteArray = new Byte[imageData.Length];
                    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));


                }
                string random = GeneratePassword(7);
                Imagebyeds.Add(myByteArray);
                strimg.Add(random);
                DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random+".jpg", myByteArray, "jpg/png"));
            }
            foreach (string stringUrl in UrlVideoString)
            {


                DataSql = new DataSql();

                byte[] myByteArray;
                using (NSData data = NSData.FromUrl(NSUrl.FromString(stringUrl)))
                {


                    myByteArray = new byte[data.Length];

                    System.Runtime.InteropServices.Marshal.Copy(data.Bytes, myByteArray, 0, Convert.ToInt32(data.Length));
                }
                string random = GeneratePassword(7);
                // this.Title = videoUrl.ToString(); ;

                DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random+".mp4", myByteArray, "mov"));
            }


            foreach (byte[] stringUrl in byetdata)
            {
               
                    string random = GeneratePassword(7);
                    DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(random + ".jpg", stringUrl, "jpg/png"));
                
            }
            
         // 

            reload();
            //cal.addbutton(Imagebyeds, strimg);
            // Imagebyeds.Clear();
            // strimg.Clear();
            UrlVideoString.Clear();
            Imagedata.Clear();
            byetdata.Clear();
        }


        private SqliteParameterCollection DataSql_Parameters(string date, byte[] m, string j)
        {
            //  var date = DateTime.Now.ToString(" HH:mm:ss");
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row + 0.ToString(), date);

            ReturnParamter.AddWithValue(LibraryWords.Row + 1.ToString(), m);
            ReturnParamter.AddWithValue(LibraryWords.Row + 2.ToString(), j);

            return ReturnParamter;

        }

        private List<UIImage> byeimge()
        {



            List<UIImage> showimgelist = new List<UIImage>();



            foreach (byte[] byt in DataSql.databyet)
            {
                // MemoryStream ms = new MemoryStream(imageBytes);
                byte[] encodedDataAsBytes = byt;
                NSData data = NSData.FromArray(encodedDataAsBytes);
                var uiImage = UIImage.LoadFromData(data);
                showimgelist.Add(uiImage);
            }





            return showimgelist;
        }
        private string GeneratePassword(int num)
        {
            string strPwdchar = "abcdefghijklmnopqrstuvwxyz0123456789";
            string strPwd = "";
            Random rnd = new Random();
            for (int i = 0; i <= num; i++)
            {
                int iRandom = rnd.Next(0, strPwdchar.Length - 1);
                strPwd += strPwdchar.Substring(iRandom, 1);
            }
            return strPwd;
        }

        ViewWer view;
        private object fileName;

        public object MediaFileType { get; private set; }
        public object TemporalDirectoryName { get; private set; }

        //private void Button_TouchUpInside(int number, string text, iEbutton iebutton)
        //{

        //    try {
        //        UIStoryboard storyboard = UIStoryboard.FromName("boardimg", null);

        //        view = storyboard.InstantiateViewController("imageview") as ViewWer;


        //        view.getimge(iebutton.image(), iebutton.getText(), number);
        //        //  var but = (UIButton)sender;
        //        //  int info = Convert.ToUInt16(but.TitleLabel.Text );

        //        NavigationController.PushViewController(view, true);




        //    }
        //    catch { }

        //}

        private void putimage(int size, int far, int min)
        {


            // lab.Text = ImageView.Count.ToString();



            // int x = 0, y = 0;
            //for(int i=0;i< UIbutton.Count;i++)
            // {

            //  //   ImageView[i].tu

            //    // ImageView[i].Frame = new RectangleF(x, y, size, size);
            //     UIbutton[i].Frame(x, y, size);
            //     x = x + far;
            //     if (x >= scoll.Frame.Width -min)
            //     {
            //         x = 0;
            //         y = y + far;

            //     }

            //   UIbutton[i].TouchUpInside += Images_TouchUpOutside;  
            // scoll.Add(UIbutton[i].RButton());

            //  scoll.Delete(UIbutton[i].RButton());


            // }
        }
        public void localdelet()
        {





            reload();

        }
        private void reload()
        {
           
            try
            {
                int i = 0;
              //  foreach (var n in viewcoll.Subviews) { viewcoll.Delete(n); }
            }
            catch { }
            local cal = new local();
            DataSql = new DataSql();





            //foreach (var view in scoll.Subviews)
            //{
            //    view.RemoveFromSuperview();
            //}

            UIbutton = cal.retUIbutton();

            bool isEmpty = UIbutton.Any();

            if (isEmpty) { Nettab.bar.Change(isEmpty); }

            else { Nettab.bar.Change(false); }


            // viewcoll.RegisterClassForSupplementaryView(typeof(CollectionViewCell1), CollectionViewCell1.Key);

            CollectionView.RegisterClassForCell(typeof(CollectionViewCell1), CollectionViewCell1.Key);

            CollectionView.RegisterClassForSupplementaryView(typeof(CollectionViewCell1), UICollectionElementKindSection.Header, CollectionViewCell1.Key);
            CollectionView.Source = new sourcecollection(UIbutton);
           
            //   scoll.ContentSize = new CGSize(uiv.Frame.Width - 20, ImageView.Count * 15);



            //}

        }

    }
}