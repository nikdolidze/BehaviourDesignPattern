using System;
/*
 The main intetn of this pattern is to avoid coupling between the sender and    of a request and from its receiver by giving more than one object a chance to handle this
like all the behaviour design pattern the main intent of behaviour design pattern is to focus on object rather composition rather than inharitance.
way it woeks for chain resposibility pattern is instead of one class handling the request we devide the request into multiple handler   based onthe situation the handler
decide whether to propagatethe request to the next level or not 
 */
namespace ChainOfResposibility4
{
    public record ExpenseReport(string name, int Amount);

    public interface IManager
    {
        void SerSuperviser(IManager manager);
        void ApprovedRequst(ExpenseReport expenseReport);
    }

    public class SeniorManager : IManager
    {
        private IManager manager;

        public void ApprovedRequst(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 500)
                Console.WriteLine("Approved by manager");
            else
                manager?.ApprovedRequst(expenseReport);
        }

        public void SerSuperviser(IManager manager)
        {
            this.manager = manager;
        }
    }
    public class VicePresitend : IManager
    {
        private IManager _manager;
        public void ApprovedRequst(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 1000)
                Console.WriteLine("Approved by Vp");
            else
                _manager?.ApprovedRequst(expenseReport);
        }

        public void SerSuperviser(IManager manager)
        {
            this._manager = manager;
        }
    }
    public class COO : IManager
    {
        private IManager manager1;
        public void ApprovedRequst(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 5000) Console.WriteLine("approves by co");
            else manager1?.ApprovedRequst(expenseReport);
        }

        public void SerSuperviser(IManager manager)
        {
            this.manager1 = manager;
        }
    }
}
