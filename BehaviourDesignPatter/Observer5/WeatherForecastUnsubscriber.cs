using System;
using System.Collections.Generic;

namespace Observer5
{
    public class WeatherForecastUnsubscriber : Unsubscriber<WeatherInfo>
    {
        public WeatherForecastUnsubscriber(
            List<IObserver<WeatherInfo>> observers,
            IObserver<WeatherInfo> observer) : base(observers, observer)
        {
        }
    }
}