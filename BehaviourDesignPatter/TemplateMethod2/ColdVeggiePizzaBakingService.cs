/*
A Template method is an method in  a superclass that defines the skeleton of an operation in terms of higher level steps.Sublcasses implement these steps.
The template method pattern gets name from having a non-virtual method in  a paretn or base class that calls other virtual or abstract mthod in than same parent class.
Child classes override the methods where they wish to customize behaviour,but they cant touch the template method itself Some method in the abstract class may have a basic implementation,
while others may be empty and are provided solely as hooks for child classes 
*/
namespace TemplateMethod2
{
    public class ColdVeggiePizzaBakingService : PanFoodServiceBase<ColdVeggiePizza>
    {
        public ColdVeggiePizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void AddToppings()
        {
            _logger.Log("Add cream cheese, peppers, and veggies");

        }

        // there are a few ways to deal with optional behavior like this
        // 1. Override the default and do nothing
        // 2. Add conditional logic to the base template method
        // 3. Implement do-nothing hook method in base template; only override if you need to do something (see Cover)
        //protected override void Bake()
        //{
        //    // override default behavior
        //}

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out dough and press into pan");
        }

        protected override void Slice()
        {
            _logger.Log("Slice into squares");
            
        }
    }
}
