
namespace TP2 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            Api openweather = new Api();

            // ----------------------------------------------------- Question 1 ---------------------------------------------


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What's the weather like in Morocco ? \n");
            Console.ForegroundColor = ConsoleColor.White;
            Morocco morocco = new Morocco();
            Root datamorocco = openweather.GetValuesBySymbol(morocco);

            Console.WriteLine($"the weather in Morocco is {datamorocco.current.weather[0].description} and the temperature is {datamorocco.current.temp} °C\n");

            // ----------------------------------------------------- Question 2 ---------------------------------------------


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("When will the sun rise and set today in Oslo ? \n");
            Console.ForegroundColor = ConsoleColor.White;
            Oslo oslo = new Oslo();
            Root dataoslo = openweather.GetValuesBySymbol(oslo);
            var sunriseoslo = ConvertFromUnixTimestamp(dataoslo.current.sunrise);
            var sunsetoslo = ConvertFromUnixTimestamp(dataoslo.current.sunset);

            Console.WriteLine($"Today in oslo, the sun rise at {sunriseoslo} and the sun set at {sunsetoslo}\n");

            // ----------------------------------------------------- Question 3 ---------------------------------------------


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" What’s the temperature in Jakarta ?\n");
            Console.ForegroundColor = ConsoleColor.White;

            Jakarta jakarta = new Jakarta();
            Root datajakarta = openweather.GetValuesBySymbol(jakarta);

            Console.WriteLine($"In Jakarta, the temperature is {datajakarta.current.temp} °C\n");

            // ----------------------------------------------------- Question 4 ---------------------------------------------


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Where is it more windy, New-York , Tokyo or Paris ?\n");
            Console.ForegroundColor = ConsoleColor.White;

            NewYork newyork = new NewYork();
            Root datanewyork = openweather.GetValuesBySymbol(newyork);

            Tokyo tokyo = new Tokyo();
            Root datatokyo = openweather.GetValuesBySymbol(tokyo);

            Paris paris = new Paris();
            Root dataparis = openweather.GetValuesBySymbol(paris);

            var maxspeed = datanewyork.current.wind_speed;
            var maxname = "New York";

            if (maxspeed < datatokyo.current.wind_speed) 
            {
                maxspeed = datatokyo.current.wind_speed;
                maxname = "Tokyo";
            }
            if (maxspeed < dataparis.current.wind_speed)
            {
                maxspeed = dataparis.current.wind_speed;
                maxname = "Paris";
            }

            Console.WriteLine($"The city which is more windy is {maxname} with a wind speed of {maxspeed}\n");

            // ----------------------------------------------------- Question 5 ---------------------------------------------

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What is the humidity and pressure like in Kiev, Moscow and Berlin ? \n");
            Console.ForegroundColor = ConsoleColor.White;

            Kiev kiev = new Kiev();
            Root datakiev = openweather.GetValuesBySymbol(kiev);

            Console.WriteLine($"In Kiev, the humidity is {datakiev.current.humidity} % and the pressure is {datakiev.current.pressure} hPa\n");

            Moscow moscow = new Moscow();
            Root datamoscow = openweather.GetValuesBySymbol(moscow);

            Console.WriteLine($"In Moscow, the humidity is {datamoscow.current.humidity} % and the pressure is {datamoscow.current.pressure} hPa\n");

            Berlin berlin = new Berlin();
            Root databerlin = openweather.GetValuesBySymbol(berlin);

            Console.WriteLine($"In Berlin, the humidity is {databerlin.current.humidity} % and the pressure is {databerlin.current.pressure} hPa\n");

            Console.ReadKey(); // I have added this command so that the terminal does not close after the . exe in the bin

        }
        static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);//on recupere la date zero de référence : le 1/1/1970 00:00:00
            return origin.AddSeconds(timestamp);//on ajoute le timestamp (nombre de secondes depuis la date zero)
        }
    }
}