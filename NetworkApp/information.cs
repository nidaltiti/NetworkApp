using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Foundation;
using Network_App;
using Newtonsoft.Json;
using UIKit;


namespace NetworkApp
{
    class information
    {
        public static bool isconnct = false;

        Connect connect;
        receive _receive;
        Connect tansconnet;
        Tranferclint _Tranferclint = new Tranferclint();
        //    receive _receive;
        // Socket sck;
        
        public delegate void SeverDiconncet(String data);

        List<js> json_list = new List<js>();
        

        public event SeverDiconncet Diconncet;
        public void connet(string Address, int port) {

            try { isconnct = true;


                new Thread(() => {

                    Thread.Sleep(500);
                    tansconnet = new Connect(Address,port);
                  
                    connect = new Connect(Address, --port);


                      _receive = new receive(connect.rentun_Socket());

                    _receive.Receive += _receive_Receive;

                    _receive.Diconncet += _receive_Diconncet;
                    _Tranferclint.Connect(tansconnet.rentun_Socket());
                  //   sck = _receive.retun_socket();
                    ConverToJson();

                    send();

                }).Start();
                 




            } 
            
            
            
            
            catch { }
        
        
        
        
        
        
        
        
        
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

            List<string> typefiles = _local.retDataString(2, 1);

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

            }
            catch { }


        }







    }
}