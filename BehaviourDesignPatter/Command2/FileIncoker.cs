namespace Command2
{
    public class FileIncoker
    {
        ICommand command;

        public FileIncoker(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }
    }
}
