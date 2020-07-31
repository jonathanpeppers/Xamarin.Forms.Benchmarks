# Xamarin.Forms.Benchmarks

Example of using BenchmarkDotNet to write some benchmarks for Xamarin.Forms concepts.

## Using BenchmarkDotnet for Xamarin.Forms in a Console app

This is likely the simplest option. Setup [BenchmarkDotNet][getting-started] as you would for a normal .NET console app.

This is what I normally do:

```csharp
static void Main(string[] args)
{
    var config = default (IConfig);
#if DEBUG
    // If you want to debug your benchmarks, you need this
    // When taking final measurements, use a Release build.
    config = new DebugInProcessConfig ();
#endif
    BenchmarkSwitcher.FromAssembly (typeof (Program).Assembly).Run (args, config);
}
```

If you want to use Xamarin.Forms on desktop, use my [Xamarin.Forms.Mocks][mocks] mocking library.
This will allow you to benchmark Xamarin.Forms.Core and Xamarin.Forms.Xaml independent of any platform-specific code.

[getting-started]: https://benchmarkdotnet.org/articles/guides/getting-started.html
[mocks]: https://github.com/jonathanpeppers/Xamarin.Forms.Mocks

## Using BenchmarkDotNet in your Xamarin.Android/iOS project

If trying to get this working in a mobile application project, a couple of notes:

* Run benchmarks with `Release` builds
* Disable the linker

Otherwise, the bulk of the work is going to be making a simple UI for choosing benchmarks and running them.

Check out [BenchmarkDotNet's samples][bdn] for details.

[bdn]: https://github.com/dotnet/BenchmarkDotNet/tree/master/samples
