using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Abstractions
{
    public interface IHandler
    {
        void SetNextHandler(IHandler next);
        IResponse Handle(IRequset requset);
    }
}
