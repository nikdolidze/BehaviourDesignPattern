using Observer5.ExtendedObservable;
using System;
using System.Collections.Generic;

namespace Observer5
{
    public class WeatherForecas2t : IExtendedObservable<WeatherInfo>
    {
        private readonly List<IObserver<WeatherInfo>> m_Observers;
        private readonly List<WeatherInfo> m_WeatherInfoList;

        public WeatherForecas2t()
        {
            m_Observers = new List<IObserver<WeatherInfo>>();
            m_WeatherInfoList = new List<WeatherInfo>();
        }

        public IReadOnlyCollection<WeatherInfo> Snapshot => m_WeatherInfoList;

        public IDisposable Subscribe(IObserver<WeatherInfo> observer)
        {
            return Subscribe(observer, false);
        }

        public IDisposable Subscribe(IObserver<WeatherInfo> observer, bool withHistory)
        {
            if (!m_Observers.Contains(observer))
            {
                m_Observers.Add(observer);

                if (withHistory)
                {
                    foreach (var item in m_WeatherInfoList)
                    {
                        observer.OnNext(item);
                    }
                }
            }

            return new WeatherForecastUnsubscriber2(
                () =>
                {
                    if (m_Observers.Contains(observer))
                    {
                        m_Observers.Remove(observer);
                    }
                });
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