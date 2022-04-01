using Payment_processing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers
{
    public abstract class PaymentHandler : IHandler<Order3>
    {
        private IHandler<Order3> Next { get; set; }
        public virtual void Handle(Order3 requst)
        {
           if(Next == null && requst.AmountDue  > 0)
            {
                throw new InvalidOperationException();
            }
            if (requst.AmountDue > 0)
            {
                Next.Handle(requst); 
            }
        }

        public IHandler<Order3> SetNext(IHandler<Order3> next)
        {
            Next = next;
            return Next;
        }
    }
}
