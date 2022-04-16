using BetterChainOfResponsibility.Abstractions;
using System.Collections.Generic;

namespace BetterChainOfResponsibility.Implementations.Handlers
{
    public class Handler1 : HandlerBase
    {
        public override IResponse Handle(IRequset originalRequest , IResponse accumulatedResponse  = null)
        {
            List<string> newMessages;

            if (accumulatedResponse != null)
            {
                newMessages = new List<string>(accumulatedResponse.Messages) { "Handled by Handler 1" };
            }
            else
            {
                newMessages = new List<string>(originalRequest.Messages) { "Handled by Handler 1" };
            }

            return new Response(newMessages);
            //var newMessage = new List<string>(requset.Messages) { "handled by handler 1" };

            //if(NextHandler != null)
            //{
            //    var nextRequest = new Requset(requset.id, newMessage);
            //    return NextHandler.Handle(nextRequest);
            //}
            //return new Response(newMessage);
        }

    
    }
}
