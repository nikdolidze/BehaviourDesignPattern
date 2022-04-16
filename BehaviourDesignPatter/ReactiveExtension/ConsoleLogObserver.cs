using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtension
{
    public class ConsoleLogObserver : IObserver<int>
    {
        public void OnCompleted()
        {
            Console.WriteLine($"Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error {error}");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"Even Number {value}");
        }

     
    }
}
