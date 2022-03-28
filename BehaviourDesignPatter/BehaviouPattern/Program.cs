using Command;
using Mediator;
using Strategy;
using Strategy2;
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
            TeamChatRoom chatRoom = new();

            var nika = new Loyer("nika");
            var nika2 = new Loyer("nika2");
            var nika3 = new AccountManager("nika3");
            var nika4 = new AccountManager("nika4");
            var nika5 = new AccountManager("nika5");

            chatRoom.Registger(nika);
            chatRoom.Registger(nika2);
            chatRoom.Registger(nika3);
            chatRoom.Registger(nika4);
            chatRoom.Registger(nika5);


            nika4.SendTo<Loyer>("accoutmanager");

        //    nika.Send("nika3", "baro");

       //     nika.Send("test");
          //  nika3.Send("yest");

            Console.ReadLine();
            Command();
            Strategy2();
            Strategy();
            TemplateMethod3();
            TemplateMtehod2();
            TemplateMethod();
        }
        public static void Command()
        {
            CommandManager commandManager = new();
            IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();
            commandManager.
                    Invoke(new AddAmployeeToManagerList(employeeManagerRepository, 3, new Employee(1, "")));
            commandManager.Undo();
        }
        public static void Strategy2()
        {

            var order = new Order2
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                SalesTaxStrategy = new SwedenSalesTaxStrategy()
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
            Console.WriteLine(order.GetTax());
            order.FinalizeOrder();
        }
        public static void Strategy()
        {
            var order = new Order("test,", "nika", 5);
            order.ExportService = new CSVExportService();
            order.Export();

            order.ExportService = new JsonExportService();
            order.Export();

            order.Export(new XmlExportService());
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
