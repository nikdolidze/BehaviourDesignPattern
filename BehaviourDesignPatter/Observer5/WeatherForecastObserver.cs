using System;

namespace Observer5
{
    public class WeatherForecastObserver : IObserver<WeatherInfo>
    {
        private IDisposable m_Unsubscriber;
        public virtual void Subscribe(WeatherForecast provider) => m_Unsubscriber = provider.Subscribe(this);
        public virtual void Unsubscribe() => m_Unsubscriber.Dispose();
        public void OnCompleted() => Console.WriteLine("Completed");
        public void OnError(Exception error) => Console.WriteLine("Error");
        public void OnNext(WeatherInfo value) => Console.WriteLine($"Temperature: {value.Temperature}");
    }
}