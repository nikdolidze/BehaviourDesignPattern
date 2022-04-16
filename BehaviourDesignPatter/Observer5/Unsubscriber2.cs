using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer5
{
    public class Unsubscriber2 : IDisposable
    {
        private readonly Action m_UnsubscribeAction;
        private bool m_IsDisposed;

        public Unsubscriber2(Action unsubscribeAction)
        {
            m_UnsubscribeAction = unsubscribeAction;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_IsDisposed) return;

            if (disposing)
            {
                m_UnsubscribeAction();
            }

            m_IsDisposed = true;
        }

        Unsubscriber2()
        {
            Dispose(false);
        }
    }
}