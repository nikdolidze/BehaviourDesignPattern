using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod3dot3
{
    public abstract class Procces
    {
        public void Start()
        {
            AbstractHook();
            DefaultHook();
        }
        public abstract void AbstractHook();
        public virtual void DefaultHook() { }
    }

    public class A : Procces
    {
        public override void AbstractHook()
        {
          //override
        }

        public override void DefaultHook()
        {
            base.DefaultHook();
        }
    }

    public class Procces_Strategy
    {
        Action strategy;
        public Procces_Strategy(Action strategy) => this.strategy = strategy;
        public void Start()
        {
            A();
            B();
            strategy();

        }
        public void B() => Console.WriteLine(nameof(B));

        public void A() => Console.WriteLine(nameof(A));
    }

}
