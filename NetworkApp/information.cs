using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AVFoundation;
using Foundation;
using Mono.Data.Sqlite;
using Network_App;
using Newtonsoft.Json;
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
      
        string outfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
     static   List<queue> _QueueList = new List<queue>();
        Tranferclint _Tranferclint = new Tranferclint();




        //    receive _receive;
        // Socket sck;

        public delegate void SeverDiconncet(String data);

        List<js> json_list = new List<js>();


        public event SeverDiconncet Diconncet;
        public void connet(string Address, int port) {

            try { isconnct = true;


                new Thread(() => {

                   // Thread.Sleep(500);
                    tansconnet = new Connect(Address, port);

                    connect = new Connect(Address, --port);


                    _receive = new receive(connect.rentun_Socket());

                    _receive.Receive += _receive_Receive;

                    _receive.Diconncet += _receive_Diconncet;
                    _Tranferclint.Connect(tansconnet.rentun_Socket());
                    _Tranferclint.OutputFolder = outfolder;
                    _Tranferclint.Queued += _Tranferclint_Queued;
                    _Tranferclint.Run();
                    //   sck = _receive.retun_socket();
                    ConverToJson();

                    send();

                }).Start();





            }




            catch { }









        }
        static string Type;
        NSTimer Timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(0.1), delegate {
        
            for (int i=0; i< _QueueList.Count; i++) { 
            
            if(_QueueList[i].Progress==100|| !_QueueList[i].Running)
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
                    Save_Data(_QueueList[i]);

                    File.Delete(_QueueList[i].Filename);

                    _QueueList.RemoveAt(i);
                }






            }
        
        
        
        
        
        
        });




        private static void Save_Data(queue Finsh_queue) {


            DataSql _DataSql = new DataSql();
            UIImage image;
            LibraryWords library = new LibraryWords();



            var myByteArray = File.ReadAllBytes(Finsh_queue.Filename);

            byte[] myByteThumbnail = null;


            if ( Finsh_queue._Type == "Video")
            {



                //// byte[] myByteArray;
                CoreMedia.CMTime actualTime;
                NSError outError;
                using (var asset = AVAsset.FromUrl(NSUrl.FromFilename (Finsh_queue.Filename)))
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
            }
            else { myByteThumbnail = myByteArray; }


            _DataSql.process(library.File(2), library.INSERT(2), DataSql_Parameters(   Path.GetFileName ( Finsh_queue.Filename) , myByteArray, myByteThumbnail, Finsh_queue._Type)); }

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
          if(queue.Type == QueueType.Download)
             _QueueList.Add(queue);
            _Tranferclint.StartTransfer(queue);
        }

        private void send()
        {
            new Thread(() =>
            {
                //  Thread.Sleep(1000);

                _receive.SendSocket(json_list);

            }).Start();



          








        }
        private void ConverToJson() {
            local _local = new local();
            List<string> namefiles = _local.retDataString(0, 1);

            List<string> typefiles = _local.retDataString(3, 1);

            int i = 0;
            
            
            while ( i< namefiles.Count) {
                js _js = new js { NameFile = namefiles[i], Type = typefiles[i] };

                json_list.Add(_js);

                i++;
                    
                    
                    
                    }
       
        
        
        
        }






        private void _receive_Diconncet(receive sender, byte[] data)
        {
            isconnct = false;
            if (Diconncet != null) Diconncet("conncet");
        }

        private void _receive_Receive(receive sender, byte[] data)
        {
            throw new NotImplementedException();
        }

        public void stop (){

            isconnct = false;
            try
            {
                connect.close();
                _Tranferclint.Close();

            }
            catch { }


        }







    }
}