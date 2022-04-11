using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer2
{
	public class Alarm2 : IObservable<int>, IDisposable
	{
		List<IObserver<int>> watchers = new();

		public IDisposable Subscribe(IObserver<int> observer)
		{
			watchers.Add(observer);
			return this;
		}
		int i = 0;

		public void Notify()
		{
			if (i > 3)
			{
				watchers.ForEach(x => x.OnCompleted());
				return;
			}

			watchers.ForEach(x => x.OnNext(i++));
		}

		public void Dispose() => throw new NotImplementedException();
	}


	public class FireStation2 : IObserver<int>
	{
		public void Alert(Alarm value)
		{
            Console.WriteLine(nameof(FireStation2) + "RESPONDING");
		}

		public void OnCompleted()
		{
			Console.WriteLine(nameof(FireStation2) + "complete");
		}

		public void OnError(Exception error)
		{
			Console.WriteLine(nameof(FireStation2) + "error");
		}

		public void OnNext(int value)
		{
			Console.WriteLine(nameof(FireStation2) + "next: " + value);
		}
	}
}
