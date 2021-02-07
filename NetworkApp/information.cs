using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AssetsLibrary;
using AVFoundation;
using Foundation;
using Mono.Data.Sqlite;
using Network_App;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UIKit;


namespace NetworkApp
{
    class information
    {
        public static bool isconnct = false;
        DataSql _DataSql = new DataSql();
        Connect connect;
        receive _receive;
        Connect tansconnet;
        static bool  downloading = false;
        string outfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static List<queue> _QueueList = new List<queue>();
    static    Tranferclint _Tranferclint = new Tranferclint();
        static int w;
     static   ListSQL _ListSQL = new ListSQL();



        //    receive _receive;
        // Socket sck;

        public delegate void SeverDiconncet(String data);

       static List<js> json_list = new List<js>();


        public event SeverDiconncet Diconncet;
        public void connet(string Address, int port) {

            try { isconnct = true;


             

                    // Thread.Sleep(500);
                    tansconnet = new Connect(Address, port);

                   // connect = new Connect(Address, --port);


                   // _receive = new receive(connect.rentun_Socket());

                 //   _receive.Receive += _receive_Receive;

                   // _receive.Diconncet += _receive_Diconncet;
                    _Tranferclint.Connect(tansconnet.rentun_Socket());
                    _Tranferclint.OutputFolder = outfolder;
                    _Tranferclint.Queued += _Tranferclint_Queued;
                _Tranferclint.Disconnected += _Tranferclint_Disconnected;
                    _Tranferclint.Run();
                    //_Tranferclint.Receive += _Tranferclint_Receive;
                    //   sck = _receive.retun_socket();
                    ConverToJson();

                    send();


             





            }




            catch { }









        }

        private void _Tranferclint_Disconnected(object sender, EventArgs e)
        {foreach (queue q in _QueueList) { q.Close(); }

           

            _Tranferclint.Close();
           // _Tranferclint = null;
          //  isconnct = true;
            _QueueList.Clear();
            isconnct = false;
              if (Diconncet != null) Diconncet("conncet");
            // throw new NotImplementedException();
        }

        private void _Tranferclint_Receive(byte[] data)
        {
            if (data.Length < 0) { }
        }

        static string Type;
        NSTimer Timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(0.1), delegate {


          



            for (int i = 0; i < _QueueList.Count; i++) {

                if (_QueueList[i].Progress == 100 || !_QueueList[i].Running)
                {





                    //  Type = _QueueList[i]._Type;



                    DataSql _DataSql = new DataSql();

                    LibraryWords library = new LibraryWords();

                    //   UIImage image;

                    //var myByteArray = File.ReadAllBytes(_QueueList[i].Filename);

                    //byte[] myByteThumbnail= null;


                    //if (_QueueList[i]._Type == "Video") {



                    //    //// byte[] myByteArray;
                    //    CoreMedia.CMTime actualTime;
                    //    NSError outError;
                    //    using (var asset = AVAsset.FromUrl(NSUrl.FromFilename(_QueueList[i].Filename)))
                    //    using (var imageGen = new AVAssetImageGenerator(asset))
                    //    using (var imageRef = imageGen.CopyCGImageAtTime(new CoreMedia.CMTime(1, 1), out actualTime, out outError))
                    //    {
                    //        if (imageRef == null)
                    //        {
                    //            // return null;
                    //        }
                    //        image = UIImage.FromImage(imageRef);
                    //    }
                    //    using (NSData imageData = image.AsPNG())
                    //    {
                    //        myByteThumbnail = new Byte[imageData.Length];
                    //        System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteThumbnail, 0, Convert.ToInt32(imageData.Length));


                    //    }
                    //}
                    //else { myByteThumbnail = myByteArray; }

                    //_DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(Path.GetFileName(_QueueList[i].Filename), myByteArray, myByteThumbnail, _QueueList[i]._Type));

                    if (_QueueList[i].Type == QueueType.Download)
                    {
                        if ( Path .GetFileName( _QueueList[i].Filename) !="commad.json")
                        {
                            Save_Data(_QueueList[i]);
                        }
                        else {
                            Getcommand (_QueueList[i].Filename); 
                        
                        
                        }
                    }
                    if (save.Savegerlly)
                    {
                       
                    }
                        File.Delete(_QueueList[i].Filename);

                    _QueueList.RemoveAt(i);
                }

             



            }
            bool isEmpty = _QueueList.Any();

            if (downloading && isEmpty == false) 
            
            { 
                ConverToJson(); downloading = false;
            
            
            
            
            
            
            
            
            }




        });




