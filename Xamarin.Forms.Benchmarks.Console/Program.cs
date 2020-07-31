using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Xamarin.Forms.Benchmarks.Console
{
	public class Program
	{
		static void Main(string[] args)
		{
			var config = default (IConfig);
#if DEBUG
			config = new DebugInProcessConfig ();
#endif
			BenchmarkSwitcher.FromAssembly (typeof (BaseBenchmark).Assembly).Run (args, config);
		}
	}
}
