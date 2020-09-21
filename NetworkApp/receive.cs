using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Text;

namespace Network_App
{
    class receive
    {
        Socket sck;
        public  receive(Socket s)
        {
            sck = s;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }

        void callback(IAsyncResult ar)
        {
            byte[] buf=null;
            try
            {

                sck.EndReceive(ar);
                buf = new byte[8192];
                int rec = sck.Receive(buf, buf.Length, 0);
                if (rec < buf.Length)
                {

                    Array.Resize<byte>(ref buf, rec);

                    if (Receive != null)
                    {

                        Receive(this, buf);

                    }

                }
               
                   
                    sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);

                   
                           }
            catch
            {
                if (Diconncet != null)
                {

                    Diconncet(this, buf);

                }
            }

        }




        public delegate void cilentReviceHandler(receive sender, byte[] data);




        public event cilentReviceHandler Receive;

        public delegate void SeverDiconncet(receive sender, byte[] data);




        public event SeverDiconncet Diconncet;
    }

}

