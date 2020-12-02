using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Challenges
{
    public class One
    {
        public static async Task Run()
        {
            var lines = await FileHelper.ReadLines("1.txt");
            var dictionary = lines.ToDictionary(int.Parse, int.Parse);

            RunPart1(dictionary);
            RunPart2(dictionary);
        }

        private static void RunPart1(Dictionary<int, int> dictionary)
        {
            var numbers = FindNumberForSum(dictionary, 2020);
            if (numbers != null)
            {
                Console.WriteLine($"Found a match: {numbers.Value.Item1} and {numbers.Value.Item2}");
                Console.WriteLine($"Sum is {numbers.Value.Item1 * numbers.Value.Item2}");
                return;
            }

            Console.WriteLine("No matches found");
        }

        private static void RunPart2(Dictionary<int, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                var subSum = 2020 - item.Value;
                var numbers = FindNumberForSum(dictionary, subSum);
                if (numbers != null)
                {
                    Console.WriteLine($"Found a match: {item.Value} and {numbers.Value.Item1} and {numbers.Value.Item2}");
                    Console.WriteLine($"Sum is {item.Value * numbers.Value.Item1 * numbers.Value.Item2}");
                    return;
                }
            }

            Console.WriteLine("No matches found");
        }

        private static (int, int)? FindNumberForSum(Dictionary<int, int> dictionary, int sum)
        {
            foreach (var item in dictionary)
            {
                var otherNumber = sum - item.Value;

                if (dictionary.ContainsKey(otherNumber))
                {
                    return (item.Value, otherNumber);
                }
            }

            return null;
        }
    }
}
