using System.Text.Json;
using System.Text.Json.Serialization;
using Dotnet_Rest_test.Models;

namespace Dotnet_Rest_test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize OpenWeather class
            OpenWeather weather = new OpenWeather();
            // Initialize HttpClient class
            HttpClient client = new HttpClient();

            // Get REST API content
            var response = await client.GetAsync("https://api.openweathermap.org/data/3.0/onecall?lat=33.44&lon=-94.04&appid=18ccbbd129b7bdecaaf072a9f9977f01");
            // Convert json into string
            string result = await response.Content.ReadAsStringAsync();
            // Insert data into the OpenWeather class
            weather = JsonSerializer.Deserialize<OpenWeather>(result);

            // Output
            Console.WriteLine($"Temp: {weather.current.temp}");
            Console.WriteLine($"Pressure: {weather.current.pressure}");
            Console.WriteLine($"Humidity: {weather.current.humidity}");
        }
    }
}