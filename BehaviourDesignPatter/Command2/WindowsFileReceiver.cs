using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command2
{
    public class WindowsFileReceiver : IFileSystemReceiver
    {
        public void CloseFile()
        {
            Console.WriteLine("Closing file on windows");
        }

        public void OpenFile()
        {
            Console.WriteLine("Open file on windows");
        }

        public void WriteFile()
        {
            Console.WriteLine("Write file on windows");
        }
    }
}
