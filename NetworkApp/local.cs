using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using Foundation;
using UIKit;
using NetworkApp;
using System.IO;
using System.Threading;
using AVFoundation;

namespace Network_App
{

    class local
    {
   public  static   List  <string> deletlist = new List<string>();
        DataSql DataSql = new DataSql();
        LibraryWords library = new LibraryWords();
        static List<UIImage> uIImage = new List<UIImage>();
        List<UIImageView> ImageView = new List<UIImageView>();
     public static   List<iEbutton> UIbutton = new List<iEbutton>();
        List<string> nameimage = new List<string>();

       

        public List<iEbutton> retUIbutton()
        {
            data();


            return UIbutton;

        }

        private void data()
        {



            try
            {
              //  DataSql DataSql = new DataSql();
                DataSql.databyet.Clear();
                DataSql.data.Clear();
                //  uIImage.Clear();
                nameimage.Clear();
                UIbutton.Clear();
                sourcecollection._collectionViewCell.Clear();
                //{
                DataSql.lop = "";
                DataSql.Rowdata(1);
                DataSql.process(library.File(2), library.SELECT(1), null);


                //   uIImage = byeimge();

                DataSql.lop = "string";
                DataSql.Rowdata(0);
                DataSql.process(library.File(2), library.SELECT(1), null);
                nameimage = DataSql.data;

                setbutton();

                DataSql.data.Clear();
                DataSql.databyet.Clear();
                UIbutton.Clear();
            }





            catch { }
        }
        private void setbutton()
        {
            
            for (int icount = 0; icount <= DataSql.databyet.Count; icount++)
            {


                iEbutton button = new iEbutton();

                button.whate_is_byte(DataSql.databyet[icount], icount);
            //    button.creation(icount, DataSql.databyet[icount]);
                button.getText(nameimage[icount]);
                
                button.click += Button_click;

                if (button._isvideor())
                {
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string localFilename = nameimage[icount] + ".mov"; //same if I save the file as .mp4
                    string localPath = Path.Combine(documentsPath, localFilename);

                    File.WriteAllBytes(localPath, DataSql.databyet[icount].ToArray());

                    var avasset = AVAsset.FromUrl(NSUrl.FromFilename(localPath));
                    var avplayerItem = new AVPlayerItem(avasset);
                    var avplayer = new AVPlayer(avplayerItem);
                    var avplayerLayer = AVPlayerLayer.FromPlayer(avplayer);
                    button.localstring(localPath);
                    button.creatFilemov(avplayerLayer);
                }
                
                else { button.creationimge(); }


                UIbutton.Add(button);
              //  Thread.Sleep(1000);
            }
        }

        private void Button_click(int number, string text, iEbutton iebutton)
        {
            if (Images.imG.isSelect()==false)
            {
                try
                {
                    if ((iebutton._isvideor()))
                    {
                        UIStoryboard storyboard = UIStoryboard.FromName("boardimg", null);

                        var view = storyboard.InstantiateViewController("idVid") as AMvideo;

                       
                        //   view.creat(iebutton.retbyet());
                        //  var but = (UIButton)sender;
                        //  int info = Convert.ToUInt16(but.TitleLabel.Text );
                        
                        view.file(iebutton._AVPlayer(), iebutton.setText(), iebutton.retbyet());
                        Images.imG.NavigationController.PushViewController(view, true);
                       // view.getimge(iebutton.image(), iebutton.setText(), iebutton.buttonnumber());
                    }
                    else
                    {
                        UIStoryboard storyboard = UIStoryboard.FromName("boardimg", null);

                        var view = storyboard.InstantiateViewController("imageview") as ViewWer;



                        //  var but = (UIButton)sender;
                        //  int info = Convert.ToUInt16(but.TitleLabel.Text );

                        Images.imG.NavigationController.PushViewController(view, true);
                        view.getimge(iebutton.image(), iebutton.setText(), iebutton.buttonnumber());

                    }
                }
                catch { }
            }
            else { sourcecollection._collectionViewCell[number].BorderColor();

                iebutton.booldelert();

            }
        }
        public void remove(string eb)
        {


          
            
                DataSql = new DataSql();
               // DataSql.close();



                DataSql.process(library.File(2), library.DELETE(1), DataSql_Parameters(eb));
                     
        }

        private SqliteParameterCollection DataSql_Parameters(string data)
        {
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row ,data);

            return ReturnParamter;

        }
        public List<iEbutton> retUIbutton(int add)
        {



            return UIbutton;

        }
        public void addbutton(List<byte[]> Imagedata, List<string> strimg)
        {
            for (int icount = 0; icount < Imagedata.Count; icount++)
            {


                iEbutton button = new iEbutton();
               // button.creation(icount, Imagedata[icount]);
                button.getText(strimg[icount]);

                button.click += Button_click;

                UIbutton.Add(button);

            }
           
        }
      
    }
}