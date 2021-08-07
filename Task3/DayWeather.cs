using System;

namespace Task3
{
    public class DayWeather
    {
        public TempratureModel Temp { get; set; }
        public double Pressure { get; set; }
        public double TempDiff { get { return Math.Abs(Temp.Morn - Temp.Night); } }
    }
}