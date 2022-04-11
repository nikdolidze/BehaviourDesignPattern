using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command2
{
    public interface IFileSystemReceiver
    {
        void OpenFile();
        void CloseFile();
        void WriteFile();
    }
}
