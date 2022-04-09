using System;

namespace State3
{
    public class Switch
    {
        public State3 State = new OffState();
        public void On() { State.On(this); }
        public void Off() { State.Off(this); }
    }
    public abstract class State3
    {
        public virtual void On(Switch @switch)
        {
            Console.WriteLine("light is already on .");

        }
        public virtual void Off(Switch @switch)
        {
            Console.WriteLine("lisght is already off.") ;
        }
    }
    public class OnState: State3
    {
        public OnState()
        {
            Console.WriteLine("Light turnded on");
        }
        public override void Off(Switch @switch)
        {
            Console.WriteLine("Turning light off....");
            @switch.State = new OffState();
        }
    }
    public class OffState : State3
    {
        public OffState()
        {
            Console.WriteLine("Light turned off.");
        }
        public override void On(Switch @switch)
        {
            Console.WriteLine("Turning light on....");
            @switch.State = new OnState();
        }
    }
}