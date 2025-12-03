using Microsoft.Extensions.Configuration;

public class WeatherService
{
    public async Task<string> GetWeatherAsync(string city)
    {
        string apiKey = "test_key";
        string baseUrl = "https://api.openweathermap.org/data/2.5";
        string url = baseUrl + "/weather?q=" + city + "&appid=" + apiKey + "&units=metric";
        
        
        using HttpClient client = new HttpClient();
        Console.WriteLine("Requesting URL: " + url);
        var response = await client.GetAsync(url);
        Console.WriteLine("Requesting URL: " + url);
       
        return "Ok";

    }

}
    }
}

