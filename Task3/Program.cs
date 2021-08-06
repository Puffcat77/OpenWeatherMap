using System;
using System.Configuration;
using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        /*
        Задача: Разработать программу, которая будет отправлять запрос к сервису прогноза погоды https://openweathermap.org/  с использованием бесплатного плана (Free, требует регистрации на сайте) и на основании полученных данных выводить следующую информацию:
        1. Максимальное давление за предстоящие 5 дней (включая текущий);
        2. День с минимальной разницей между ночной (night) и утренней 
        (morn) температурой (с указанием значения в градусах Цельсия).
        Выводить данные для Вашего города (указав либо долготу/широту, либо идентификатор города из документации сайта).
         */
        static async Task Main(string[] args)
        {
            APIConnection connection = new APIConnection();
            WeatherProcessor processor = new WeatherProcessor();
            await Task.Run(() => processor.GetHighestPressureAndLeastTempDiffDays());
        }
    }
}
