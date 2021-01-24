using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Xamarin.Essentials;
using Foundation;
using UIKit;

namespace NetworkApp
{
    class js
    {
        // public int id { get; set; }
        public string NameFile { get; set; }
        public string Type { get; set; }
        //  public byte[] ImageToBytes { get; set; }
        public bool Auto{ get; set; }
    }

    class ListSQL
    {
        // public int id { get; set; }
        public List <string >NameFile { get; set; }
        public List<string> Type { get; set; }
        public List <byte[]> ImageToBytes { get; set; }

    }
    class  save_Plus {

        public string Title { get; set; }
        public string Url { get; set; }
        public UIImage Image { get; set; }
        public UIImage Thumbnail { get; set; }
        public byte[] ImageToBytes { get; set; }
        public byte[] ThumbnailToBytes { get; set; }
        public string Extension { get; set ; }

    }

  //  public static bool Autosave = false;
  class save
    {
       

      public  static    bool Savegerlly {

                get => Preferences.Get("saveAuto", false);

                set { Preferences.Set("saveAuto", value); }


            }


            //  public static bool Autosave;








        }

}