using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor2
{
    public interface INotificationSender
    {
        void Send(string message);

        void Accept(Ivisitor ivisitor);
      
    }
}
