using System;
using Xamarin.Forms.Benchmarks.Views;

namespace Xamarin.Forms.Benchmarks
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			BindingContext = new []
			{
				typeof (Bindings),
				typeof (Layouts),
			};
		}

		void ListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			if (e.Item is Type benchmarkType) {
				Navigation.PushAsync (new RunnerPage (benchmarkType));
				List.SelectedItem = null;
			}
		}
	}
}
