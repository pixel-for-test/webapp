using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KolkataWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string WeatherShape { get; private set; }
        public string WeatherDescription { get; private set; }
        public string CurrentQuote { get; private set; }
        public string CurrentDateTime { get; private set; }
        public List<string> TrendingTopics { get; private set; }
        public string Temperature { get; private set; }

        private List<string> quotes = new List<string>
        {
            "The future belongs to those who believe in the beauty of their dreams. - Eleanor Roosevelt",
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "Strive not to be a success, but rather to be of value. - Albert Einstein",
            "The mind is everything. What you think you become. - Buddha"
        };

        public void OnGet()
        {
            // --- Weather Information ---
            // In a real application, this would come from a weather API.
            // Based on the information gathered, it's currently raining in Kolkata.
            var currentWeather = "Rainy"; 
            Temperature = "28°C";

            WeatherDescription = $"The current weather in Kolkata is {currentWeather}.";

            // Set the visual shape based on the weather
            switch (currentWeather.ToLower())
            {
                case "rainy":
                    // Using an SVG for a rain cloud icon
                    WeatherShape = @"<svg class='w-24 h-24 text-blue-400' fill='none' stroke='currentColor' viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'><path stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M3 15a4 4 0 004 4h9a5 5 0 10-.1-9.999 5.002 5.002 0 10-9.78 2.096A4.001 4.001 0 003 15zM12 19l-2-2m0 0l2-2m-2 2h4m-2 2l2-2'></path></svg>";
                    break;
                case "sunny":
                    // SVG for a sun icon
                    WeatherShape = @"<svg class='w-24 h-24 text-yellow-400' fill='none' stroke='currentColor' viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'><path stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707M16 12a4 4 0 11-8 0 4 4 0 018 0z'></path></svg>";
                    break;
                case "cloudy":
                    // SVG for a cloud icon
                    WeatherShape = @"<svg class='w-24 h-24 text-gray-400' fill='none' stroke='currentColor' viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'><path stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M3 15a4 4 0 004 4h9a5 5 0 10-.1-9.999A5.002 5.002 0 1012 5.001 5.002 5.002 0 003 15z'></path></svg>";
                    break;
                default:
                    // A default shape
                    WeatherShape = @"<div class='w-24 h-24 bg-gray-300 rounded-full'></div>";
                    break;
            }

            // --- Quote of the Moment ---
            var random = new Random();
            int index = random.Next(quotes.Count);
            CurrentQuote = quotes[index];

            // --- Date and Time ---
            // This will display the server's time. For accurate Kolkata time, a timezone library would be needed.
            CurrentDateTime = DateTime.Now.ToString("F");

            // --- Trending Topics in Kolkata ---
            // In a real-world scenario, this data would be fetched from a news API or a web scraper.
            TrendingTopics = new List<string>
            {
                "Speculation over electoral roll revision in West Bengal.",
                "A giraffe cub has been born at Alipore Zoological Garden.",
                "KMC intensifies its anti-malaria drive in central Kolkata.",
                "Bengal is making strides towards the elimination of Hepatitis B.",
                "The city is experiencing heavy monsoon rainfall."
            };
        }
    }
}