        private static void Save_Data(queue Finsh_queue) {


            DataSql _DataSql = new DataSql();
            UIImage image;
            LibraryWords library = new LibraryWords();



            var myByteArray = File.ReadAllBytes(Finsh_queue.Filename);

            byte[] myByteThumbnail = null;


            if (Finsh_queue._Type == "Video")
            {

               
               
              //   byte[] myByteArray;
                CoreMedia.CMTime actualTime;
                NSError outError;
                using (var asset = AVAsset.FromUrl(NSUrl.FromFilename(Finsh_queue.Filename)))
                using (var imageGen = new AVAssetImageGenerator(asset))
                using (var imageRef = imageGen.CopyCGImageAtTime(new CoreMedia.CMTime(1, 1), out actualTime, out outError))
                {
                    if (imageRef == null)
                    {
                        // return null;
                    }
                    image = UIImage.FromImage(imageRef);
                }
                using (NSData imageData = image.AsPNG())
                {
                    myByteThumbnail = new Byte[imageData.Length];
                    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteThumbnail, 0, Convert.ToInt32(imageData.Length));


                }


                if (save.Savegerlly) {

                    if (File.Exists(Finsh_queue.Filename))
                    {
                        savedowloaning file = new savedowloaning();
                        // AMvideo.SaveToAlbum(Finsh_queue.Filename);
                        file.Get_clipfile(Finsh_queue.ID.ToString(), myByteArray);
                        // ALAssetsLibrary lib = new ALAssetsLibrary();
                        // lib.WriteVideoToSavedPhotosAlbum(NSUrl.FromFilename(Finsh_queue.Filename), (t, u) => { });
                    }
                }



            }
            else { myByteThumbnail = myByteArray;


                if (save.Savegerlly)
                {
                  
                        savedowloaning file = new savedowloaning();
                        file.Get_imagefile(Finsh_queue.ID.ToString(), myByteArray);


                   


                }





            }


