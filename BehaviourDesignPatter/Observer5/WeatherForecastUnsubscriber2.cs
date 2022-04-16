using System;

namespace Observer5
{
    public class WeatherForecastUnsubscriber2 : Unsubscriber2
    {
        public WeatherForecastUnsubscriber2(
            Action unsubscribeAction) : base(unsubscribeAction)
        {
        }
    }

    public class WeatherForecastObserver2 : IObserver<WeatherInfo>
    {
        private IDisposable m_Unsubscriber;

        public virtual void Subscribe(WeatherForecas2t provider)
        {
            m_Unsubscriber = provider.Subscribe(this, true);
        }

        public virtual void Unsubscribe()
        {
            m_Unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error");
        }

        public void OnNext(WeatherInfo value)
        {
            Console.WriteLine($"Temperature: {value.Temperature}");
        }
    }
}