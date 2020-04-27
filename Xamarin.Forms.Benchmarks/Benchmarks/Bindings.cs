using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Xamarin.Forms.Benchmarks
{
	class BindingData
	{
		public string Text { get; set; }
	}

	[Orderer (SummaryOrderPolicy.FastestToSlowest)]
	public class Bindings
	{
		[Benchmark]
		public void ByHand ()
		{
			var label = new Label {
				BindingContext = new BindingData {
					Text = "Foo"
				}
			};
			var binding = new Binding ("Text");
			label.SetBinding (Label.TextProperty, binding);
		}

		[Benchmark]
		public void XamlC ()
		{
			var label = new BindingLabel {
				BindingContext = new BindingData {
					Text = "Foo"
				}
			};
		}

		[Benchmark]
		public void Typed ()
		{
			var label = new TypedBindingLabel {
				BindingContext = new BindingData {
					Text = "Foo"
				}
			};
		}
	}
}