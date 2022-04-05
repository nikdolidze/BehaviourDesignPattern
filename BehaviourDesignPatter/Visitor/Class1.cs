using System;
using System.Collections.Generic;
/*
The intern of this pattern is to represent an operation to be performed on the elemetn of an object structure. visitor lets you define a new operation without changing the classes of 
the elements on whitch it operates.

*/
namespace Visitor
{/// <summary>
/// ConcreateElement
/// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }
        public Customer(string name, decimal amountOrder)
        {
            this.Name = name; this.AmountOrdered = amountOrder;
        }

        public void Accept(IVisitor visitor)
        {
            //  visitor.VisitCustomer(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name} , dicount given {Discount}");
        }
    }

    public class Employee : IElement
    {
        public int YearsEmployeed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }
        public Employee(string name, int yearsEmployeed)
        {
            this.Name = name; this.YearsEmployeed = yearsEmployeed;
        }

        public void Accept(IVisitor visitor)
        {
            //  visitor.VisitEmployee(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} {Name} , dicount given {Discount}");

        }
    }

    //public interface IVisitor
    //{
    //    void VisitCustomer(Customer customer);
    //    void VisitEmployee(Employee employee);
    //}
    public interface IVisitor
    {
        void Visit(IElement element);
    }
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDicsountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if (element is Employee e)
            {
                VisitEmployee(e);
            }
        }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered / 10;
            customer.Discount = discount;
            TotalDicsountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            var dicout = employee.YearsEmployeed < 10 ? 100 : 200;
            employee.Discount = dicout;
            TotalDicsountGiven += dicout;
        }
    }
    public class Containter
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach (var custimer in Customers)
            {
                custimer.Accept(visitor);
            }
        }
    }

}
