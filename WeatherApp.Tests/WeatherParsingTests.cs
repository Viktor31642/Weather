using System.Text.Json;
using Xunit;
public class WeatherParsingTests
{
    [Fact]
    public void Deserialize_ValidJson_FillsAllFields()
    {
        string json = @"{
          ""name"": ""Lviv"",
          ""main"": { ""temp"": 15.5 },
          ""weather"": [
            { ""description"": ""clear sky"" }
          ]
        }";

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        WeatherResponse? result = JsonSerializer.Deserialize<WeatherResponse>(json, options);

        Assert.NotNull(result);
        Assert.NotNull(result!.main);
        Assert.NotNull(result.weather);
        Assert.NotEmpty(result.weather);

        Assert.Equal(15.5, result.main.temp);
        Assert.Equal("clear sky", result.weather[0].description);
        Assert.Equal("Lviv", result.name);
    }
}
