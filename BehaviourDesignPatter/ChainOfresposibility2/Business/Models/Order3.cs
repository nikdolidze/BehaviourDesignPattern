using System.Collections.Generic;
using System.Linq;

namespace Payment_processing.Business.Models
{
    public class Order3
    {
        public Dictionary<Item3, int> LineItems { get; } = new Dictionary<Item3, int>();

        public IList<Payment3> SelectedPayments { get; } = new List<Payment3>();

        public IList<Payment3> FinalizedPayments { get; } = new List<Payment3>();

        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - FinalizedPayments.Sum(payment => payment.Amount);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
    }
    
    public enum ShippingStatus 
    { 
        WaitingForPayment,
        ReadyForShippment,
        Shipped
    }

    public enum PaymentProvider3
    {
        Paypal,
        CreditCard,
        Invoice
    }

    public class Payment3
    {
        public decimal Amount { get; set; }
        public PaymentProvider3 PaymentProvider { get; set; }
    }

    public class Item3
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Item3(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}