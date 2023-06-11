namespace Dotnet_Rest_test.Models
{
    public class OpenWeather
    {
        public decimal? lat { get; set; }
        public decimal? lon { get; set; }
        public string? timezone { get; set; }
        public Current? current { get; set; }
    }

    public class Current
    {
        public decimal? temp { get; set; }
        public int? pressure { get; set; }
        public int? humidity { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Weather
    {
        public int? id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }
}