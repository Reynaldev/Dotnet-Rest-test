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
            List<UserLocation> location = new List<UserLocation>();

            HttpResponseMessage response;
            string content;

            // Get API content for geo data
            response = await client.GetAsync("http://api.openweathermap.org/geo/1.0/direct?q=Jakarta&limit=5&appid=18ccbbd129b7bdecaaf072a9f9977f01");
            // Convert json into string
            content = await response.Content.ReadAsStringAsync();
            // Insert data into the UserLocation class
            location = JsonSerializer.Deserialize<List<UserLocation>>(content);
            
            // Get REST API content for weather data
            response = await client.GetAsync("https://api.openweathermap.org/data/3.0/onecall?lat=33.44&lon=-94.04&appid=18ccbbd129b7bdecaaf072a9f9977f01");
            content = await response.Content.ReadAsStringAsync();
            // Insert data into the OpenWeather class
            weather = JsonSerializer.Deserialize<OpenWeather>(content);

            // Output
            Console.WriteLine("==================================");
            Console.WriteLine($"Lat: {location[0].lat}");
            Console.WriteLine($"Lon: {location[0].lon}");

            Console.WriteLine("\n==================================");
            Console.WriteLine($"Timezone: {weather.timezone}");
            Console.WriteLine($"Temp: {weather.current.temp}");
            Console.WriteLine($"Pressure: {weather.current.pressure}");
            Console.WriteLine($"Humidity: {weather.current.humidity}");
            Console.WriteLine($"Id: {weather.current.weather[0].id}");
        }
    }
}