using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Xamarin.Forms.Benchmarks
{
	class BindingData
	{
		public string Text { get; set; }
	}

	[MemoryDiagnoser]
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
