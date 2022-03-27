
using Strategy2;

namespace Strategy_Pattern_Creating_an_invoice.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order2 order);
    }
}