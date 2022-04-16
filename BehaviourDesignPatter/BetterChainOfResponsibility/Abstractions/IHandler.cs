using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterChainOfResponsibility.Abstractions
{
    public interface IHandler
    {
        //   void SetNextHandler(IHandler next);
        IResponse Handle(IRequset originalRequest, IResponse accumulatedResponse = null);
    }
}
