using System;
/*
This pattern will let an algorithm,the strategy,used by clients to achieve something vary independently from the clinets that use it.
The intetn of this pattern is to define a family of algorithms, encapsulate each one and make them interchangeable,Strategy lets  the algorithm vary independenlty 
from clinets than use it.In other words you define a family of algorithms,put each one in a separate clas,and make them interchangebale
Strategy declares an interface common to all supported algorithms. Context uses it to call the algorithm defined a by ConcrateStrategy
Context is configured with a ConcreateStrategy object and maintains a reference to a Strategy object
 */
namespace Strategy
{/// <summary>
/// Strategy
/// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json");
        }
    }
    public class XmlExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML");
        }
    }
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV");
        }
    }
}
