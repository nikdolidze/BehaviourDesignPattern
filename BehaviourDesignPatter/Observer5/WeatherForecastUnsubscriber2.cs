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
}