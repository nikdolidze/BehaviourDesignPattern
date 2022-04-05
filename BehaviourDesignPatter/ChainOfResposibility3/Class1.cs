using System;
/*
 The main purpose of this pattern is to separate the request some kind of message some kind of event from the actual thing that handles it 
 */
namespace ChainOfResposibility3
{
    public interface IKeyHandler
    {
        void Handle(string key);
    }
    public class IDE : IKeyHandler
    {
        IKeyHandler _handler;
        public IDE(IKeyHandler keyHandler) => _handler = keyHandler;

        public void Handle(string key)
        {
            if (key == "Ctrl+F")
                Console.WriteLine("Full Search");
            else if (key == "Ctrl+F4")
            {
                Console.WriteLine("Close application");
            }
            else
            {
                _handler.Handle(key);
            }
        }
    }
    public class CodeEditor : IKeyHandler
    {
        IKeyHandler _handler;
        public CodeEditor(IKeyHandler keyHandler) => _handler = keyHandler;

        public void Handle(string key)
        {
            if (key == "Ctrl+F")
                Console.WriteLine("local search");
            else _handler.Handle(key);
        }
    }
    public class CodeSelectin : IKeyHandler
    {
        IKeyHandler _handler;
        public CodeSelectin(IKeyHandler keyHandler) => _handler = keyHandler;

        public void Handle(string key)
        {

            if (key == "Ctrl+F")
                Console.WriteLine("selection  search");
            else _handler.Handle(key);
        }
    }
}
