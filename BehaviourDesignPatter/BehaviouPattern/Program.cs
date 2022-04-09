using Chain_of_Responsibility_First_Look.Business;
using Chain_of_Responsibility_First_Look.Business.Models;
using ChainOfResposibility;
using ChainOfresposibility2.Business.Handlers;
using ChainOfresposibility2.Business.Handlers.PaymentHandlers;
using ChainOfResposibility3;
using ChainOfResposibility4;
using Command;
using Interpreter;
using Iterator;
using Mediator;
using Observer;
using Payment_processing.Business.Models;
using State;
using State._2;
using Strategy;
using Strategy2;
using System;
using System.Collections.Generic;
using System.Globalization;
using TemplateMethod;
using TemplateMethod2;
using TemplateMethod3;
using TemplateMethod3not2;
using Visitor;

namespace BehaviouPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Cat lordOfHouse = new Cat(typeof(Sleeping),10);
            lordOfHouse.ReceiveFood(5);
            lordOfHouse.FinishEating();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();



            Console.ReadKey();










            Console.ReadLine();

            Interpretor();
            Visitor();
            Iterator();
            State();
            Observer();
            ChainOfResposibility4();
            ChainOfResposibility3();
            ChainOfResposibilitise2();
            ChainOfResponsibility();
            Mediator();
            Command();
            Strategy2();
            Strategy();
            TemplateMethod3();
            TemplateMtehod2();
            TemplateMethod();
        }
        public static void Interpretor()
        {
            var expressions = new List<RomanExpression>
                {
                    new RomanHunderdExpression(),
                    new RomanTenExpression(),
                    new RomanOneExpression(),
                };

            var context = new RomanContext(5);
            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }
            Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 = {context.Output}");

            context = new RomanContext(81);
            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }
            Console.WriteLine($"Translating Arabic numerals to Roman numerals: 81 = {context.Output}");

            context = new RomanContext(733);
            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }
            Console.WriteLine($"Translating Arabic numerals to Roman numerals: 733 = {context.Output}");

        }
        public static void Visitor()
        {

            var container = new Containter();

            container.Customers.Add(new Customer("test", 1));
            container.Customers.Add(new Customer("test2", 12));
            container.Customers.Add(new Customer("test3", 123));
            container.Employees.Add(new Visitor.Employee("test4", 1234));
            container.Employees.Add(new Visitor.Employee("test5", 12345));

            DiscountVisitor discount = new();
            container.Accept(discount);

            Console.WriteLine($"Total discount : {discount.TotalDicsountGiven}");


        }
        public static void Iterator()
        {
            PeopleCollection people = new();
            people.Add(new Person("ge ", "nika"));
            people.Add(new Person(" ka", "nika2"));
            people.Add(new Person(" rus", "nika3"));
            people.Add(new Person("en ", "nika4"));

            var iterato = people.CrateIterator();
        }
        public static void State()
        {
            BankAccount bankAccount = new();
            bankAccount.Deposite(100);
            bankAccount.Withdrow(500);
            bankAccount.Withdrow(100);

            bankAccount.Deposite(2000);
            bankAccount.Deposite(100);
            bankAccount.Withdrow(3000);
            bankAccount.Deposite(3000);
            bankAccount.Deposite(100);



        }
        public static void Observer()
        {

            TicketStockService ticketStockServive = new();
            TicketResellerService ticketResellerServive = new();
            OrderService orderService = new();

            orderService.AddObserver(ticketResellerServive);
            orderService.AddObserver(ticketStockServive);
            orderService.CompleteTicketSale(1, 2);

        }
        public static void ChainOfResposibilitise2()
        {

            var order = new Order3();
            order.LineItems.Add(new Item3("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item3("EOSR", "Canon EOS R", 1799), 1);
            order.SelectedPayments.Add(new Payment3
            {
                PaymentProvider = PaymentProvider3.Paypal,
                Amount = 1000
            });
            order.SelectedPayments.Add(new Payment3
            {
                PaymentProvider = PaymentProvider3.Invoice,
                Amount = 1797
            });
            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
            /// TODO: Handle payment...

            var handler = new PaymentHandler(
                          new PayPalHandler(),
                          new InvoiceHandler(),
                          new CreditCardHandler());


            handler.Handle(order);

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
            /////////////

            var user = new User("Filip Ekberg",
                "870101XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));


            Console.WriteLine(user.Age);
            var processor = new UserProcessor();

            var ressult = processor.Register(user);

            Console.WriteLine(ressult);

        }
        public static void ChainOfResposibility4()
        {
            var manager = new SeniorManager();
            var vp = new VicePresitend();
            var co = new COO();


            manager.SerSuperviser(vp);
            vp.SerSuperviser(co);

            var expense = new ExpenseReport("nika", 5);
            manager.ApprovedRequst(expense);


        }
        public static void ChainOfResposibility3()
        {
            var ide = new IDE(null);
            var editor = new CodeEditor(ide);
            var codeselection = new CodeSelectin(editor);

            editor.Handle("Ctrl+F");
            codeselection.Handle("Ctrl+F");
            codeselection.Handle("Ctrl+F4");


        }
        public static void ChainOfResponsibility()
        {
            var validDocument = new Document("Test", DateTimeOffset.UtcNow, true, true);

            var inValidDocument = new Document("Test", DateTimeOffset.UtcNow, true, false);

            var documentChainHandler = new DocumentTitleHandler();

            documentChainHandler.SetSuccessor(new DocumentLastModifiedHandler())
                                .SetSuccessor(new DocumentApprovedByLitigationandler())
                                .SetSuccessor(new DocumentApprovedByManagmentHandler());


            try
            {
                documentChainHandler.Handle(validDocument);
                documentChainHandler.Handle(inValidDocument);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void Mediator()
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

        }
        public static void Command()
        {
            CommandManager commandManager = new();
            IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();
            commandManager.
                    Invoke(new AddAmployeeToManagerList(employeeManagerRepository, 3, new Command.Employee(1, "")));
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
