using BetterChainOfResponsibility.Abstractions;

namespace BetterChainOfResponsibility.Implementations.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        protected IHandler NextHandler;
        public abstract IResponse Handle(IRequset requset, IResponse accumulatedResponse = null);


        //public void SetNextHandler(IHandler next)
        //{
        //    this.NextHandler = next;
        //}
    }
}
