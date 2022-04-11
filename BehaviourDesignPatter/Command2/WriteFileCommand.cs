namespace Command2
{
    public class WriteFileCommand : ICommand
    {
        private IFileSystemReceiver fileSystemReceiver;

        public WriteFileCommand(IFileSystemReceiver fileSystemReceiver)
        {
            this.fileSystemReceiver = fileSystemReceiver;
        }

        public void Execute()
        {
            fileSystemReceiver.WriteFile();

        }
    }
}
