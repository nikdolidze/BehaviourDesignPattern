using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Abstractions
{
    public interface IRequset
    {
        int id { get; }
        IReadOnlyCollection<string> Messages { get; }
    }
}
