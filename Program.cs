using System.Text.Json;
using System.Text.Json.Serialization;
using Dotnet_Rest_test.Models;

namespace Dotnet_Rest_test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            string appId = DotEnv.Load(dotenv);

            // Initialize OpenWeather class
            OpenWeather _weather = new OpenWeather();
            // Initialize HttpClient class
            HttpClient _client = new HttpClient();
            List<UserLocation> _location = new List<UserLocation>();

            HttpResponseMessage _response;
            string _content;

            // Get API content for geo data
            _response = await _client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q=Jakarta&limit=5&appid={appId}");
            // Convert json into string
            _content = await _response.Content.ReadAsStringAsync();
            // Insert data into the UserLocation class
            _location = JsonSerializer.Deserialize<List<UserLocation>>(_content);
            
            // Get REST API content for weather data
            _response = await _client.GetAsync($"https://api.openweathermap.org/data/3.0/onecall?lat=33.44&lon=-94.04&appid={appId}");
            _content = await _response.Content.ReadAsStringAsync();
            // Insert data into the OpenWeather class
            _weather = JsonSerializer.Deserialize<OpenWeather>(_content);

            // Output
            Console.WriteLine("==================================");
            Console.WriteLine($"Lat: {_location[0].lat}");
            Console.WriteLine($"Lon: {_location[0].lon}");

            Console.WriteLine("\n==================================");
            Console.WriteLine($"Timezone: {_weather.timezone}");
            Console.WriteLine($"Temp: {_weather.current.temp}");
            Console.WriteLine($"Pressure: {_weather.current.pressure}");
            Console.WriteLine($"Humidity: {_weather.current.humidity}");
            Console.WriteLine($"Id: {_weather.current.weather[0].id}");
        }
    }
}