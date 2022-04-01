using Payment_processing.Business.Models;
using System.Linq;

namespace Payment_processing.Business.PaymentProcessors
{
    public class InvoicePaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order3 order)
        {
            // Create an invoice and email it

            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider3.Invoice);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}
