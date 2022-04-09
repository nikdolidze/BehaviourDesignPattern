using System;

namespace StateMachine
{
    public class Car
    {
        public enum StateCar
        {
            Stopped, Started, Running
        }
        public enum Action
        {
            Stop, Start, Accelarate
        }

        private StateCar state = StateCar.Stopped;
        public StateCar CurrentState { get { return state; } }

        public void TakeAction(Action action)
        {
            state = (state, action) switch

            {
                (StateCar.Stopped, Action.Start) => StateCar.Started,
                (StateCar.Started, Action.Accelarate) => StateCar.Running,
                (StateCar.Started, Action.Stop) => StateCar.Stopped,
                (StateCar.Running, Action.Stop) => StateCar.Stopped,
                _ => state 
            };
        }
    }
}
