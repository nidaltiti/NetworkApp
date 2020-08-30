using Foundation;
using NetworkApp;
using System;
using UIKit;

namespace Network_App
{
    public partial class Nettab : UITabBarController
    {
        LibraryWords library = new LibraryWords();
        bool trueclick = false;
        int shwich=0;
        UIBarButtonItem Secbutton = new UIBarButtonItem();
        UIBarButtonItem sendbutton = new UIBarButtonItem();
        public Nettab(IntPtr handle) : base(handle)
        {
        }

        public delegate void sender(object sender);
        public event sender Ssender;
        public delegate void secletion(object sender);
        public event secletion selectboutton;
        public delegate void clickbuttonright(object sender,int d);
        public event clickbuttonright plusbutton;
        public static Nettab bar;
       
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

         //   this.NavigationItem.SetHidesBackButton(true, false);

        


          //  this.NavigationItem.LeftBarButtonItem = Secbutton;

        }
        public override void LoadView()
        {
           /// buttn.TouchUpOutside += Buttn_TouchUpOutside;

            bar = this;

            Secbutton.Title = "Select";

            Secbutton.Clicked += Secbutton_Clicked;
            sendbutton.Clicked += Sendbutton_Clicked;
        NavigationItem.SetLeftBarButtonItem(null, true);


            for (int i=0;i < tabconrol.Items.Length; i++)
            tabconrol.Items[i].Title = library.Tabs(i);
          
           

            //  hidbutton(true);
            base.LoadView();
            this.ViewControllerSelected += (sender, e) => {
                // Take action based on the tab being selected
                //   NavigationItem.LeftBarButtonItem = btn;

               
                if (TabBar.SelectedItem.Title== library.Tabs(0)) {
                  
                    DataSql.data.Clear();
                    ViewController._ViewController.ViewDidLoad();
                    title(library.Tabs(0));
                    shwich =0;
                //    sendbutton.Enabled = false;
                  //  NavigationItem.SetLeftBarButtonItem(null, true);
                    //   NavigationItem.SetLeftBarButtonItem(null, true);
                    // NavigationItem.SetLeftBarButtonItems()
                 //   this.NavigationItem.LeftBarButtonItems = null;
                    img.imG.is_Select();
                 //   img.imG.ViewDidLoad();
                    changebuttonclick();
                    this.NavigationItem.LeftBarButtonItems = null;
                }



                if (TabBar.SelectedItem.Title == library.Tabs(1))
                {
                  
                   // img.imG.ViewDidLoad();
                    title(library.Tabs(1));
                    //
                    shwich =1;

                   // Change(Secbutton, true);
                    this.NavigationItem.SetLeftBarButtonItem(Secbutton, true);
                    Secbutton.Title = "Select";


                }


              

          
            };
        }
        /// <summary>
        /// 
        /// </summary>
        
        private void Sendbutton_Clicked(object sender, EventArgs e)
        {
            if (Ssender != null)
            {
                Ssender(sender);
                // throw new NotImplementedException();
            }

        }
        /// <summary>
        /// end Send button Clicke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Secbutton_Clicked(object sender, EventArgs e)
        {
            if (selectboutton != null)
            {
                selectboutton(sender);
                // throw new NotImplementedException();
            }
        }
      
        private void Buttn_TouchUpOutside(object sender, EventArgs e)
        {
           

        }

        public void title (string title) { this.Title = title; }

        partial void Buttn_TouchUpInside(UIButton sender)
        {
            if (plusbutton != null)
            {
                plusbutton(sender, shwich);
               // throw new NotImplementedException();
            }
        }



        public void Change(bool en) {



            Secbutton.Enabled = en;
        }

        public void Addtowbuton() {

            Secbutton.Title = "Cancel";
            sendbutton.Title = "Share";
             this.NavigationItem.SetLeftBarButtonItem(null, true);

            UIBarButtonItem[] listithem=  { Secbutton, sendbutton };


            this.NavigationItem.LeftBarButtonItems = listithem;
        }
        public void changebuttonclick() // change selectbutton 
        {



            if (Secbutton.Title == "Cancel")
            {
                this.NavigationItem.SetLeftBarButtonItem(null, true);

                this.NavigationItem.SetLeftBarButtonItem(Secbutton, true);


                Secbutton.Title = "Select";




            
            }


            else { Secbutton.Title = "Cancel";


                Secbutton.Title = "Cancel";
                sendbutton.Title = "chooice";
                this.NavigationItem.SetLeftBarButtonItem(null, true);

                UIBarButtonItem[] listithem = { Secbutton, sendbutton };
              
                this.NavigationItem.LeftBarButtonItems = listithem;





            }

        }

    }
   
}