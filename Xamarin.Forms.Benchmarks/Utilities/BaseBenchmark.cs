using System.Runtime.InteropServices;
using Xamarin.Forms.Mocks;

namespace Xamarin.Forms.Benchmarks
{
	public class BaseBenchmark
	{
		/// <summary>
		/// NOTE: using this over DependencyService, because BDN runs stuff out of proc in a custom way.
		/// </summary>
		public static INativeViewRenderer Renderer = new DefaultNativeViewRenderer ();

		static BaseBenchmark ()
		{
			// NOTE: This check wouldn't be right for desktop Xamarin.Forms apps.
			// This project runs benchmarks in a Console app.
			if (RuntimeInformation.IsOSPlatform (OSPlatform.Windows) || RuntimeInformation.IsOSPlatform (OSPlatform.OSX))
				MockForms.Init ();
		}
	}
}
