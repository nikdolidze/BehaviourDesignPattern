using ChainOfResposibilities5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Implementations
{
    public class Requset : IRequset
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
