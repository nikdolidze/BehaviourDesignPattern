using ChainOfResposibilities5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Implementations.Handlers
{
    public class Handler2 : HandlerBase
    {
        public override IResponse Handle(IRequset requset)
        {
            var newMessage = new List<string>(requset.Messages) { "handled by handler 2" };
            if (NextHandler != null)
            {
                var nextRequest = new Requset(requset.id, newMessage);
                return NextHandler.Handle(nextRequest);
            }
            return new Response(newMessage);
        }
    }
}
