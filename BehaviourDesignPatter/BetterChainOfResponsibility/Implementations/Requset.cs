using BetterChainOfResponsibility.Abstractions;
using System.Collections.Generic;

namespace BetterChainOfResponsibility.Implementations
{
    public class Requset : IRequset  //same
    {
        public int id { get; }

        public IReadOnlyCollection<string> Messages { get; }

        public Requset(int id, IReadOnlyCollection<string> messages)
        {
            this.id = id;
            Messages = messages;
        }
    }
}
