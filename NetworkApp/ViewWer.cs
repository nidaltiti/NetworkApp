using Foundation;
using Mono.Data.Sqlite;
using System;
using UIKit;
using System.Threading;
using NetworkApp;
namespace Network_App
{
    public partial class ViewWer : UIViewController
    {
        LibraryWords library = new LibraryWords();
        DataSql DataSql;
        UIImage uIImage;
        string text;
        iEbutton eb;
        int num;
        public ViewWer(IntPtr handle) : base(handle)
        {
        }



        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //
            ximage.Image = uIImage;

            UIBarButtonItem savebutton = new UIBarButtonItem();

            savebutton.Title = "Save";

            savebutton.Clicked += Savebutton_Clicked;
            this.NavigationItem.SetRightBarButtonItem(savebutton, true);
          


        }

        private void Savebutton_Clicked(object sender, EventArgs e)
        {
            alertsure("Save");
         }

        public    void getimge(UIImage xuIImage, string Title,int nub ,byte[] b)
        {
            num = nub;
            uIImage = xuIImage;
            this.Title = Title;
            text = Title;

        }
   
        partial void Delete_Activated(UIBarButtonItem sender)
        {
            alertsure("Delete");
        }
        void alertsure(string mess)
        {


            Action<UIAlertAction> okaction = null;
            Action<UIAlertAction> Cancelaction = null;

            switch (mess)
            {
                case "Save":
                    {
                        okaction = (UIAlertAction => {


                            var someImage = uIImage;
                            someImage.SaveToPhotosAlbum((image, error) =>
                            {
                                var o = image as UIImage;

                                Console.WriteLine("error:" + error);
                            });





                        });


                        Cancelaction = (UIAlertAction => {
                            //  Nettab.bar.changebuttonclick();


                            
                        });

                    }
                    break;

               
                   
                case "Delete":
                    {
                        okaction = (UIAlertAction => { detelet(); });

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
        } //messgebox ask are you sure 
        //private SqliteParameterCollection DataSql_Parameters(string data)
        //{
        //    SqliteCommand SqliteCommand = new SqliteCommand();
        //    SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

        //    ReturnParamter.AddWithValue(LibraryWords.Row, data);

        //    return ReturnParamter;

        //}
        private void detelet() {



            try
            {
                local cal = new local();
                //    Images mig =new Images ()
                cal.remove(text);
                Images.imG.ViewDidLoad();
            }
            catch {
                var armAlert = UIAlertController.Create("database dot open", string.Empty, UIAlertControllerStyle.Alert);
                var cancelAction1 = UIAlertAction.Create("ok", UIAlertActionStyle.Cancel, alertAction1 => { });

                armAlert.AddAction(cancelAction1);


                PresentViewController(armAlert, true, null);
            }

            NavigationController.PopViewController(true);


        }

        partial void UIBarButtonItem264_Activated(UIBarButtonItem sender)//share button
        {


            var imageToShare = uIImage;
             var activityItems = new NSObject[] { imageToShare};

            var controller = new UIActivityViewController(activityItems, null);




            this.PresentViewController(controller, true, null);


        }

        partial void Settings_button_Activated(UIBarButtonItem sender)
        {
            throw new NotImplementedException();
        }
    }


   
    
}