using System;

using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Xamarin.Forms.Benchmarks.Droid
{
	[Activity (Label = "Forms Benchmarks", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate (savedInstanceState);

			BaseBenchmark.Renderer = new NativeViewRenderer ();
			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			LoadApplication (new App ());
		}
	}
}
