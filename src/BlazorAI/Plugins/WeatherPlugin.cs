using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BlazorAI.Plugins
{
    public class WeatherPlugin {
        [KernelFunction("get_current_weather")]
        [Description("Returns the current weather for the given location")]
        [return: Description("The current weather for a given location.")]
        public async Task<string> GetWeatherAsync(float latitude, float longitude) {
            Console.WriteLine("Getting Current or Future Weather");
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation,rain,showers,snowfall,weather_code,wind_speed_10m,wind_direction_10m,wind_gusts_10m&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch");
                return response;
            }
        }

        [KernelFunction("get_future_weather")]
        [Description("Returns the future weather for the given parameters")]
        [return: Description("The future weather for a given location and date.")]
        public async Task<string> GetFutureWeatherAsync(float latitude, float longitude, int daysInFuture) {
            Console.WriteLine("Getting Future Weather");
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation,rain,showers,snowfall,weather_code,wind_speed_10m,wind_direction_10m,wind_gusts_10m&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&forcast_days={daysInFuture}");
                return response;
            }
        }        

        [KernelFunction("get_past_weather")]
        [Description("Returns the past weather for the given parameters")]
        [return: Description("The past weather for a given date.")]
        public async Task<string> GetPastWeatherAsync(float latitude, float longitude, int daysInPast) {
            Console.WriteLine("Getting Past Weather");
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation,rain,showers,snowfall,weather_code,wind_speed_10m,wind_direction_10m,wind_gusts_10m&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&past_days={daysInPast}");
                return response;
            }
        }        
  
    }
}