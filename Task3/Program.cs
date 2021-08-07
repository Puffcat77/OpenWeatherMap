using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            APIConnection connection = new APIConnection();
            WeatherProcessor processor = new WeatherProcessor();
            await Task.Run(() => processor.GetHighestPressureAndLeastTempDiffDays());
        }
    }
}