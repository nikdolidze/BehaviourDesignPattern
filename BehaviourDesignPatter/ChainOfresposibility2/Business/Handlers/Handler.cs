using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }
        public  virtual void Handle(T requst)
        {
            Next?.Handle(requst);
        }

        public IHandler<T> SetNext(IHandler<T> next)
        {
           Next = next;
            return Next;
        }
    }


    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        void Handle(T requst);
    }
}
