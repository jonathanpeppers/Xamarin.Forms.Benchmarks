namespace Xamarin.Forms.Benchmarks
{
	class DefaultNativeViewRenderer : INativeViewRenderer
	{
		/// <summary>
		/// We can't create a native view in a Console app. Let's force a layout instead.
		/// </summary>
		public object CreateNativeView (View view)
		{
			if (view is Layout layout) {
				layout.ForceLayout ();
			} else {
				view.Measure (double.MaxValue, double.MaxValue);
			}
			return view;
		}
	}
}
