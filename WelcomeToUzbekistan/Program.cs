using Newtonsoft.Json;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WelcomeToUzbekistan.Entities.Places;
using WelcomeToUzbekistan.Entities.Regions;
using WelcomeToUzbekistan.WelcomeToUzbekistan;

namespace WelcomeToUzbekistan
{
    class Program
    {
        static async Task Main()
        {
            var uzbekistan = new Uzbekistan();
            await uzbekistan.Run();

            var regionSelectionPrompt = new SelectionPrompt<Entities.Regions.Region>();
            regionSelectionPrompt.Title("Select a region:")
                .AddChoices(uzbekistan.Regions)
                .UseConverter(region => region != null ? region.Name : "Exit");

            var keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new FigletText("* Historical Places *")
                        .LeftJustified()
                        .Color(Color.Green));
                Console.WriteLine();

                var selectedRegion = AnsiConsole.Prompt(regionSelectionPrompt);
                if (selectedRegion == null)
                {
                    keepRunning = false;
                    continue;
                }

                var historicalPlaces = await uzbekistan.GetHistoricalPlacesByRegion(selectedRegion.Id);
                Console.WriteLine($"Historical Places in {selectedRegion.Name}:");
                foreach (var historicalPlace in historicalPlaces)
                {
                    Console.WriteLine(historicalPlace.Name);
                    Console.WriteLine();
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}