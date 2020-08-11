using System;
using System.Reflection;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Diagnostics;
using Xamarin.Forms.Xaml.Internals;
using static Xamarin.Forms.Internals.ResourceLoader;

namespace Xamarin.Forms.Benchmarks
{
	public partial class BindingLabel : Label
	{
		public BindingLabel (bool initializeComponent2)
		{
			if (initializeComponent2) {
				InitializeComponent2 ();
			} else {
				InitializeComponent ();
			}
		}

		void InitializeComponent2 ()
		{
			if (ResourceLoader2.IsEnabled && ResourceLoader2.CanProvideContentFor (new ResourceLoader.ResourceLoadingQuery {
				AssemblyName = typeof (BindingLabel).GetTypeInfo ().Assembly.GetName (),
				ResourcePath = "Views/BindingLabel.xaml",
				Instance = this
			})) {
				__InitComponentRuntime2 ();
				return;
			}
			if (XamlLoader.XamlFileProvider != null && XamlLoader.XamlFileProvider (GetType ()) != null) {
				__InitComponentRuntime2 ();
				return;
			}
			BindingExtension bindingExtension;
			VisualDiagnostics.RegisterSourceInfo (bindingExtension = new BindingExtension (), new Uri ("Views\\BindingLabel.xaml" + ";assembly=" + "Xamarin.Forms.Benchmarks", UriKind.RelativeOrAbsolute), 6, 5);
			BindingLabel bindingLabel;
			VisualDiagnostics.RegisterSourceInfo (bindingLabel = this, new Uri ("Views\\BindingLabel.xaml" + ";assembly=" + "Xamarin.Forms.Benchmarks", UriKind.RelativeOrAbsolute), 2, 2);
			NameScope value = (NameScope) (NameScope.GetNameScope (bindingLabel) ?? new NameScope ());
			NameScope.SetNameScope (bindingLabel, value);
			bindingExtension.Path = "Text";
			BindingBase binding = ((IMarkupExtension<BindingBase>) bindingExtension).ProvideValue ((IServiceProvider) null);
			bindingLabel.SetBinding (Label.TextProperty, binding);
		}

		void __InitComponentRuntime2() { }
	}
}

namespace Xamarin.Forms.Internals
{
	public static class ResourceLoader2
	{
		public static bool IsEnabled { get; } = false;

		public static bool CanProvideContentFor (ResourceLoadingQuery rlq) => ResourceLoader.CanProvideContentFor (rlq);
	}
}
