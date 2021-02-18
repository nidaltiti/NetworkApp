using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Network_App
{
    class Message:LibraryWords 
    {

        string[] message= { " Galleryfly-Win Ip", };
        string[] erorMessages = { "is not number" };
        public string Messages(int number) {


            

            return message[number];  }

       public string ErorMessages(int number) { return erorMessages[number]; }


        public UIFont Font() {

            UIFont uIFont=  UIFont.FromName("Helvetica-Bold", 25f);

            // "Helvetica-Bold", 25f;
            return uIFont;

        }


    }
}