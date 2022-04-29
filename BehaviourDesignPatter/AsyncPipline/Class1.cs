using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncPipline
{
	public interface IAsyncPipelineStep<TIn, TOut>
	{
		Task<TOut> ProcessAsync(Task<TIn> Input);
	}

	public abstract class AsyncPipeline<TIn, TOut> : IAsyncPipelineStep<TIn, TOut>
	{
		public Func<Task<TIn>, Task<TOut>> _pipelineSteps { get; protected set; }

		public Task<TOut> ProcessAsync(Task<TIn> Input)
		{
			return _pipelineSteps(Input);
		}

		public Task<TOut> ProcessAsync(TIn Input)
		{
			var inputTask = Task.FromResult(Input);
			return _pipelineSteps(inputTask);
		}
	}

	public static class AsyncPipelineStepExtensions
	{
		public static Task<TOut> Step<TIn, TOut>(this Task<TIn> Input, IAsyncPipelineStep<TIn, TOut> Step)
		{
			return Step.ProcessAsync(Input);
		}
	}

	public class HttpFetchAsyncStep : IAsyncPipelineStep<Uri, string>
	{
		private static readonly HttpClient _client = new HttpClient();

		public async Task<string> ProcessAsync(Task<Uri> Input)
		{
			var uri = await Input;
			return await _client.GetStringAsync(uri);
		}
	}

	public class DiskWriteAsyncStep : IAsyncPipelineStep<string, string>
	{
		public async Task<string> ProcessAsync(Task<string> Input)
		{
			var data = await Input;
			var fileName = System.IO.Path.GetTempFileName();

			await System.IO.File.WriteAllTextAsync(fileName, data);

			return fileName;
		}
	}

	public class ExampleAsyncPipeline : AsyncPipeline<Uri, string>
	{
		public ExampleAsyncPipeline()
		{
			_pipelineSteps = input => input
				.Step(new HttpFetchAsyncStep())
				.Step(new DiskWriteAsyncStep());

		}
	}
}