using System;

namespace State._2
{
    public abstract class CatState
    {
        protected Cat Handle { get; set; }
        public CatState(Cat handle)
        {
            this.Handle = handle;
        }
        public virtual void GetFed(int amount, int happywith) { }
        public virtual void BowEmpty() { }
        public virtual void WolBeware() { }

    }

    public class Cat
    {
        public CatState CurrentState { get; set; }
        int foodHappyAmount;
        public Cat(Type InitialState, int happywith)
        {
            if (InitialState == typeof(Sleeping))
                this.CurrentState = new Sleeping(this);
            if (InitialState == typeof(Eating))
                this.CurrentState = new Eating(this, 0, happywith);
            if (InitialState == typeof(Contemplating))
                this.CurrentState = new Contemplating(this);

            Console.WriteLine($"His majesty is {CurrentState.GetType().Name}");
            this.foodHappyAmount = happywith;
        }

        public void ReceiveFood(int amount)
        {
            CurrentState.GetFed(amount, foodHappyAmount); Console.WriteLine($"His majesty is {CurrentState.GetType().Name}");
        }
        public void FinishEating()
        {
            CurrentState.BowEmpty(); Console.WriteLine($"His majesty is {CurrentState.GetType().Name}");
        }
        public void CompletePlan()
        {
            CurrentState.WolBeware(); Console.WriteLine($"His majesty is {CurrentState.GetType().Name}");

        }
    }

    public class Contemplating : CatState
    {
        private Cat cat;

        public Contemplating(Cat cat) : base(cat) { }
        public override void WolBeware()
        {
            Console.WriteLine("the plan is complete , but first .... a nap.");
            this.Handle.CurrentState = new Sleeping(this.Handle);
        }
    }

    public class Eating : CatState
    {
        private int amount;
        private int happywith;

        public Eating(Cat cat, int amount, int happywith) : base(cat)
        {
            this.amount = amount;
            this.happywith = happywith;
        }
        public override void BowEmpty()
        {
            if (amount >= happywith)
            {
                Console.WriteLine("The feas was acceptabe. Bring the royal cushion");
                this.Handle.CurrentState = new Sleeping(this.Handle);
            }
            else
            {
                Console.WriteLine("Human, you lack of preparation has dooomed all making");
                this.Handle.CurrentState = new Contemplating(this.Handle);
            }
        }
    }

    public class Sleeping : CatState
    {


        public Sleeping(Cat handle) : base(handle)
        {
        }
        public override void GetFed(int amount, int happywith)
        {
            Console.WriteLine("aaaaha, my tribute has arrived");
            this.Handle.CurrentState = new Eating(this.Handle, amount, happywith);
        }
    }
}