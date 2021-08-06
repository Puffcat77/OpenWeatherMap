using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace Task3
{
    public class WeatherProcessor
    {
        string apiKey = "3fe29a3f69a1a5f16fc52525a7e579bb";
        string cityCoordinates = "lat=59.57&lon=30.19";
        string excludeParts = "&exclude=current,minutely,hourly,alerts";
        string URL
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/onecall?" + cityCoordinates +
                    "&cnt=" + 5 + "&units=metric&appid=" + apiKey + excludeParts;
            }
        }
        public async Task<DayWeather[]> LoadWeather()
        {
            using (HttpResponseMessage response = await APIConnection.ApiClient.GetAsync(URL)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherModel model = await response.Content.ReadAsAsync<WeatherModel>();
                    return model.Daily;
                }
                else throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task GetHighestPressureAndLeastTempDiffDays()
        {
            DayWeather[] weather = await Task.Run(() => LoadWeather());
            DayWeather highestPressureDay = GetMaxPressureForNext5Days(weather);
            Console.WriteLine("Day with highest pressure is {0} starting from today." +
                "It's pressure is {1} hPa"
                , Array.IndexOf(weather, highestPressureDay)
                , highestPressureDay.Pressure);
            DayWeather smoothestDay = GetMinTempDiffDay(weather);
            Console.WriteLine("Least temprature difference is {0:0.00}°C " +
                "on day {1} starting from today.\n" +
                "It's morning temprature is {2}°C and night temprature is {3}°C."
                , smoothestDay.TempDiff
                , Array.IndexOf(weather, smoothestDay)
                , smoothestDay.Temp.Morn
                , smoothestDay.Temp.Night);
        }

        private DayWeather GetMaxPressureForNext5Days(DayWeather[] days) => days.Take(6)
                .OrderByDescending(day => day.Pressure)
                .ToList()[0];

        private DayWeather GetMinTempDiffDay(DayWeather[] days) => days.Take(6)
            .OrderBy(day => day.TempDiff)
            .ToList()[0];
    }
}
