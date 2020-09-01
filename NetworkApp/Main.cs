using System;
using UIKit;

namespace Network_App
{
    public class Application
    {
        static public Random Rand;


        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            Rand = new Random();

            UIApplication.Main(args, null, "AppDelegate");
           
        }
    }
}