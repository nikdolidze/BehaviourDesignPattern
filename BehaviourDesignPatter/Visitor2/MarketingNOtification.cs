using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor2
{
    public class MarketingNotification : INotificationSender
    {
        public void Accept(Ivisitor ivisitor)
        {
            ivisitor.Visit(this);
        }

        public void Send(string message)
        {
            Console.WriteLine("Nofificafion sent " + message);
        }

    }
}
