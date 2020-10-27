using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

using Foundation;
using UIKit;

namespace NetworkApp
{
    class js
    {
       // public int id { get; set; }
        public string NameFile { get; set; }
        public string Type { get; set; }
    }


    class  save_Plus {

        public string Title { get; set; }
        public string Url { get; set; }
        public UIImage Image { get; set; }
        public UIImage Thumbnail { get; set; }
        public byte[] ImageToBytes { get; set; }
        public byte[] ThumbnailToBytes { get; set; }
        public string Extension { get; set; }

    }




}