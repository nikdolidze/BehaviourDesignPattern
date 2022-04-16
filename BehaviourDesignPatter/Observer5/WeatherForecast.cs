using System;
using System.Collections.Generic;

namespace Observer5
{

    public class WeatherForecast : IObservable<WeatherInfo>
    {
        private readonly List<IObserver<WeatherInfo>> m_Observers;
        private readonly List<WeatherInfo> m_WeatherInfoList;

        public WeatherForecast()
        {
            m_Observers = new List<IObserver<WeatherInfo>>();
            m_WeatherInfoList = new List<WeatherInfo>();
        }

        public IDisposable Subscribe(IObserver<WeatherInfo> observer)
        {
            if (!m_Observers.Contains(observer))
            {
                m_Observers.Add(observer);

                foreach (var item in m_WeatherInfoList)
                {
                    observer.OnNext(item);
                }
            }

            return new WeatherForecastUnsubscriber(m_Observers, observer);
        }

        public void RegisterWeatherInfo(WeatherInfo weatherInfo)
        {
            m_WeatherInfoList.Add(weatherInfo);

            foreach (var observer in m_Observers)
            {
                observer.OnNext(weatherInfo);
            }
        }

        public void ClearWeatherInfo()
        {
            m_WeatherInfoList.Clear();
        }
    }
}
