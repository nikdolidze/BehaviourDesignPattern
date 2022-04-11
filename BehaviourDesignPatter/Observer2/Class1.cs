using System;
using System.Collections.Generic;

namespace Observer2
{

    public class Alarm
    {
        List<IWatcher<Alarm>> watchers = new();
        public void AddWatcher(IWatcher<Alarm> alarmWatcher)
        {
            watchers.Add(alarmWatcher);
        }

        public void Notify()
        {
            foreach (var w in watchers)
            {
                w.Alert(this);
            }
        }
    }

    public interface IWatcher<T>
    {
        public void Alert(T value);
    }

    public class FireStation : IWatcher<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine(nameof(FireStation) + " RESPONDING!");
        }
    }

    public class PoliceStation : IWatcher<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine(nameof(PoliceStation) + " RESPONDING!");
        }
    }

    public class HospitalStation : IWatcher<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine(nameof(HospitalStation) + " RESPONDING!");
        }
    }

}
