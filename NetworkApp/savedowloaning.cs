using AssetsLibrary;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;

namespace NetworkApp
{
    class savedowloaning
    { public void Get_clipfile(string nameFile, byte[] filebyet)
        {
            new Thread(() =>
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename = nameFile+".mov"; //same if I save the file as .mp4
                var localPath = Path.Combine(documentsPath, localFilename);

                File.WriteAllBytes(localPath, filebyet);
                ALAssetsLibrary lib = new ALAssetsLibrary();
                lib.WriteVideoToSavedPhotosAlbum(NSUrl.FromFilename(localPath), (t, u) => { });
                Thread.Sleep(1000);
                File.Delete(localPath);
                if (File.Exists(localPath)) ;
                else { };

            }).Start();
           


          
        
        }
        public void Get_imagefile(string nameFile, byte[] _ui) {

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string localFilename = nameFile + ".jpg"; //same if I save the file as .jpg
            var localPath = Path.Combine(documentsPath, localFilename);

            File.WriteAllBytes(localPath, _ui);


            var someImage = UIImage.FromFile(localPath);
          
              
              //  UIImage someImage = _ui;
                someImage.SaveToPhotosAlbum((UIImage, error) =>
                {
                    var o = UIImage as UIImage;

                    Console.WriteLine("error:" + error);
                });


            new Thread(() => { 
            
                Thread.Sleep(2000);
                File.Delete(localPath);
            }).Start();

            //




        }
    }
}