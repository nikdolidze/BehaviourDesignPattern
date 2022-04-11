using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command2
{
    public class OpenFileCommand : ICommand
    {
        private IFileSystemReceiver fileSystemReceiver;

        public OpenFileCommand(IFileSystemReceiver fileSystemReceiver)
        {
            this.fileSystemReceiver = fileSystemReceiver;
        }

        public void Execute()
        {
            fileSystemReceiver.OpenFile();

        }
    }
}
