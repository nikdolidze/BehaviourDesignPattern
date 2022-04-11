using System;
using System.Collections.Generic;
/*
The main intent of this pattern is to define a one to many dependency between objects, so that when one object  changes its state, all objects dependent on it are notified automtically

*/
namespace Observer3
{
    public class Subject : IObservable<User3>, IDisposable // the main object whose state changei s what we are interested
    {
        public readonly User3 user;
        private IList<IObserver<User3>> observers = new List<IObserver<User3>>();
        public Subject(string name, int age)
        {
            user = new User3() { Age = age, Name = name };
        }

        public IDisposable Subscribe(IObserver<User3> observer)
        {
            this.observers.Add(observer);
            observer.OnNext(user);
            return this;
        }

        public void UpdateUserAge(int age)
        {
            user.Age = age;
            foreach (var item in observers)
            {
                item.OnNext(user);
            }

        }

        public void Dispose()
        {
            observers.Clear();
        }
    }

    public class Test
    {
        public Test(ISubject subject)
        {
            subject.UserChanged += Subject_UserChanged;
        }

        private void Subject_UserChanged(User3 obj)
        {
            Console.WriteLine($"Name  test : {obj.Name} Age test : {obj.Age}");
        }
    }

    public class Observerr3 : IObserver<User3> //are interested int state change of the subject
    {


        public void OnCompleted()
        {
            Console.WriteLine("Compleagted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error");
        }

        public void OnNext(User3 value)
        {
            Console.WriteLine("Name is " + value.Name + " Age is "+value.Age);
        }


    }


    public class User3//state
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
