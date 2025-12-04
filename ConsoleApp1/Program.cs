using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main()
    {
        var weatherService = new WeatherService();
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        IConfiguration config = builder.Build();
        IConfigurationSection section = config.GetSection("WeatherApi");
        string baseUrl = section["baseUrl"];
        string apiKey = section["ApiKey"];

        while (true)
        {
            Console.WriteLine("The Weather Cheker");
            Console.WriteLine("Enter your city:");
            string city = Console.ReadLine();
            string result = await weatherService.GetWeatherAsync(baseUrl, city, apiKey);
            Console.WriteLine("Service result: " + result);

            Console.WriteLine("Do you want to check another city? (yes/no)");
            string response = Console.ReadLine().Trim().ToLower();

            if (response == "no")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (response != "yes")
            {
                continue;
            }
        }
    }
}
