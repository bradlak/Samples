using System;
using LocalizationTest.Resources;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using System.Globalization;

namespace LocalizationTest.Droid
{
	[Activity (Label = "LocalizationTest", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private TextView crossTextView;

        private TextView nativeTextView;

        private TextsProvider provider;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

            provider = new TextsProvider();

            crossTextView = FindViewById<TextView> (Resource.Id.textCross);
            nativeTextView = FindViewById<TextView>(Resource.Id.textNative);

            crossTextView.Text = provider.GetText("Hello");
            nativeTextView.Text = Resources.GetString(Resource.String.Hello);
        }

        private void SetCulture(string cultureKey)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureKey);
        }
	}
}


