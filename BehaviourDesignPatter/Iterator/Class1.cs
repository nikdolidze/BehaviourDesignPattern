using System;
using System.Collections.Generic;
using System.Linq;
/*
its intent is to provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation
*/
namespace Iterator
{
    public class Person
    {
        public string Country { get; set; }
        public string Name { get; set; }

        public Person(string country, string name)
        {
            Country = country;
            Name = name;
        }
    }
    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }
    }
    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CrateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    internal class PeopleIterator : IPeopleIterator
    {
        private PeopleCollection _people;   
        private int _current;
        public PeopleIterator(PeopleCollection peopleCollection)
        {
            _people = peopleCollection;
        }

        public Person CurrentItem
        {
            get
            {
                return _people.OrderBy(x=>x.Name).ToList()[_current];
            }
        }

        public Person First()
        {
            _current = 0;
            return _people.OrderBy(x=>x.Name).ToList()[_current];
        }
        public bool IsDone
        {
            get { return _current >= _people.Count; }
          
        }

        public Person Next()
        {
            if (IsDone)
            {
                _current++;
                return _people.OrderBy(x => x.Name).ToList()[_current];
            }
            else
            {
                return null;
            }
          
        }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CrateIterator();
    }
}
