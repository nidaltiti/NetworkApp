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
        List<string> extfile = new List<string>();
        List<byte[]> listByete = new List< byte[] > ();
        List<byte[]> tumbmaillist = new List<byte[]>();


        public List<string > retDataString(int row, int table) //retturn string
        {
            List<string> Datastring = new List<string>();
            // data();
            DataSql dataSql = new DataSql();
          //  DataSql.data.Clear();
            dataSql.Rowdata(row);
            dataSql.lop = "string";
          //  DataSql dataSql = new DataSql();
            dataSql.process(library.File(2), library.SELECT(table), null);
            Datastring = dataSql.return_string();



            return Datastring;

        }
        public List<byte[]> retDataByet(int row,int table) //retturn byet
        {
            DataSql.databyet.Clear();

            List <byte[] > Data = new List<byte[]>();
            DataSql dataSql = new DataSql();
            // data();
            dataSql.Rowdata(row);
            dataSql.lop = "byte";
           // DataSql dataSql = new DataSql();
            dataSql.process(library.File(2), library.SELECT(table), null);
            Data = dataSql.return_byet();


            return Data;

        }
        public List<int> Retdatainger(int row,int table) //retturn int
        {
            //  DataSql.datainger.Clear();
            DataSql dataSql = new DataSql();
            List<int> Data = new List<int>();
            // data();
            dataSql.Rowdata(row);
            dataSql.lop = "int";
           
            dataSql.process(library.File(2), library.SELECT(table), null);
            Data = dataSql.return_Intger();


            return Data;

        }

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
                //DataSql.databyet.Clear();
                //DataSql.data.Clear();
                //  uIImage.Clear();
                tumbmaillist.Clear();
                extfile.Clear();
                nameimage.Clear();
                UIbutton.Clear();
                sourcecollection._collectionViewCell.Clear();
                //{
                //DataSql.lop = "byte";
                //DataSql.Rowdata(1);
                //DataSql.process(library.File(2), library.SELECT(1), null);
                
                //   uIImage = byeimge();

                //DataSql.lop = "string";
                //DataSql.Rowdata(0);
                //DataSql.process(library.File(2), library.SELECT(1), null);
                nameimage = retDataString(0, 1);
                listByete = retDataByet(1, 1);
                tumbmaillist = retDataByet(2, 1);
                extfile = retDataString(3, 1);
                setbutton();

                //DataSql.data.Clear();
                //DataSql.databyet.Clear();
                UIbutton.Clear();
            }





            catch { }
        }
        private void setbutton()
        {
            
            for (int icount = 0; icount <= DataSql.databyet.Count; icount++)
            {


                iEbutton button = new iEbutton();
                button.ext(extfile[icount]);
                button.whate_is_byte(listByete[icount], icount);
            //    button.creation(icount, DataSql.databyet[icount]);
                button.getText(nameimage[icount]);
             
                button.click += Button_click;

                if (button._isvideor())
                {//change
                    //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //string localFilename = nameimage[icount] + ".mov"; //same if I save the file as .mp4
                    //string localPath = Path.Combine(documentsPath, localFilename);

                    //File.WriteAllBytes(localPath, DataSql.databyet[icount].ToArray());

                    //var avasset = AVAsset.FromUrl(NSUrl.FromFilename(localPath));
                    //var avplayerItem = new AVPlayerItem(avasset);
                    //var avplayer = new AVPlayer(avplayerItem);
                    //var avplayerLayer = AVPlayerLayer.FromPlayer(avplayer);
                    //button.localstring(localPath);
                    //File.Delete(localPath);
                   
                    
                    button.creatFilemov(tumbmaillist[icount]);

                    // var capture = UIScreen.MainScreen.Capture();


                }
                
                else { button.creationimge(); }


                UIbutton.Add(button);
              //  Thread.Sleep(1000);
            }
        }

        private void Button_click(int number, string text, iEbutton iebutton)
        {
            if (img.imG.isSelect()==false)
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
                        
                        view.file( iebutton.setText(), iebutton.retbyet());
                        img.imG.NavigationController.PushViewController(view, true);
                       // view.getimge(iebutton.image(), iebutton.setText(), iebutton.buttonnumber());
                    }
                    else
                    {
                        UIStoryboard storyboard = UIStoryboard.FromName("boardimg", null);

                        var view = storyboard.InstantiateViewController("imageview") as ViewWer;



                        //  var but = (UIButton)sender;
                        //  int info = Convert.ToUInt16(but.TitleLabel.Text );

                        img.imG.NavigationController.PushViewController(view, true);
                        view.getimge(iebutton.image(), iebutton.setText(), iebutton.buttonnumber(), iebutton.retbyet());

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
        public void Uplod(string[] eb)
        {




            DataSql = new DataSql();
            // DataSql.close();



            DataSql.process(library.File(2), library.Upload(), DataSql_Parameters(eb));

        }

        private SqliteParameterCollection DataSql_Parameters(string data)
        {
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row ,data);

            return ReturnParamter;

        }
        private SqliteParameterCollection DataSql_Parameters(string[] data)
        {
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row, data[0]);
            ReturnParamter.AddWithValue(LibraryWords.Row +1.ToString(), data[1]);
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