using Android.Content;
using Xamarin.Forms;
using AView = Android.Views.View;

[assembly: Dependency (typeof (Xamarin.Forms.Benchmarks.Droid.NativeViewRenderer))]

namespace Xamarin.Forms.Benchmarks.Droid
{
	class NativeViewRenderer : INativeViewRenderer
	{
		readonly Context context = global::Android.App.Application.Context;

		public object CreateNativeView (View view)
		{
			var native = (AView) Platform.Android.Platform.CreateRendererWithContext (view, context);
			native.Layout (0, 0, 100, 100);
			return native;
		}
	}
}
