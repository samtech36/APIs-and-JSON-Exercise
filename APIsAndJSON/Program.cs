using System;
using System.Net.Http;
using System.Net.Security;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
           var client = new HttpClient();
           var quote = new QuoteGenerator(client);
           var appsettingsText = File.ReadAllText("appsettings.json");
           string apiKey = JObject.Parse(appsettingsText)["key"].ToString();
           var weather = new OpenWeatherMapAPI();


           Console.WriteLine("Hello. If you like to check the weather or view a conversation, select the options: ");
           Console.WriteLine("Enter 1 or 2");
           Console.WriteLine("1. Check the weather");
           Console.WriteLine("2. view a conversation between kanye west and ron swanson");
           int userInput = int.Parse(Console.ReadLine());

           
            //current weather forecast
           if (userInput == 1)
           {
               Console.WriteLine("Enter the city you would like to see the current temperature:  ");
               string cityName = Console.ReadLine();
               var (temp, humditiy, windSpeed) = weather.GetWeather(cityName, apiKey);
               
               Console.WriteLine($"Hello. Here are the current conditions in {cityName}.");
               Console.WriteLine($"The current temperature in {cityName} is {temp} degrees Fahrenheit.");
               Console.WriteLine($"The Humidity is {humditiy} %");
               Console.WriteLine($"The Wind Speed is {windSpeed} mph");
           }
           
           //quote generator
           else if (userInput == 2)
               for (int i = 0; i < 5; i++)
               {
                   Console.WriteLine($"Kanye: {quote.KanyeQuote()}");
                   Console.WriteLine($"Ron: {quote.RonQuote()}");
                   Console.WriteLine("-------------------------");
               }
           

        }
    }
}
