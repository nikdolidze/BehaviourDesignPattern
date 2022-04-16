using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer5
{
    namespace ExtendedObservable
    {
        public interface IExtendedObservable<out T> : IObservable<T>
        {
            IReadOnlyCollection<T> Snapshot { get; }

            IDisposable Subscribe(IObserver<T> observer, bool withHistory);
        }
    }
}
