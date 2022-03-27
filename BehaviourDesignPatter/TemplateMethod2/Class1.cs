using System;
using System.Collections.Generic;
/*
A Template method is an method in  a superclass that defines the skeleton of an operation in terms of higher level steps.Sublcasses implement these steps.
The template method pattern gets name from having a non-virtual method in  a paretn or base class that calls other virtual or abstract mthod in than same parent class.
Child classes override the methods where they wish to customize behaviour,but they cant touch the template method itself Some method in the abstract class may have a basic implementation,
while others may be empty and are provided solely as hooks for child classes 
*/
namespace TemplateMethod2
{
    public abstract class PanFood
    {
        public bool RequiresBakin { get; set; } = true;
    }
    public class ColdVeggiePizza : PanFood
    {
        public ColdVeggiePizza()
        {
            base.RequiresBakin = false;
        }
    }

    public class Pie : PanFood { }

    public class Pizza : PanFood
    {
        public string CrustType { get; set; } = "no crust";
        public int NumSlices { get; set; } = 1;
        public List<string> Toppings { get; private set; } = new List<string>();
        public bool WasBaked { get; set; }
    }
    public class PizzaBakingService : PanFoodServiceBase<Pizza>
    {
        public PizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out and hand tossing the dough");
            _item.CrustType = "Thin";
        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pizza toppings");
            _item.Toppings.Add("Pepperoni");
            _item.Toppings.Add("Sausage");
        }

        protected override void Bake()
        {
            _logger.Log("Baking for 15 minutes");
            _item.WasBaked = true;
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 8 slices.");
            _item.NumSlices = 8;
        }
    }
}
