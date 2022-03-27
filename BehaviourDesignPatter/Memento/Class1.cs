using System;
using System.Collections.Generic;
using System.Linq;
/*
it's all about capturing and externalizeing an objects internal state.
The intent of this pattern is to capture and externalize an object's itnernal state so that the object can be restored to this state latter,without violating encapsulation.
in other words this pattern allow us to store and restore private field and propertyvalues.
Momento stores the internal satate  of the originator.The state should be protected  against acces by other bjects as much as possible
Originator creates a Momento with a snapshot of its internal state it aslo use the Momento to restore its internal state
Caretaker keeps the Memento safe 
.
add momento class to hold the internal state of our  addemployeetomanagerlistcommand
    Pattern contequences :
    1)it preserves encapsulation
    2) simplifies originator
   
*/
namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class Manager : Employee
    {
        public List<Employee> Employees = new();
        public Manager(int id, string name) : base(id, name)
        {

        }
    }

    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int menegerId, int employeeId);
        void WriteDatabase();
    }
    //Receiver knows how to perform the operations  associated with carrying  out  a repuest
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>()
    {
        new Manager(1,"nika"),new Manager(2,"Geoff")
    };
        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int menegerId, int employeeId)
        {
            return true;
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDatabase()
        {

        }
    }
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
  //      AddEmployeeToManagerListMemento CreateMemento();
    }
    //ConcreateCommand defines a bilding between a Reciever and action. it implements Execute by invoiking ther corresponding operations on Receiver
    /// <summary>
    /// ConcraetCommand and Originator
    /// </summary>
    public class AddAmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository employeeManagerRepository;
        private  int managerId;
        private  Employee employee;
        public AddAmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee employee)
        {
            this.employeeManagerRepository = employeeManagerRepository;
            this.managerId = managerId;
            this.employee = employee;
        }

        public AddEmployeeToManagerListMemento CreateMemento() => new AddEmployeeToManagerListMemento(managerId, employee);
        public void RestoreMemento(AddEmployeeToManagerListMemento empmanagerlistmomento)
        {
            managerId = empmanagerlistmomento.ManagerId;
            employee = empmanagerlistmomento.Employee;

        }
        public bool CanExecute()
        {
            if (employee == null)
                return false;
            if (employeeManagerRepository.HasEmployee(managerId, employee.Id))
                return false;
            return true;
        }
        public void Execute()
        {
            if (employee == null)
                return;
            employeeManagerRepository.AddEmployee(managerId, employee);
        }
        public void Undo() => employeeManagerRepository.RemoveEmployee(managerId, employee);

    }
    //invoker
    /// <summary>
    /// Invoker && Caretaker
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _memento = new Stack<AddEmployeeToManagerListMemento>();
        private AddAmployeeToManagerList _command;

        public void Invoke(ICommand command)
        {
            if (_command == null)
                _command = (AddAmployeeToManagerList)command;

            if (command.CanExecute())
                command.Execute();
            _memento.Push(((AddAmployeeToManagerList)command).CreateMemento());
        }

        public void Undo()
        {
            if (_memento.Any())
                _command.RestoreMemento(_memento.Pop());
        }
    }
    /// <summary>
    /// Memento 
    /// </summary>
    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee Employee { get; private set; }

        public AddEmployeeToManagerListMemento(int managerId, Employee employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }
}
