using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
/*
It allows as to encapsulate request as objects. 
The intent of pattern is to encapsulate a request as an object, thereby letting  you parametrize clients with different request, queue or log request, and support
undoable operations

Use CASES : 
        1.When you whant to parameterize objects with an action to perform(we turnd an action into standalone object with we can pass around.
        2.When you want to suppor unod
        3.When you want to specify, queue and execute request ar different times. The lifetime of the command object can be independent of that original request
        4.When you whant  to store a list of changes to pottentialy reapply later on.
Pattern concencueces :
        1.it decouples the class that invokes the operation from the one  that knows how to perform it 'Single reponsibility'
        2.The command can be manipulated and extended any other object.
        3.Command can be  assembled into a composite command
        4.Existing implementation dont have to be changed to add new commands 
*/
namespace Command
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
    }
    //ConcreateCommand defines a bilding between a Reciever and action. it implements Execute by invoiking ther corresponding operations on Receiver
    public class AddAmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository employeeManagerRepository;
        private readonly int managerId;
        private readonly Employee employee;
        public AddAmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee employee)
        {
            this.employeeManagerRepository = employeeManagerRepository;
            this.managerId = managerId;
            this.employee = employee;
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
    public class CommandManager
    {
        private readonly Stack<ICommand> _commnads = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
                command.Execute();
            _commnads.Push(command);
        }

        public void Undo()
        {
            if (_commnads.Any())
                _commnads.Pop()?.Undo();
        }
    }
}
