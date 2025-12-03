using System.Net;
using System.Text.Json;

public class WeatherService
{
    public async Task<string> GetWeatherAsync(string city, string apiKey)
    {
        string baseUrl = "https://api.openweathermap.org/data/2.5";
        string url = baseUrl + "/weather?q=" + city + "&appid=" + apiKey + "&units=metric";
        using HttpClient client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return "Error 404 — City not found";
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return "Error 401 — Unauthorized, no access";
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError) 
            {
                return "Error 500 — Server problem";
            }
            else if (response.IsSuccessStatusCode) // 200–299
            {
                string json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                WeatherResponse? data = JsonSerializer.Deserialize<WeatherResponse>(json, options);

                if (data == null || data.main == null || data.weather == null || data.weather.Length == 0)
                {
                    return "Weather data format is unexpected.";
                }

                double temp = data.main.temp;
                string description = data.weather[0].description;
                string cityName = string.IsNullOrWhiteSpace(data.name) ? city : data.name;

                return $"Weather in {cityName}: {temp}°C, {description}";
            }
            return "Other status code: " + (int)response.StatusCode;
        }

        catch (HttpRequestException ex)
        {
       
            return "Network error. Please check your internet connection and try again.";
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Request timeout: " + ex.Message);
            return "The request took too long. Please try again later.";
        }

        
    }
}
