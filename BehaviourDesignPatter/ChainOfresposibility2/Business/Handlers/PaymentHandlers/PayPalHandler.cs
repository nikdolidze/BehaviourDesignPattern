using Payment_processing.Business.Models;
using Payment_processing.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers.PaymentHandlers
{
    public class PayPalHandler : IReceiver<Order3>
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get;}= new PaypalPaymentProcessor();
        public  void Handle(Order3 requst)
        {
            if (requst.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider3.Paypal))
                PaypalPaymentProcessor.Finalize(requst);

        }
    }
  
}
