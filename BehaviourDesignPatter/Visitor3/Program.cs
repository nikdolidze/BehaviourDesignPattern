using System;

namespace Visitor3
{
   public interface IInsurance
    {
        void Accept(IVisitor visitor);
    }
    public interface IVisitor
    {
        void VisitCarInsurance(CarInsurance carInsurance);
        void VisitMotorBikeInsurance(MotorBikeInsurance motorBikeInsurance);
    }
    public class QuoteVisitor : IVisitor
    {
        public void VisitCarInsurance(CarInsurance carInsurance)
        {
            Console.WriteLine($"Get Quote for Car as the element is {carInsurance.GetType()}");
        }

        public void VisitMotorBikeInsurance(MotorBikeInsurance motorBikeInsurance)
        {
            Console.WriteLine($"Get Quote for moto as the element is {motorBikeInsurance.GetType()}");
        }
    }
    public class CustomerCommunicationVisitor : IVisitor
    {
        public void VisitCarInsurance(CarInsurance carInsurance)
        {
            Console.WriteLine($"Email is sent as the element class is  {carInsurance.GetType()}");
        }

        public void VisitMotorBikeInsurance(MotorBikeInsurance motorBikeInsurance)
        {
            Console.WriteLine($"Sms is sent as the element class is  {motorBikeInsurance.GetType()}");

        }
    }

    public class CarInsurance : IInsurance
    {
        public string RegistrationNumber { get; set; }
        public string PostCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int EngineCC { get; set; }
        public bool IsLeftHandDrive { get; set; }
        public bool IsModified { get; set; }

        public void Accept(IVisitor visitor)
        {
           visitor.VisitCarInsurance(this);
        }
    }
    public class MotorBikeInsurance : IInsurance
    {
        public string RegistrationNumber { get; set; }
        public string PostCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int EngineCC { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitMotorBikeInsurance(this);
        }
    }
}
