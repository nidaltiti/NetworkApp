using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace  NetworkApp

{
    class Listen
        
    {
        Socket _socket;
        public bool listenring
        { 
            get;

            private set;
                
                
                }
        public int Port
        {
            get;

            private set;

        }
        public Listen(int port) {

            Port = port;

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public void Start() {
            if (listenring) return;
            IPEndPoint localtion = new IPEndPoint(IPAddress.Any, Port);
            _socket.Bind(localtion);
            _socket.Listen(0);
            _socket.BeginAccept(Callback, null);

             listenring = true;

        }
        public void Stop() { if (!listenring) 
                return;

            _socket.Close();
            _socket.Dispose();

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }
        void Callback (IAsyncResult ar)
        {
            try {


                Socket _socketAcc = _socket.EndAccept(ar);

                if(socketAccpete != null) { socketAccpete(_socketAcc); }
                _socket.BeginAccept(Callback, null);




            }
            catch { }
        
        
        
        
        
        }
        public delegate void SocketAccpetedHandler(Socket e);
        public event SocketAccpetedHandler socketAccpete;
    }

}
