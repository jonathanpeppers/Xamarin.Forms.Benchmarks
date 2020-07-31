namespace Xamarin.Forms.Benchmarks
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage (new MainPage ());
		}
	}
}
