using Payment_processing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers
{
    public class PaymentHandler
    {
        private readonly IList<IReceiver<Order3>> receivers;

        public PaymentHandler(params IReceiver<Order3>[] receivers)
        {
            this.receivers = receivers;
        }

        public void Handle(Order3 order)
        {
            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");

                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if (order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public void SetNext(IReceiver<Order3> next)
        {
            receivers.Add(next);
        }
    }
    public class InsufficientPaymentException : Exception
    {
    }
}

    //public abstract class PaymentHandler : IHandler<Order3>
    //{
    //    private IHandler<Order3> Next { get; set; }
    //    public virtual void Handle(Order3 requst)
    //    {
    //        Console.WriteLine($"Running : {GetType().Name}");
    //        if (Next == null && requst.AmountDue > 0)
    //        {
    //            throw new InvalidOperationException();
    //        }
    //        if (requst.AmountDue > 0)
    //        {
    //            Next.Handle(requst);
    //        }
    //        else
    //        {
    //            requst.ShippingStatus = ShippingStatus.ReadyForShippment;
    //        }
    //    }

    //    public IHandler<Order3> SetNext(IHandler<Order3> next)
    //    {
    //        Next = next;
    //        return Next;
    //    }
    //}
//}
