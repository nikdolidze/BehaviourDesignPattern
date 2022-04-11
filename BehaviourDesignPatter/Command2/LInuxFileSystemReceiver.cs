using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command2
{
    public class LInuxFileSystemReceiver : IFileSystemReceiver
    {
        public void CloseFile()
        {
            Console.WriteLine("Closing file on linux");
        }

        public void OpenFile()
        {
            Console.WriteLine("Open file on lonux");
        }

        public void WriteFile()
        {
            Console.WriteLine("Write file on linux");
        }
    }
}
