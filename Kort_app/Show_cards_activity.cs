using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
namespace Kort_app
{
    [Activity(Label = "Show_cards_activity")]
    public class Show_cards_activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.show_cards);
            // Create your application here
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}