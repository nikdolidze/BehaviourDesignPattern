using ChainOfResposibilities5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Implementations.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        protected IHandler NextHandler;
        public abstract IResponse Handle(IRequset requset);


        public void SetNextHandler(IHandler next)
        {
            this.NextHandler = next;
        }
    }
}
