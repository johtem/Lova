using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LOVA.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Dependency(typeof(LOVA.Droid.Statusbar))]
namespace LOVA.Droid
{

    public class Statusbar : IStatusBarPlatformSpecific
    {

        public Statusbar()
        {

        }

        public void SetStatusBarColor(Color color)
        {
            // The SetStatusBarcolor is new since API 21
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.ToAndroid(); //.AddLuminosity(-0.1).ToAndroid();
                //Use the plugin
                CrossCurrentActivity.Current.Activity.Window.SetStatusBarColor(androidColor);
            }
            else
            {
                // Here you will just have to set your color in styles.xml file as above.
            }
        }
    }
}