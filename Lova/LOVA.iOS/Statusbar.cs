using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LOVA.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace LOVA.iOS
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public Statusbar()
        {
        }

        public void SetStatusBarColor(Color color)
        {
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(
            new NSString("statusBar")) as UIView;
            if (statusBar != null && statusBar.RespondsToSelector(
            new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = color.ToUIColor();
            }
        }
    }
}