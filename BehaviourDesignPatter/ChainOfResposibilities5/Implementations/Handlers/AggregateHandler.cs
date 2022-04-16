using ChainOfResposibilities5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilities5.Implementations.Handlers
{
    public class AggregateHandler : HandlerBase
    {
        private readonly List<IHandler> m_handlers;

        public AggregateHandler(params IHandler[] handlers)
        {
            if (handlers == null || !handlers.Any())
            {
                throw new ArgumentNullException(nameof(handlers), "no handlers ar set");
            }
            m_handlers = new List<IHandler>();
            m_handlers.AddRange(handlers);
        }

        public override IResponse Handle(IRequset requset)
        {
            if (m_handlers.Count > 0)
            {
                for (int handlerIndex = 0; handlerIndex < m_handlers.Count - 1; handlerIndex++)
                {
                    m_handlers[handlerIndex].SetNextHandler(m_handlers[handlerIndex + 1]);
                }
            }
            return m_handlers[0].Handle(requset);
        }
    }

}
