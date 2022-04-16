using System;

namespace Observer5
{
    public class WeatherInfo
    {
        public WeatherInfo(double temperature)
        {
            Temperature = temperature;
        }

        public double Temperature { get; }
    }
}
