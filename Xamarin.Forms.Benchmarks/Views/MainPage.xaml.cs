using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Benchmarks
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		async void Button_Clicked (object sender, EventArgs e)
		{
			SetIsRunning (true);
			try {
				var logger = new ActionLogger (SetSummary);
				var summary = await Task.Run (() => BenchmarkRunner.Run<Layouts> (DefaultConfig.Instance.AddLogger (logger)));
				ConclusionHelper.Print (logger,
					summary.BenchmarksCases
						.SelectMany (benchmark => benchmark.Config.GetCompositeAnalyser ().Analyse (summary))
						.Distinct ()
						.ToList ());
			} catch (Exception exc) {
				SetSummary ("Unhandled exception: " + exc);
			} finally {
				SetIsRunning (false);
			}
		}

		void SetIsRunning (bool isRunning)
		{
			Indicator.IsRunning = isRunning;
			Run.IsVisible = !isRunning;
			if (isRunning) {
				Summary.Text = "";
			}
			ResizeSummary ();
		}

		/// <summary>
		/// NOTE: called from background thread
		/// </summary>
		void SetSummary (string text)
		{
			Device.BeginInvokeOnMainThread (() => {
				Summary.Text = text;
				ResizeSummary ();
			});
		}

		void ResizeSummary ()
		{
			Summary.WidthRequest = Summary.HeightRequest = -1;
			var size = Summary.Measure (double.MaxValue, double.MaxValue).Request;
			Summary.WidthRequest = size.Width;
			Summary.HeightRequest = size.Height;
			Scroller.ScrollToAsync (0, size.Height, false);
		}

		class ActionLogger : ILogger
		{
			readonly StringBuilder builder = new StringBuilder ();
			readonly Action<string> callback;

			public ActionLogger (Action<string> callback)
			{
				this.callback = callback;
			}

			public string Id => nameof (ActionLogger);

			public int Priority => 0;

			public void Flush () => callback (builder.ToString ());

			public void Write (LogKind logKind, string text) => builder.Append (text);

			public void WriteLine ()
			{
				builder.AppendLine ();
				Flush ();
			}

			public void WriteLine (LogKind logKind, string text)
			{
				builder.AppendLine (text);
				Flush ();
			}
		}
	}
}
