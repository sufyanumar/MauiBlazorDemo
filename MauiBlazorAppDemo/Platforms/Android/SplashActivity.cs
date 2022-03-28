using Android.App;
using Android.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorAppDemo.Platforms.Android
{
    [Activity(Label = "Apex Connect", Theme = "@style/Theme.Splash", MainLauncher = false, NoHistory = true)]
    public partial class SplashActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
        }
    }
}
