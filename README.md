# Xamarin.Forms.Benchmarks

Example of using BenchmarkDotNet to write some benchmarks for Xamarin.Forms concepts.

## Results of different bindings

Running on Windows .NET framework:

|         Method |     Mean |     Error |    StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |---------:|----------:|----------:|-------:|-------:|------:|----------:|
|  ByHandOneTime | 3.210 us | 0.0836 us | 0.0553 us | 0.5531 | 0.0038 |     - |   3.42 KB |
|   TypedOneTime | 4.087 us | 0.0560 us | 0.0370 us | 0.8163 | 0.0076 |     - |   5.05 KB |
| RegularOneTime | 5.375 us | 0.0117 us | 0.0077 us | 0.9079 | 0.0076 |     - |   5.61 KB |
|         ByHand | 5.552 us | 0.6508 us | 0.4305 us | 0.5951 | 0.1450 |     - |   3.71 KB |
|          Typed | 6.992 us | 0.4679 us | 0.3095 us | 0.9155 | 0.3052 |     - |   5.67 KB |
|        Regular | 7.822 us | 0.3988 us | 0.2638 us | 0.9460 | 0.3128 |     - |   5.86 KB |

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
