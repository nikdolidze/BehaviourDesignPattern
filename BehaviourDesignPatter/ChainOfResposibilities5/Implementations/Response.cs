using ChainOfResposibilities5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Implementations
{
    public class Response : IResponse
    {
        public IReadOnlyCollection<string> Messages { get; }

        public Response(IReadOnlyCollection<string> messages)
        {
            Messages = messages;
        }
    }
}
