using AssetsLibrary;
using AVFoundation;
using AVKit;
using CoreMedia;
using Foundation;
using Network_App;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;

namespace NetworkApp
{

    public partial class AMvideo : AVPlayerViewController
    {
        string namefile, local;
        AVAsset avasset;
        AVPlayerItem avplayerItem;
        AVPlayer avplayer;
        byte[] _videobyte;
        public AMvideo(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            UIBarButtonItem actionbutton = new UIBarButtonItem();
            actionbutton.Title = "-->";
            actionbutton.Clicked += Actionbutton_Clicked;
            this.NavigationItem.SetRightBarButtonItem(actionbutton, true);

            base.ViewDidLoad();
        }

        private void Actionbutton_Clicked(object sender, EventArgs e)
        {
            this.Player.Pause();
            var alert = UIAlertController.Create("", "", UIAlertControllerStyle.ActionSheet);
            alert.AddAction((UIAlertAction.Create("Save Video", UIAlertActionStyle.Default, async (UIAlertAction obj) =>
            {


                 SaveToAlbum(local, "nidal", namefile);





            })));
            alert.AddAction((UIAlertAction.Create("Share", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {

                var ii = NSUrl.FromFilename(local);

                var imageToShare = ii.Copy();
                var activityItems = new NSObject[] { imageToShare };

                var controller = new UIActivityViewController(activityItems, null);




                this.PresentViewController(controller, true, null);
            })));
            alert.AddAction((UIAlertAction.Create("Delete", UIAlertActionStyle.Destructive, (UIAlertAction obj) => {
                try
                {
                    local cal = new local();
                    //    Images mig =new Images ()
                    cal.remove(this.Title);
                    img.imG.ViewDidLoad();
                }
                catch
                {
                    var armAlert = UIAlertController.Create("database dot open", string.Empty, UIAlertControllerStyle.Alert);
                    var cancelAction1 = UIAlertAction.Create("ok", UIAlertActionStyle.Cancel, alertAction1 => { });

                    armAlert.AddAction(cancelAction1);


                    PresentViewController(armAlert, true, null);
                }

                NavigationController.PopViewController(true);


            })));
            alert.AddAction((UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (UIAlertAction obj) => { })));

            this.PresentViewController(alert, true, null);

        }



        public override void LoadView()
        {


            base.LoadView();
        }
        public void file(string localfile, string Title,byte[] _byet)
        {
            _videobyte = _byet;

            this.Title = namefile = Title;
           
            local = localfile;

            avasset = AVAsset.FromUrl(NSUrl.FromFilename(localfile));
            var avplayerItem = new AVPlayerItem(avasset);
            var avplayer = new AVPlayer(avplayerItem);
            avplayer.Play();
            this.Player = avplayer;
            // this.ShowsPlaybackControls = true;

            CoreMedia.CMTime m = avplayer.CurrentTime;
            CMTime duration = avplayerItem.Duration; //total time
            CMTime currentTime = avplayerItem.CurrentTime; //playing time

            // this.Title =   avasset.Tracks..ToString();


            avplayer.Play();


        }
   public    void  creat( byte[] g)
        {
            
        }
       void  SaveToAlbum(string video_url, string directory, string filename)
        {
           
           
                byte[] data = _videobyte;
           
                try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename =  "text.mov"; //same if I save the file as .mp4
            var    localPath = Path.Combine(documentsPath, localFilename);

                File.WriteAllBytes(localPath, data);
                ALAssetsLibrary lib = new ALAssetsLibrary();
                    lib.WriteVideoToSavedPhotosAlbum(NSUrl.FromFilename(localPath), (t, u) => { });
             
            }
                catch (Exception ex)
                {

                }
           
                  
            }
        }
    }
