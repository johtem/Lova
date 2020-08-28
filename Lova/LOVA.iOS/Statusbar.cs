using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LOVA.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: Dependency(typeof(LOVA.iOS.Statusbar))]
namespace LOVA.iOS
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public Statusbar()
        {
        }

        public void SetStatusBarColor(Color color)
        {
            //UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBarManager")) as UIView;
            //if (statusBar != null && statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            //{
            //    statusBar.BackgroundColor = color.ToUIColor();
            //}


            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                //Obj-C: 
                // UIView *statusBar = [[UIView alloc]initWithFrame:[UIApplication sharedApplication].keyWindow.windowScene.statusBarManager.statusBarFrame] ;
                // statusBar.backgroundColor = [UIColor redColor];
                // [[UIApplication sharedApplication].keyWindow addSubview:statusBar];

                // Xamarin.iOS: 

                //UIView statusBar = UIDevice.CurrentDevice.CheckSystemVersion(13, 0) ? new UIView(UIApplication.SharedApplication.StatusBarFrame) : UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;

                ////var apa = UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame;


                //UIView statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame);
                //statusBar.BackgroundColor = UIColor.Red;
                //UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);



            }
            else
            {
                UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = UIColor.Red;
                    statusBar.TintColor = UIColor.White;
                    UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
                }
            }
        }
    }
}