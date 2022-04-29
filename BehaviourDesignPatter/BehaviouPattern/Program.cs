#region MyRegion
using BetterChainOfResponsibility.Implementations;
using BetterChainOfResponsibility.Implementations.Handlers;
using Chain_of_Responsibility_First_Look.Business;
using Chain_of_Responsibility_First_Look.Business.Models;
using ChainOfResposibility;
using ChainOfresposibility2.Business.Handlers;
using ChainOfresposibility2.Business.Handlers.PaymentHandlers;
using ChainOfResposibility3;
using ChainOfResposibility4;
using Command;
using Command2;
using Interpreter;
using Iterator;
using Mediator;
using Observer;
using Observer2;
using Observer3;
using Observer4;
using Observer5;
using Payment_processing.Business.Models;
using Pipline;
using ReactiveExtension;
using State;
using State._2;
using State3;
using StateMachine;
using Strategy;
using Strategy2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using TemplateMethod;
using TemplateMethod2;
using TemplateMethod3;
using Visitor;
using Visitor2;
using Visitor3;
#endregion
using Pipline.StronglyTypedPipelines;
using AsyncPipline;
using System.Threading.Tasks;

namespace BehaviouPattern
{
    internal class Program
    {
   
       

        static  void Main(string[] args)
        {
          


          

            Console.ReadLine();
            Console.ReadKey();
            Visitor3();
            Pipline();
            Observer5();
            Commandd2();
            ChainOfResposibilitities5();
            Observer4();
            Observer3();
            Observer2();
            StateMacine();
            State3();
            State2();
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
        async Task Test()
        {
            var pipeline = new ExampleAsyncPipeline();
            var uri = new Uri("https://news.bbc.co.uk/");

            var tempFile = await pipeline.ProcessAsync(uri);

            Console.WriteLine($"{uri} saved to {tempFile}");

        }
        public static void Visitor3()
        {
            var motorBikeInsurance = new MotorBikeInsurance();
            var carInsurance = new CarInsurance();
            var quoteVisitor = new QuoteVisitor();
            var customerVisitor = new CustomerCommunicationVisitor();

            motorBikeInsurance.Accept(quoteVisitor);
            carInsurance.Accept(quoteVisitor);
            Console.WriteLine("-----------------------");

            motorBikeInsurance.Accept(customerVisitor);
            carInsurance.Accept(customerVisitor);
        }
        public static void Pipline()
        {
            Console.WriteLine("Event Pipeline Test");

            var input = 49;
            Console.WriteLine(string.Format("Input Value: {0} [{1}]", input, input.GetType().Name));

            var pipeline = new EventStep<int, int>(new DoubleStep());
            pipeline.OnInput += i => Console.WriteLine("Input event: " + i.ToString());
            pipeline.OnOutput += o => Console.WriteLine("Output event: " + o.ToString());
            var output = pipeline.Process(input);

            Console.WriteLine(string.Format("Output Value: {0} [{1}]", output, output.GetType().Name));
            Console.WriteLine();
            static void BasicPipelineTest()
            {
                Console.WriteLine("Basic Pipeline Test");

                var input = 49;
                Console.WriteLine(string.Format("Input Value: {0} [{1}]", input, input.GetType().Name));

                var pipeline = new BasicPipeline();
                var output = pipeline.Process(input);

                Console.WriteLine(string.Format("Output Value: {0} [{1}]", output, output.GetType().Name));
                Console.WriteLine();
            }
            static void NestedPipelineTest()
            {
                Console.WriteLine("Nested Pipeline Test");

                var input = 103;
                Console.WriteLine(string.Format("Input Value: {0} [{1}]", input, input.GetType().Name));

                var pipeline = new NestedPipeline();
                var output = pipeline.Process(input);

                Console.WriteLine(string.Format("Output Value: {0} [{1}]", output, output.GetType().Name));
                Console.WriteLine();
            }
            static void BranchingPipelineTest()
            {
                Console.WriteLine("Branching Pipeline Test");

                foreach (int input in new int[] { 1, 10, 100, 1000 })
                {
                    Console.WriteLine(string.Format("Input Value: {0} [{1}]", input, input.GetType().Name));

                    var pipeline = new BranchingPipeline();
                    var output = pipeline.Process(input);

                    Console.WriteLine(string.Format("Output Value: {0} [{1}]", output, output.GetType().Name));
                }

                Console.WriteLine();
            }
            BasicPipelineTest();
            NestedPipelineTest();
            BranchingPipelineTest();
        }
        public static void ReacviceExtension()
        {
            var evenNumber = new EvenNumberSubject();
            evenNumber.Subscribe(Console.WriteLine);
            evenNumber.Run();

            Observable.Range(1, 100).Where(x => x % 2 == 0).Subscribe(Console.WriteLine);

            //var eventNumber = new EvenNumberObservable();
            //var consoleLogObserver = new ConsoleLogObserver();
            //eventNumber.Subscribe(consoleLogObserver);

        
        }
        public static void Observer5()
        {
            var provider = new WeatherForecast();
            provider.RegisterWeatherInfo(new WeatherInfo(1));
            provider.RegisterWeatherInfo(new WeatherInfo(2));
            provider.RegisterWeatherInfo(new WeatherInfo(3));

            var observer = new WeatherForecastObserver();
            observer.Subscribe(provider);
            provider.RegisterWeatherInfo(new WeatherInfo(4));
            provider.RegisterWeatherInfo(new WeatherInfo(5));

            observer.Unsubscribe();

            provider.RegisterWeatherInfo(new WeatherInfo(6));

            observer.Subscribe(provider);

            provider.RegisterWeatherInfo(new WeatherInfo(7));
        }
        public static void ChainOfResposibilitities5()
        {
            var initialRequest = new Requset(1, new List<string> { "This is the initial request" });

            var aggregateHandler1 = new AggregateHandler(
                new Handler1(),
                new Handler2());

            Console.WriteLine(string.Join("\n\r", aggregateHandler1.Handle(initialRequest).Messages));

            var aggregateHandler2 = new AggregateHandler(
                new Handler2(),
                new Handler1());

            Console.WriteLine();

            Console.WriteLine(string.Join("\n\r", aggregateHandler2.Handle(initialRequest).Messages));

            Console.ReadLine();
        }
        public void Visitor2()
        {
            var emailVisitor = new EmailVisitor();
            var textvisitor = new TexsVisitor();

            var notificationsender1 = new InvoiceNotificationSender();
            notificationsender1.Accept(emailVisitor);
            notificationsender1.Accept(textvisitor);
            notificationsender1.Send("INvoice");



            var notificationsender2 = new MarketingNotification();
            notificationsender2.Accept(textvisitor);
            notificationsender2.Accept(textvisitor);
            notificationsender2.Send("Marketin");
        }
        public static void Commandd2()
        {
            //craete receiver object
            IFileSystemReceiver fs = new WindowsFileReceiver();

            FileIncoker fileIncoker;

            OpenFileCommand openFileCommand = new OpenFileCommand(fs);
            fileIncoker = new FileIncoker(openFileCommand);
            fileIncoker.Execute();

            WriteFileCommand wr = new WriteFileCommand(fs);
            fileIncoker = new FileIncoker(wr);
            fileIncoker.Execute();


            CloseFileCommand cl = new CloseFileCommand(fs);
            fileIncoker = new FileIncoker(cl);
            fileIncoker.Execute();

            IFileSystemReceiver fs2 = new LInuxFileSystemReceiver();


            FileIncoker fileIncoker2;

            OpenFileCommand openFileCommand2 = new OpenFileCommand(fs2);
            fileIncoker = new FileIncoker(openFileCommand2);
            fileIncoker.Execute();

            WriteFileCommand wr2 = new WriteFileCommand(fs2);
            fileIncoker = new FileIncoker(wr2);
            fileIncoker.Execute();


            CloseFileCommand cl2 = new CloseFileCommand(fs2);
            fileIncoker = new FileIncoker(cl2);
            fileIncoker.Execute();

        }
        public static void Observer3()
        {
            var subject = new Subject("nika", 24);
            var objserver = new Observerr3();
            subject.Subscribe(objserver);
            subject.UpdateUserAge(25);



        }
        public static void Observer2()
        {
            var alarm2 = new Alarm2();
            alarm2.Subscribe(new FireStation2());
            alarm2.Notify();
            alarm2.Notify();
            alarm2.Notify();
            alarm2.Notify();
            alarm2.Notify();


            var alarm = new Alarm();
            alarm.AddWatcher(new FireStation());
            alarm.AddWatcher(new PoliceStation());
            alarm.AddWatcher(new HospitalStation());
            alarm.Notify();
        }
        public static void Observer4()
        {
            WeatherStation weatherStation = new WeatherStation();
            NewsAgency newsAgency1 = new NewsAgency("Alpha");
            weatherStation.Attach(newsAgency1);
            NewsAgency newsAgency2 = new NewsAgency("Alpha2");
            weatherStation.Attach(newsAgency2);

            weatherStation.updqteTemprature(31.2f);
            weatherStation.updqteTemprature(28f);
            weatherStation.updqteTemprature(46.8f);
            weatherStation.updqteTemprature(15.3f);

        }
        public static void StateMacine()
        {
            var car2 = new Stateless.StateMachine<Car.StateCar, Car.Action>(Car.StateCar.Stopped);


            car2.OnTransitioned(x => Console.WriteLine($"***********************************************Transitioned {x.Source},  {x.Destination}"));

            car2.Configure(Car.StateCar.Stopped)
                .Permit(Car.Action.Start, Car.StateCar.Started);

            car2.Configure(Car.StateCar.Started)

                .Permit(Car.Action.Accelarate, Car.StateCar.Running)
                .PermitReentry(Car.Action.Start)
                .Permit(Car.Action.Stop, Car.StateCar.Stopped)
                .OnEntry(x => Console.WriteLine($"Source {x.Source} , {x.Destination}")).
                 OnExit(x => Console.WriteLine($"exit {x.Source} , {x.Destination}"));

            var triggerwithparam = car2.SetTriggerParameters<int>(Car.Action.Start);

            car2.Configure(Car.StateCar.Running)
                .SubstateOf(Car.StateCar.Started)
                .OnEntryFrom(triggerwithparam, speed => Console.WriteLine($"Speed is  {speed}"))
                .Permit(Car.Action.Stop, Car.StateCar.Stopped)
                .InternalTransition(Car.Action.Start, () => Console.WriteLine("Car is already runnning"));




            car2.Fire(triggerwithparam, 50);



            Console.WriteLine($"CurrentState {car2.State}");

            car2.Fire(Car.Action.Stop);

            Console.WriteLine($"CurrentState {car2.State}");

            car2.Fire(Car.Action.Start);

            Console.WriteLine($"CurrentState {car2.State}");

            car2.Fire(Car.Action.Accelarate);

            Console.WriteLine($"CurrentState {car2.State}");
            car2.Fire(Car.Action.Stop);

            Console.WriteLine($"CurrentState {car2.State}");


            var a = car2.GetPermittedTriggers();

            Console.WriteLine("-------**********---------");

            var car = new Car();
            Console.WriteLine($"CurrentState {car.CurrentState}");

            car.TakeAction(Car.Action.Start);

            Console.WriteLine($"CurrentState {car.CurrentState}");

            car.TakeAction(Car.Action.Start);

            Console.WriteLine($"CurrentState {car.CurrentState}");

            car.TakeAction(Car.Action.Accelarate);

            Console.WriteLine($"CurrentState {car.CurrentState}");
            car.TakeAction(Car.Action.Stop);

            Console.WriteLine($"CurrentState {car.CurrentState}");



        }
        public static void State3()
        {
            string code = "1234";
            var statee = SState.Locked;
            var entry = new StringBuilder();
            while (true)
            {
                switch (statee)
                {
                    case SState.Locked:
                        entry.Append(Console.ReadKey().KeyChar);
                        if (entry.ToString() == code)
                        {
                            statee = SState.Unloked;
                            break;
                        }
                        if (!code.StartsWith(entry.ToString()))
                        {
                            statee = SState.Failed;
                            break;
                        }
                        break;
                    case SState.Failed:
                        Console.CursorLeft = 0;
                        Console.WriteLine("Failded");
                        entry.Clear();
                        statee = SState.Locked;
                        break;
                    case SState.Unloked:
                        Console.CursorLeft = 0;
                        Console.WriteLine("Unloked");
                        break;

                }
            }




            Console.Read();
            var state = StateEnum.OffHook;
            while (true)
            {
                Console.WriteLine("The pron is currently " + state);
                Console.WriteLine("select a trigger :");
                for (int i = 0; i < Demo.rules[state].Count; i++)
                {
                    var (t, h) = Demo.rules[state][i];
                    Console.WriteLine($"{i} , {t}        {h}");
                }
                int input = int.Parse(Console.ReadLine());
                var (_, s) = Demo.rules[state][input];
                state = s;
            }




            Console.ReadLine();
            var ls = new Switch();
            ls.On();
            ls.Off();
            ls.Off();


        }
        public static void State2()
        {

            Cat lordOfHouse = new Cat(typeof(Sleeping), 10);
            lordOfHouse.ReceiveFood(5);
            lordOfHouse.FinishEating();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();
            lordOfHouse.CompletePlan();
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
