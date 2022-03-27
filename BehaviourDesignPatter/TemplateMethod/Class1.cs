using System;
/*
 Its intent is to define a skeleton of an algorithm in an operaion, deferring  some steps to sublcasses.
the intent of this pattern is to define the skeleton of an algorithm in an operation, deferring some steps to subclasses. it lets subclasses redefine some steps to subclasses.
it lets subclasses redefine certain steps of an algorithm without changing the algorithms structure.
 */
namespace TemplateMethod
{
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("finding server");
        }
        public abstract void AuthentificateToServer();

        public string ParseHtmlMainBody(string identifier)
        {
            Console.WriteLine("Parsing HTML main body....");
            return $"This is the body of a main with id {identifier}";
        }
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing main body (in template Method)");
            FindServer();
            AuthentificateToServer();
            return ParseHtmlMainBody(identifier);
        }

    }

    public class ExchangeMainParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora server thorugh");
        }
        public override void AuthentificateToServer()
        {
            Console.WriteLine("Conected to Apache");

        }
    }

    public class EudoraMailServer : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("finding Eudora server through a custom algorithm");
        }
        public override void AuthentificateToServer()
        {
            Console.WriteLine("connected to Eudora");
        }
    }
}
