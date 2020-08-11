using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Xamarin.Forms.Benchmarks
{
	class BindingData : INotifyPropertyChanged
	{
		string text;

		public string Text {
			get => text;
			set {
				text = value;
				PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (nameof (Text)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	[MemoryDiagnoser]
	[WarmupCount (100), IterationCount (100), InvocationCount (100)] // NOTE: I needed to cap the iterations, as BDN was going on and on
	[Orderer (SummaryOrderPolicy.FastestToSlowest)]
	public class Bindings : BaseBenchmark
	{
		BindingData bindingContext = new BindingData {
			Text = "Foo"
		};

		[Benchmark]
		public void ByHand ()
		{
			var label = new Label ();
			var binding = new Binding ("Text");
			label.SetBinding (Label.TextProperty, binding);
			label.BindingContext = bindingContext;
		}

		[Benchmark]
		public void Regular ()
		{
			var label = new BindingLabel (false) {
				BindingContext = bindingContext,
			};
		}

		[Benchmark]
		public void Regular2 ()
		{
			var label = new BindingLabel (true) {
				BindingContext = bindingContext,
			};
		}
	}
}
