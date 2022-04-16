using BetterChainOfResponsibility.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterChainOfResponsibility.Implementations.Handlers
{
    public class AggregateHandler : HandlerBase
    {
        private readonly List<IHandler> m_Handlers;

        public AggregateHandler(params IHandler[] handlers)
        {
            if (handlers == null || !handlers.Any())
            {
                throw new ArgumentNullException(nameof(handlers), "no handlers ar set");
            }
            m_Handlers = new List<IHandler>();
            m_Handlers.AddRange(handlers);
        }
        public override IResponse Handle(IRequset originalRequest, IResponse accumulatedResponse = null)
        {
            var previousResponse = m_Handlers[0].Handle(originalRequest, accumulatedResponse);

            if (m_Handlers.Count > 1)
            {
                for (var handlerIndex = 1; handlerIndex < m_Handlers.Count; handlerIndex++)
                {
                    previousResponse = m_Handlers[handlerIndex].Handle(originalRequest, previousResponse);
                }
            }

            return previousResponse;
        }
        //public override IResponse Handle(IRequset requset)
        //{
        //    if (m_handlers.Count > 0)
        //    {
        //        for (int handlerIndex = 0; handlerIndex < m_handlers.Count - 1; handlerIndex++)
        //        {
        //            m_handlers[handlerIndex].SetNextHandler(m_handlers[handlerIndex + 1]);
        //        }
        //    }
        //    return m_handlers[0].Handle(requset);
        //}
    }

}
