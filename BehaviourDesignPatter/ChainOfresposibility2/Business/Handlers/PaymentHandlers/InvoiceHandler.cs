using Payment_processing.Business.Models;
using Payment_processing.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresposibility2.Business.Handlers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order3>
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; }= new InvoicePaymentProcessor();
        public  void Handle(Order3 requst)
        {
            if (requst.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider3.Invoice)) 
                InvoicePaymentProcessor.Finalize(requst);
        }
    }
}
