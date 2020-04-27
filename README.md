# Xamarin.Forms.Benchmarks

Example of using BenchmarkDotNet to write some benchmarks for Xamarin.Forms concepts.



## Using BenchmarkDotNet in your own Xamarin project

If trying to get this working in your own project, a couple of notes:

* Run benchmarks with `Release` builds
* Disable the linker
* You may need to add `<PackageReference Include="Microsoft.CodeAnalysis.CSharp" Version="2.10.0" />`
  * _This caused a "There are no benchmarks found" message without it._

Otherwise, the bulk of the work is going to be making a simple UI for choosing benchmarks and running them.

Check out [BenchmarkDotNet's samples][bdn] for details.

[bdn]: https://github.com/dotnet/BenchmarkDotNet/tree/master/samples
