using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using Network_App;
using UIKit;
using System.Timers;
namespace NetworkApp
{

    class Clickbuttonconnct
    {

        information _information;
        string IP;
        int Port;
        LibraryWords library = new LibraryWords();

        UITableViewCell cell; bool m = false;
        UITableViewRowAction conncatbutton;
        public Clickbuttonconnct(string ip, int port )
        {
          
            IP = ip; Port = port;
             conncatbutton = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, library.StrForm(1), click_connact);

            conncatbutton.BackgroundColor = UIColor.Blue;
           
            NSTimer xtimer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(0.1), delegate {
                if (m)
                {
                    m = false;
                    conncatbutton.BackgroundColor = UIColor.Blue;
                    _information.stop();
                    conncatbutton.Title = library.StrForm(1);
                }
                else
                {



                    //  click_connact(conncatbutton, null);
                   // cell.BackgroundColor = UIColor.Gray;

                }
            });
            }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //if (m) { cell.BackgroundColor = UIColor.Red; }
            //else {

              

            //    //  click_connact(conncatbutton, null);


            //}
        }

        private void click_connact(UITableViewRowAction row, NSIndexPath indexPath) // Action  Connect button
        {
            if (!information.isconnct)
            {
                //  cell.BackgroundColor = UIColor.Red;
              
                _information = new information();
                _information.connet(IP, Port);
                _information.Diconncet += _information_Diconncet; ;
                conncatbutton.Title = "diSconncet";

                conncatbutton.BackgroundColor = UIColor.Gray;
                // Connect connect = new Connect("",9);
            }

            else
            {
                m = false;
                conncatbutton.BackgroundColor = UIColor.Blue;
                _information.stop();
                conncatbutton.Title = library.StrForm(1);

               


            }
        }

        private void _information_Diconncet(string data)
        {
            _information.stop();
            // click_connact(conncatbutton, null);
            m = true;

            //  new Thread(() => { conncatbutton.BackgroundColor = UIColor.Black; }).Start();
            //conncatbutton.BackgroundColor = UIColor.Black;
            //  var x = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, library.StrForm(1), click_connact);
            //throw new NotImplementedException();
        }

        public UITableViewRowAction retrun_button()
        {
            return conncatbutton;
        }
    }
}