namespace Command2
{
    public class CloseFileCommand : ICommand
    {
        private IFileSystemReceiver fileSystemReceiver;

        public CloseFileCommand(IFileSystemReceiver fileSystemReceiver)
        {
            this.fileSystemReceiver = fileSystemReceiver;
        }

        public void Execute()
        {
            fileSystemReceiver.CloseFile();

        }
    }
}
