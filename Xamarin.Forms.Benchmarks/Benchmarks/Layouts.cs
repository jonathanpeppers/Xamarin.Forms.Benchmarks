using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Xamarin.Forms.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer (SummaryOrderPolicy.FastestToSlowest)]
	public class Layouts : BaseBenchmark
	{
		const int ViewCount = 100;
		const int ViewSize = 10;
		static readonly Thickness Empty = new Thickness (0);
		static BoxView [] Views;

		[GlobalSetup]
		public void GlobalSetup()
		{
			Views = new BoxView [ViewCount];
			for (int i = 0; i < Views.Length; i++) {
				Views [i] = new BoxView {
					WidthRequest = ViewSize,
					HeightRequest = ViewSize,
				};
			}
		}

		[IterationCleanup]
		public void Cleanup ()
		{
			foreach (var view in Views) {
				view.Parent = null;
			}
		}

		[Benchmark]
		public void StacksOfStacks ()
		{
			var verticalStack = new StackLayout {
				Padding = Empty,
				Spacing = 0,
				Orientation = StackOrientation.Vertical,
			};
			var horizontalStack = default (StackLayout);
			for (int i = 0; i < Views.Length; i++) {
				if (i % ViewSize == 0) {
					verticalStack.Children.Add (horizontalStack = new StackLayout {
						Padding = Empty,
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
					});
				}
				horizontalStack.Children.Add (Views [i]);
			}
			Renderer.CreateNativeView (verticalStack);
		}

		[Benchmark]
		public void GridWithRowsAndColumns ()
		{
			var grid = new Grid {
				Padding = Empty,
				ColumnSpacing = 0,
				RowSpacing = 0,
			};
			for (int i = 0; i < ViewSize; i++) {
				grid.ColumnDefinitions.Add (new ColumnDefinition { Width = GridLength.Auto });
				grid.RowDefinitions.Add (new RowDefinition { Height = GridLength.Auto });
			}
			for (int i = 0; i < Views.Length; i++) {
				var view = Views [i];
				Grid.SetColumn (view, i / ViewSize);
				Grid.SetRow (view, i % ViewSize);
				grid.Children.Add (view);
			}
			Renderer.CreateNativeView (grid);
		}

		[Benchmark]
		public void AbsoluteLayoutWithMath ()
		{
			var layout = new AbsoluteLayout {
				Padding = Empty,
				WidthRequest = ViewSize * ViewSize,
				HeightRequest = ViewSize * ViewSize,
			};
			var rect = new Rectangle (0, 0, ViewSize, ViewSize);
			for (int i = 0; i < Views.Length; i++) {
				var view = Views [i];
				rect.X = i / ViewSize;
				rect.Y = i % ViewSize;
				AbsoluteLayout.SetLayoutBounds (view, rect);
				layout.Children.Add (view);
			}
			Renderer.CreateNativeView (layout);
		}
	}
}
