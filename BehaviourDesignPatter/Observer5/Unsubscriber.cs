using System;
using System.Collections.Generic;

namespace Observer5
{
    public class Unsubscriber<T> : IDisposable
    {
        private readonly List<IObserver<T>> m_Observers;
        private readonly IObserver<T> m_Observer;
        private bool m_IsDisposed;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            m_Observers = observers;
            m_Observer = observer;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_IsDisposed) return;

            if (disposing && m_Observers.Contains(m_Observer))
            {
                m_Observers.Remove(m_Observer);
            }

            m_IsDisposed = true;
        }

        ~Unsubscriber()
        {
            Dispose(false);
        }
    }
}
