# Xamarin.Forms.Benchmarks

Example of using BenchmarkDotNet to write some benchmarks for Xamarin.Forms concepts.

## Results of different bindings

|         Method |     Mean |     Error |    StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |---------:|----------:|----------:|-------:|-------:|------:|----------:|
|         ByHand | 3.150 us | 0.0234 us | 0.0208 us | 0.5531 | 0.0038 |     - |   3.42 KB |
|  ByHandOneTime | 3.156 us | 0.0439 us | 0.0366 us | 0.5531 | 0.0038 |     - |   3.42 KB |
|   TypedOneTime | 3.972 us | 0.0188 us | 0.0176 us | 0.8163 | 0.0076 |     - |   5.05 KB |
|          Typed | 4.866 us | 0.0702 us | 0.0622 us | 0.9079 | 0.0076 |     - |   5.61 KB |
| RegularOneTime | 5.386 us | 0.0191 us | 0.0179 us | 0.9079 | 0.0076 |     - |   5.61 KB |
|        Regular | 5.598 us | 0.1091 us | 0.1883 us | 0.9003 | 0.0076 |     - |   5.58 KB |

_NOTE:_ There may be a bug in Xamarin.Forms, as `ByHandOneTime` has the same
memory usage as `ByHand`.

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
