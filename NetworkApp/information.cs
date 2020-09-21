using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using Network_App;
using UIKit;

namespace NetworkApp
{
    class information
    {
        public static bool isconnct = false;

        Connect connect;

        Connect tansconnet;
        Tranferclint _Tranferclint = new Tranferclint();
        public delegate void SeverDiconncet(String data);


        

        public event SeverDiconncet Diconncet;
        public void connet(string Address, int port) {

            try { isconnct = true;


                new Thread(() => {

                    Thread.Sleep(500);
                    tansconnet = new Connect(Address,port);
                  
                    connect = new Connect(Address, --port);

                   
                    receive _receive = new receive(connect.rentun_Socket());

                    _receive.Receive += _receive_Receive;

                    _receive.Diconncet += _receive_Diconncet;
                    _Tranferclint.Connect(tansconnet.rentun_Socket());




                }).Start();
                 




            } 
            
            
            
            
            catch { }
        
        
        
        
        
        
        
        
        
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

            }
            catch { }


        }







    }
}