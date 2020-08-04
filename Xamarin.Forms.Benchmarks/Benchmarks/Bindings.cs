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
	[WarmupCount (10), IterationCount (10), InvocationCount (10)] // NOTE: I needed to cap the iterations, as BDN was going on and on
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
		public void ByHandOneTime ()
		{
			var label = new Label ();
			var binding = new Binding ("Text", BindingMode.OneTime);
			label.SetBinding (Label.TextProperty, binding);
			label.BindingContext = bindingContext;
		}

		[Benchmark]
		public void Regular ()
		{
			var label = new BindingLabel {
				BindingContext = bindingContext,
			};
		}

		[Benchmark]
		public void RegularOneTime ()
		{
			var label = new BindingLabelOneTime {
				BindingContext = bindingContext,
			};
		}

		[Benchmark]
		public void Typed ()
		{
			var label = new TypedBindingLabel {
				BindingContext = bindingContext,
			};
		}

		[Benchmark]
		public void TypedOneTime ()
		{
			var label = new TypedBindingLabelOneTime {
				BindingContext = bindingContext,
			};
		}
	}
}
