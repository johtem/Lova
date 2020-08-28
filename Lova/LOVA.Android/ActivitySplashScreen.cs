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

namespace LOVA.Droid
{
    [Activity(Label = "ActivitySplashScreen", MainLauncher =true)]
    public class ActivitySplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // pass design here
            SetContentView(Resource.Layout.layoutSplashDesign);

            // code to delay splash screen

            Handler h = new Handler();
            h.PostDelayed(new System.Action(() =>
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }), 5000);
        }
    }
}