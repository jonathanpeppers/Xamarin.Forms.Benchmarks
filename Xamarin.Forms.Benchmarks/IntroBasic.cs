using System.Threading;
using BenchmarkDotNet.Attributes;

namespace Xamarin.Forms.Benchmarks
{
	public class IntroBasic
	{
		[Benchmark]
		public void Sleep() => Thread.Sleep(10);

		[Benchmark(Description = "Thread.Sleep(10)")]
		public void SleepWithDescription() => Thread.Sleep(10);
	}
}