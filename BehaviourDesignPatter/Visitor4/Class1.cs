
using System;
using System.Collections.Generic;
/*
The visitor is a class that adds the extra functionalities to the elements that is visits.The visitable is a clss that 
can accept a visitor to become enriched with extra functionalities.
The act of visiting is the crutial point where theese two meet and interact.Visiting assures type safety and extensibility, by the megic
of double dispatch. in simple terms, double dispatch means thet first the visitee accept the visitor,and only
then does visitor visit in Visitee
*/
namespace Visitor4
{
    public enum AlertReport
    {
        NotAnalyzable = -1,
        LowRisk = 0,
        HighRisk = 1
    }
    public interface ISicknessAlertVisitable
    {
        AlertReport Accept(ISicknessAlertVisitor visitor);
    }
    public class XRayImage : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }
    public class EcgReading : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }
    public class BloodSample : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }
    public interface ISicknessAlertVisitor
    {
        AlertReport Visit(BloodSample blood);
        AlertReport Visit(XRayImage rtg);
        AlertReport Visit(EcgReading sample);
    }

    public class HivDetector : ISicknessAlertVisitor
    {
        public AlertReport Visit(BloodSample blood)
        {
            Console.WriteLine($"{GetType().Name} - Checking blood sample");
            //analyze the blood and return correct risk value
            return AlertReport.LowRisk;
        }
        public AlertReport Visit(XRayImage rtg)
        {
            Console.WriteLine($"{GetType().Name} - currently cannot detect HIV based on X-Ray");
            return AlertReport.NotAnalyzable;
        }
        public AlertReport Visit(EcgReading sample)
        {
            Console.WriteLine($"{GetType().Name} - Checking ECG");
            return AlertReport.HighRisk;
        }
    }
    public class CancerDetector : ISicknessAlertVisitor
    {
        public AlertReport Visit(BloodSample blood)
        {
            Console.WriteLine($"{GetType().Name} - Checking blood sample");
            return AlertReport.NotAnalyzable;
        }

        public AlertReport Visit(XRayImage rtg)
        {
            Console.WriteLine($"{GetType().Name} - Checking X-Ray");
            return AlertReport.NotAnalyzable;
        }

        public AlertReport Visit(EcgReading sample)
        {
            Console.WriteLine($"{GetType().Name} - Checking ECG");
            return AlertReport.NotAnalyzable;
        }
    }


    public class TestResultsMonitoringApp
    {
        private readonly List<ISicknessAlertVisitor> _detectors;
        public TestResultsMonitoringApp(List<ISicknessAlertVisitor> detectors)
        {
            _detectors = detectors;
        }
        public List<AlertReport> AnalyzeResultsBatch(IEnumerable<ISicknessAlertVisitable> testResults)
        {
            var alertReports = new List<AlertReport>();
            foreach (var sample in testResults)
            {
                foreach (var detector in _detectors)
                {
                    alertReports.Add(sample.Accept(detector));
                }
            }
            return alertReports;
        }
    }
}
