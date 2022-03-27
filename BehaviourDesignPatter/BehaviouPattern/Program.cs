using System;
using TemplateMethod;
using TemplateMethod2;
using TemplateMethod3;
using TemplateMethod3not2;

namespace BehaviouPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.ReadLine();


            TemplateMethod3();
            TemplateMtehod2();
            TemplateMethod();
        }

        public static void TemplateMethod3()
        {
            new TemplateMethod3dot3.Procces_Strategy(() => Console.WriteLine("Action Method")).Start();

            new TemplateMethod3.Procces().Start();
            new TemplateMethod3.Variation1().Start();
            new TemplateMethod3.Variation2().Start();
            new Variation3().Start();

            new TemplateMethod3not2.Variation1().Start();
            new TemplateMethod3not2.Variation2().Start();
        }
        public static void TemplateMtehod2()
        {
            var logger = new LoggerAdapter();
            var service = new ColdVeggiePizzaBakingService(logger);

            var pizza = service.Prepare();
        }
        public static void TemplateMethod()
        {
            ExchangeMainParser exchangeMainParser = new();
            Console.WriteLine(exchangeMainParser.ParseMailBody(new Guid().ToString()));

            Console.WriteLine();

            EudoraMailServer mailServer = new EudoraMailServer();
            Console.WriteLine(mailServer.ParseMailBody("25"));

        }
    }


}
