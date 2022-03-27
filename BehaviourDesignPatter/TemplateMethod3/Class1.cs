using System;

/*
 The pattern itself aims to define an algorithm template hence template method where the steps of the algorithm can be substituted by inheritance.
the template method itsel is a blueprint the classes that inherint from the original class, have the ability to substitude the steps in the blueprin. 
 */
namespace TemplateMethod3
{
    public class Procces
    {
        public void Start()
        {
            Step1();
            Step2();
            Step3();
        }

        protected virtual void Step3()
        {
            Console.WriteLine(nameof(Step3));
        }

        protected virtual void Step2()
        {
            Console.WriteLine(nameof(Step2));
        }

        protected virtual void Step1()
        {
            Console.WriteLine(nameof(Step1));
        }
    }
    public class Variation1 : Procces
    {
        protected override void Step1()
        {
            Console.WriteLine("Step 1 Adapted");
        }
    }
    public class Variation2 : Procces
    {
        protected override void Step2()
        {
            Console.WriteLine("Step 2 adapted");
        }
    }
    public class Variation3 : Procces
    {
        protected override void Step3()
        {
            Console.WriteLine("Step 3 adapted");
        }
    }
}
