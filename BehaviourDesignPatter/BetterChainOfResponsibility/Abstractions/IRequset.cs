using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterChainOfResponsibility.Abstractions
{ //same
    public interface IRequset
    {
        int id { get; }
        IReadOnlyCollection<string> Messages { get; }
    }
}
