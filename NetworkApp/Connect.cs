using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Network;
using Foundation;
using UIKit;
using System.Net.Sockets;
using System.Net;

namespace NetworkApp
{
    class Connect
    {
        Socket  socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Connect(string Address,int port) {


            try
            {

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress _iPAddress = IPAddress.Parse(Address);

                socket.Connect(_iPAddress, port);


            }
            catch { socket.Close();
            }

        }
        public Socket rentun_Socket () { return socket;  }
        public void close() {
            //
            //socket.Shutdown(SocketShutdown.Both);

            

           // socket = null;
           // socket.Shutdown(SocketShutdown.Both);

           socket.Close();

            //socket.Shutdown(SocketShutdown.Both);
          //  socket.Dispose();
            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



        }
    }


    


}