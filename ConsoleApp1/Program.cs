using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

class Program
{
    static void Main()
    {
        string city = "Lviv";
        var WeatherService = new WeatherService();
        WeatherService.GetWeatherAsync(city);

        //while (true)
        //{
        //    Console.WriteLine("The Weather Cheker");
        //    Console.WriteLine("Enter your city:");
        //    //string city = Console.ReadLine();
        //    Console.WriteLine(city);



        //    Console.WriteLine("Do you want to check another city? (yes/no)");
        //    string response = Console.ReadLine().Trim().ToLower();




        //    if (response == "no")
        //    {
        //        Console.WriteLine("Goodbye!");
        //        break;
        //    }

        //    if (response != "yes")
        //    {
        //        continue;
        //    }
        //}
    }
}

