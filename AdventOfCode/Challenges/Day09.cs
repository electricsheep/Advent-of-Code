using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public class Day09
    {
        public static void Run()
        {
            var numbers = File.ReadAllLines($"{AppContext.BaseDirectory}/9.txt");
            RunPart1(numbers.Select(long.Parse).ToList());
        }

        public static void RunPart1(List<long> numbers)
        {
            const int take = 25;
            var skip = 0;
            var index = 25;

            while (skip < numbers.Count - 25)
            {
                var previousNumbers = numbers.Skip(skip).Take(take).ToList();
                var current = numbers[index];

                if (HasSum(previousNumbers, current))
                {
                    index++;
                    skip++;
                }
                else
                {
                    Console.WriteLine($"no sum found for {current}");
                    break;
                }
            }
        }

        private static bool HasSum(List<long> preamble, long number)
        {
            var dictionary = preamble.ToDictionary(x => x, x => x);

            return dictionary.Select(item => number - item.Value).Any(otherNumber => dictionary.ContainsKey(otherNumber));
        }
    }
}
