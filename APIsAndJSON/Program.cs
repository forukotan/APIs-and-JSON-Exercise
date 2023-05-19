using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
          for (int i = 0; i < 5; i++)
          {
             Quotes.KanyeQuote();
             Quotes.RonQuote();
          }

          var client = new HttpClient();
           Console.WriteLine("Please enter your api key");
           var api_Key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Please enter a city name:");
                var city_name = Console.ReadLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";
                var response =client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to pick a different city?");
                var userinput = Console.ReadLine();

                if(userinput.ToLower() =="no" )
                {
                    break;
                }

                
              
            }

        }
    }
}
