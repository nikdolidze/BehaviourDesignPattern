using BetterChainOfResponsibility.Abstractions;
using System.Collections.Generic;

namespace BetterChainOfResponsibility.Implementations
{
    public class Response : IResponse  //same
    {
        public IReadOnlyCollection<string> Messages { get; }

        public Response(IReadOnlyCollection<string> messages)
        {
            Messages = messages;
        }
    }
}
