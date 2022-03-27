/*
A Template method is an method in  a superclass that defines the skeleton of an operation in terms of higher level steps.Sublcasses implement these steps.
The template method pattern gets name from having a non-virtual method in  a paretn or base class that calls other virtual or abstract mthod in than same parent class.
Child classes override the methods where they wish to customize behaviour,but they cant touch the template method itself Some method in the abstract class may have a basic implementation,
while others may be empty and are provided solely as hooks for child classes 
*/
namespace TemplateMethod2
{
    public abstract class PanFoodServiceBase<T> where T : PanFood, new()
    {
        protected readonly LoggerAdapter _logger;
        protected T _item;

        public PanFoodServiceBase(LoggerAdapter logger)
        {
            _logger = logger;
        }
        public T Prepare()
        {
            _item = new T();

            PrepareCrust();

            AddToppings();

            Cover();

            if (_item.RequiresBakin)
            {
                Bake();
            }

            Slice();
         var a=   _logger.Dump();
            System.Console.WriteLine(a);
            return _item;
        }

        protected abstract void PrepareCrust();

        protected abstract void AddToppings();

        protected virtual void Bake()
        {
            _logger.Log("Bake the item.");
        }

        protected abstract void Slice();

        protected virtual void Cover()
        {
            // does nothing by default
        }

    }
}
