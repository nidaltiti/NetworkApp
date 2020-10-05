using System;
using System.Net.Sockets;
using System.Net;
using UIKit;
using CoreGraphics;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using Foundation;
using System.Collections.Generic;
using System.Data;


using System.ComponentModel;

namespace Network_App
{
  
    public partial class ViewController : UIViewController
    {
        public static ViewController _ViewController;
        Message library = new Message();
        //UITextField field =  new UITextField;
        //UITextField field2 = null;
       

     //   public static string titile;
        //public static string GetEnumDescription( Enum value)

        //{

        //    var enumType = value.GetType();

        //    var field = enumType.GetField(value.ToString());

        //    var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //    return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;


        //    // list enum  
        //}
        List<string> listdns = new List<string>();
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        Socket s;
       
        public override void ViewDidLoad()
        {
            _ViewController = this;
            Titile();
            DataSql dataSql = new DataSql();


           dataSql.fileSql(library.File(2));// ceart data file
          //  DataSql.data.Clear();
            Nettab.bar.plusbutton += Btn_Clicked;

            base.ViewDidLoad();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Perform any additional setup after loading the view, typically from a nib.


            local _local = new local();
            listdns = _local.retDataString(0, 0);
            List <int>listPort= _local.Retdatainger(1, 0);


            //dataSql.process(library.File(2),library.SELECT(0), null);
            // listdns = DataSql.data;
            this.tabview.Source = new sourc(_local.retDataString(0, 0), _local.Retdatainger(1, 0), tabview);// sends to source



        }
        string txt=string.Empty;
        string txtport = string.Empty;

        private void Btn_Clicked(object sender, int d)
        {
            UITextField field = new UITextField ();
            UITextField field2 = new UITextField();
            if (d == 0)
            {
                //throw new NotImplementedException();
                var messbox = UIAlertController.Create(library.Messages(0), string.Empty, UIAlertControllerStyle.Alert);
                messbox.View.BackgroundColor = UIColor.White;
             //   UITextField field = null;
               // UITextField field2 = null;
                messbox.AddTextField((textField1) =>
                {
                    field = textField1;
                    //field.Text = "5564";
                  //  field.Text = "";
                    // Initialize field
                    //  field.Placeholder = placeholder;
                    field.Placeholder = library.Messages(0);
                
                    // field.BackgroundColor = UIColor.Yellow;
                    //    field.Layer.BorderColor = UIColor.Gray.CGColor;

                    field.Font = library.Font();

                    field.Layer.BorderWidth = 1;
                    //   field.Layer.CornerRadius = 20;
                    //  field = new UITextField(new CoreGraphics.CGRect(10, 60, 300, 60));
                    //  field.SecureTextEntry = true;
                });
                var frame = new CGRect(40, 40, 300, 60);
                messbox.AddTextField((text) =>
                {
                    field2 = text;
                    txtport = text.Text;
                    field2.Frame = frame;
                   // field2.Placeholder = "100";
                    // field2.KeyboardType = UIKeyboardType.Default;
                    //  field2 = new UITextField(new CoreGraphics.CGRect(10, 40, 30, 10));
                    //   field2.Layer.BackgroundColor = UIColor.Red.CGColor;
                    field2.Layer.BorderWidth = 1;
                    field2.Font = library.Font();

                    field2.Text = 2321.ToString();

                    // field.Layer.CornerRadius = 40;
                    //  field2.SecureTextEntry = true;
                });
                //Add Actions
                var cancelAction = UIAlertAction.Create(library.StrForm(4), UIAlertActionStyle.Cancel, alertAction => { });
                var okayAction = UIAlertAction.Create(library.StrForm(3), UIAlertActionStyle.Default, alertAction => {

                    int j;
                    if (Int32.TryParse(field2.Text, out j))
                    {
                        txt = field.Text;
                        txtport = field2.Text;
                        //  field.Text = txt;
                        DataSql dataSql = new DataSql();
                        dataSql.process(library.File(2), library.INSERT(1 ), DataSql_Parameters());
                        //listdns.Add(field.Text);
Sourcetabview();
                    }

                    else { var armAlert = UIAlertController.Create(library.ErorMessages(0), string.Empty, UIAlertControllerStyle.Alert);
                        var cancelAction1 = UIAlertAction.Create(library.StrForm(3), UIAlertActionStyle.Cancel, alertAction1 => { });

                        armAlert.AddAction(cancelAction1);


                        PresentViewController(armAlert, true, null);


                    }
                        
                    
                  
                    //  tabview.InsertRows(new NSIndexPath[] {  }, UITableViewRowAnimation.Fade);

                    
                      
                });

                messbox.AddAction(cancelAction);
                messbox.AddAction(okayAction);

                //Present Alert
                PresentViewController(messbox, true, null);


            }

        }
      private void Sourcetabview() {

            //   dataSql.Rowdata(0);
            //   dataSql.process("ip.db3", GetEnumDescription(textcommad.SELECT),null);
            //  listdns.Clear();



            


            local _local = new local();


            this.tabview.Source = new sourc(_local.retDataString(0, 0), _local.Retdatainger(1, 0), tabview);
            using (var indexPath = NSIndexPath.FromRowSection(0, 0))
                tabview.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);

        }
    

        private SqliteParameterCollection DataSql_Parameters()
        {
            SqliteCommand SqliteCommand = new SqliteCommand();
            SqliteParameterCollection ReturnParamter= SqliteCommand.Parameters  ;

            ReturnParamter.AddWithValue(LibraryWords.Row+0.ToString(),txt);

            ReturnParamter.AddWithValue(LibraryWords.Row + 1.ToString(), txtport);


            return ReturnParamter;

        }
         public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        
       public  void Titile() {

            this.Title = library.Tabs(0);
          

        }
       


    }
   
}