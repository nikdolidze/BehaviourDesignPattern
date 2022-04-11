namespace Visitor2
{
    public interface Ivisitor
    {
        void Visit(INotificationSender sender);
    }

    public class EmailVisitor : Ivisitor
    {
        public void Visit(INotificationSender sender)
        {
            System.Console.WriteLine("Setup email");
        }

    }

    public class TexsVisitor : Ivisitor
    {
        public void Visit(INotificationSender sender)
        {
            System.Console.WriteLine("Setup text");
        }
    }
}
