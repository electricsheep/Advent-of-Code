using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class One
    {
        public static async Task Run()
        {
            using var file = File.OpenText($"{AppContext.BaseDirectory}/1.txt");
            var text = await file.ReadToEndAsync();
            var lines = text.Split(Environment.NewLine);
            var dictionary = lines.ToDictionary(int.Parse, int.Parse);

            foreach (var item in dictionary)
            {
                var otherNumber = 2020 - item.Value;

                if (dictionary.ContainsKey(otherNumber))
                {
                    Console.WriteLine($"Found a match: {item.Value} and {otherNumber}");
                    Console.WriteLine($"Sum is {item.Value * otherNumber}");
                    return;
                }
            }

            Console.WriteLine("No matches found");
        }
    }
}
