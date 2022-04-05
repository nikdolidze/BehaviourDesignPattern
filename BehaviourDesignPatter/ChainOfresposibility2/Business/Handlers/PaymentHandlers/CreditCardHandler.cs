using Payment_processing.Business.Models;
using Payment_processing.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers.PaymentHandlers
{
    public class CreditCardHandler : IReceiver<Order3>
    {
        public readonly CreditCardPaymentProcessor creditCardPaymentProcessor = new();
        public  void Handle(Order3 requst)
        {
            if (requst.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider3.CreditCard)) 
                creditCardPaymentProcessor.Finalize(requst);
        }
    }
}
