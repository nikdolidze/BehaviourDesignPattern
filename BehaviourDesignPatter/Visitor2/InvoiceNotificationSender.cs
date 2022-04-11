using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor2
{
    public class InvoiceNotificationSender : INotificationSender
    {
        public void Accept(Ivisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Send(string message)
        {
            Console.WriteLine("Nofificafion sent "+ message);
        }

    
    }
}