            _DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(Path.GetFileName(Finsh_queue.Filename), myByteArray, myByteThumbnail, Finsh_queue._Type)); }

       
        
        
        
        
        
        
        
        //private void Save_image(queue Finsh_queue) {

        //    var myByteArray = File.ReadAllBytes(Finsh_queue.Filename);
        //    _DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(Finsh_queue.Filename + ".jpg", myByteArray, "Image"));





        //}



        //change

        private static SqliteParameterCollection DataSql_Parameters(string date, byte[] m, byte[] g, string j)
        {
            //  var date = DateTime.Now.ToString(" HH:mm:ss");
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

            ReturnParamter.AddWithValue(LibraryWords.Row + 0.ToString(), date);
            ReturnParamter.AddWithValue(LibraryWords.Row + 1.ToString(), m);
            ReturnParamter.AddWithValue(LibraryWords.Row + 2.ToString(), g);
            ReturnParamter.AddWithValue(LibraryWords.Row + 3.ToString(), j);

            return ReturnParamter;

        }

        private void _Tranferclint_Queued(object sender, queue queue)
        {
            if (queue.Type == QueueType.Download) { _Tranferclint.StartTransfer(queue); downloading = true; }


            _QueueList.Add(queue);
        }


    static    private void send()
        {
           
                //  Thread.Sleep(1000);

                // _receive.SendSocket(json_list);

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename = "list.json"; //same if I save the file as .mp4
                string localPath = Path.Combine(documentsPath, localFilename);
                string n = JsonConvert.SerializeObject(json_list);
                using (var tw = new StreamWriter(localPath, true))
                {
                    tw.WriteLine(n);
                    tw.Close();
                }
                _Tranferclint.QueueTransfer(localPath);

           












        }
       // string localPath;
        private static  void   ConverToJson() {


            json_list.Clear();

            local _local = new local();

            _ListSQL.NameFile = _local.retDataString(0, 1);
            _ListSQL.Type = _local.retDataString(3, 1);

            //  _ListSQL.ImageToBytes



            _ListSQL.ImageToBytes = _local.retDataByet(1, 1);
            // throw new NotImplementedException();
            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string localFilename = _ListSQL.NameFile[0]; //same if I save the file as .mp4
            //localPath = Path.Combine(documentsPath, localFilename);

            //File.WriteAllBytes(localPath, _ListSQL.ImageToBytes[0]);



            int i = 0;


            while (i < _ListSQL.NameFile.Count) {
                js _js = new js { NameFile = _ListSQL.NameFile[i], Type = _ListSQL.Type[i], Auto=save.Savegerlly  };

                json_list.Add(_js);

                i++;



            }




        }






        //private void _receive_Diconncet(receive sender, byte[] data)
        //{
        //    isconnct = false;
        //    if (Diconncet != null) Diconncet("conncet");
        //}
        private  static     void Getcommand(string nameFile)
        {
            string reader;
            JArray formatted;
            StreamReader read = new StreamReader(nameFile);
            


                 reader = read.ReadToEnd();
              //  string Arrayjson = reader;


                
                read.Close();

            

            formatted = JArray.Parse("["+reader+"]");

            save.Savegerlly = formatted[0]["Auto"].Value<bool>();

            if (formatted[0]["numbcommdan"].Value<string>() == "100") { commandLoad(); }

            else
            {

                //  string jsonstring =  datasting ;
                JArray format = formatted;
                int i = format[0]["numbcommdan"].Value<int>();

                //  string j= format[0]["array"][1].Value<string>();
                _listcomand.Clear();
                aray(format, 0);


                command(i, format);

                // Upload(_Tranferclint, _ListSQL);
                //   w = 1;


            }
        }
        //private void _receive_Receive(receive sender, byte[] data)
        //{   /*
        //    string localPath = string.Empty;
        //    //throw new NotImplementedException();
        //    new Thread(() =>
        //    {
        //        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //        string localFilename = _ListSQL.NameFile[0]; //same if I save the file as .mp4
        //         localPath = Path.Combine(documentsPath, localFilename);
               
        //        File.WriteAllBytes(localPath, _ListSQL.ImageToBytes[0]);
        //        Thread.Sleep(100);
        //        _Tranferclint.QueueTransfer(localPath);
        //    }).Start();
           
        //  */
          
        //    string datasting = Encoding.Default.GetString(data);

        //    if (datasting == "100") { commandLoad(); }

        //    else
        //    {

        //        string jsonstring = "[" + datasting + "]";
        //        JArray format = JArray.Parse(jsonstring);
        //        int i = format[0]["numbcommdan"].Value<int>();

        //        //  string j= format[0]["array"][1].Value<string>();
        //        _listcomand.Clear();
        //        aray(format, 0);


        //        command(i, format);

        //        // Upload(_Tranferclint, _ListSQL);
        //        //   w = 1;


        //    }



        //}
      static  List<string> _listcomand = new List<string>();
     static   void      aray(JArray JD,int iJ)
        {
            _listcomand.Add(JD[0]["array"][iJ].Value<string>());

          
            try
            {


                iJ++;
                aray(JD, iJ);
               

              
            }
            catch { }
        }
        
        private static void commandLoad() {
            ConverToJson();

            send(); 
                
                
                
                }


        static void command(int i, JArray JD) {
            switch (i) 
            {

                case 0: dowload_now(); break;
                case 1: Delete(); break;
                case 2:  Delete_all() ; break;
                case 3: dowloadAll(); break;
            }
        
        
        
        
        
        }
        static void dowloadAll()
        {
            for (int i = 0; i < _ListSQL.NameFile.Count; i++)

            {
              
                    string filename = _ListSQL.NameFile[i];
                    byte[] byetesfile = _ListSQL.ImageToBytes[i];
                    new Thread(() =>
                    {
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        string localFilename = filename; //same if I save the file as .mp4
                        string localPath = Path.Combine(documentsPath, localFilename);
                        Thread.Sleep(5);
                        File.WriteAllBytes(localPath, byetesfile);

                        _Tranferclint.QueueTransfer(localPath);
                    }).Start();


                
            }
        }
        static void Delete_all() { 
            local _local = new local();

            _local.Delete_all();




        }
        static void dowload_now() {
            //int i = 0;
           
            
            
            for (int i = 0; i < _listcomand.Count;  i++) {
                
                for (int j = 0; j < _ListSQL.NameFile.Count; j++)

                {
                    if (_listcomand[i] == _ListSQL.NameFile[j])
                    
                        {
                        string filename = _ListSQL.NameFile[j];
                        byte[] byetesfile = _ListSQL.ImageToBytes[j];
                        new Thread(() =>
                        {
                            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            string localFilename = filename; //same if I save the file as .mp4
                            string localPath = Path.Combine(documentsPath, localFilename);
                            Thread.Sleep(150);
                            File.WriteAllBytes(localPath, byetesfile);
                            
                            _Tranferclint.QueueTransfer(localPath);
                        }).Start();
                        
                        
                    }
                  
                }
               
            }
        }






        static void   Delete() {
            int i = 0;
            while (i<_listcomand.Count) {

                
                
                
                local cal = new local();
                //    Images mig =new Images ()
                cal.remove(_listcomand[i]);
                i++;

            }
        
        
        
        
        }
       


        static void Upload(Tranferclint _Tranferclint, ListSQL _ListSQL ) {


        
        
        
        
        
        
        }





        public void stop (){

            isconnct = false;
            try
            {
               // connect.close();
                _Tranferclint.Close();
                _QueueList.Clear();
                tansconnet.close();
                _Tranferclint = new Tranferclint();
            }
            catch { }


        }







    }
}