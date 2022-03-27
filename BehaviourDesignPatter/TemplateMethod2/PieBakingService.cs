/*
A Template method is an method in  a superclass that defines the skeleton of an operation in terms of higher level steps.Sublcasses implement these steps.
The template method pattern gets name from having a non-virtual method in  a paretn or base class that calls other virtual or abstract mthod in than same parent class.
Child classes override the methods where they wish to customize behaviour,but they cant touch the template method itself Some method in the abstract class may have a basic implementation,
while others may be empty and are provided solely as hooks for child classes 
*/
namespace TemplateMethod2
{
    public class PieBakingService : PanFoodServiceBase<Pie>
    {
        public PieBakingService(LoggerAdapter logger):base(logger)
        {

        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pie filling");
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out crust and pressing into pie pan");
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 6 slices.");
        }
        protected override void Bake()
        {
            _logger.Log("Baking for 45 minutes");
        }
        protected override void Cover()
        {
            _logger.Log("Adding lattice top");
        }
    }
}
