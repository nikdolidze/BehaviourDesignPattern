using System;
using System.Collections.Generic;
/*
an observer design pattern can be used to create a one - to many relationship of objects, this relationship should be such that when one object changesthen all the other 
connected objects are notified about that change and hance they update themselves accordingly. 

//  Weather Station     subject
//  new agency          observer 
//  
*/
namespace Observer4
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public class NewsAgency : IObserver
    {
        public string Name { get; set; }

        public NewsAgency(string name)
        {
            this.Name = name;
        }
        public void Update(ISubject subject)
        {
            if (subject is WeatherStation weatherState)
            {
                Console.WriteLine(String.Format("{0} reporting temperature {1} degree ceslsus ",
                    Name,
                    weatherState.temperature));
                Console.WriteLine();
            }
        }
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public void updqteTemprature(float temprature) => this.temperature = temprature;
        public float temperature
        {
            get
            {
                return _temperature;
            }
            private set
            {
                _temperature = value;
                Notify();
            }
        }

        private float _temperature;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(observer => observer.Update(this));
        }
    }
}
