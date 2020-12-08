using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public class Day06
    {
        public static void Run()
        {
            var text = File.ReadAllText($"{AppContext.BaseDirectory}/6.txt");
            var groups = text.Split($"{Environment.NewLine}{Environment.NewLine}");
            RunPart1(groups);
            RunPart2(groups);
        }

        public static void RunPart1(IEnumerable<string> groups)
        {
            var answerCounts = new Dictionary<char, int>();

            foreach (var group in groups)
            {
                foreach (var letter in group.Replace($"{Environment.NewLine}", "").Distinct())
                {
                    if (!answerCounts.ContainsKey(letter))
                    {
                        answerCounts.Add(letter, 0);
                    }
                    answerCounts[letter]++;
                }
            }

            Console.WriteLine($"Sum: {answerCounts.Values.Aggregate(0, (x, y) => x + y)}");
        }

        public static void RunPart2(IEnumerable<string> groups)
        {
            var answerCounts = new Dictionary<char, int>();

            foreach (var group in groups)
            {
                var groupSize = group.Split($"{Environment.NewLine}").Length;
                var groupedLetters = group.Replace($"{Environment.NewLine}", "").GroupBy(x => x);
                var allAnswered = groupedLetters.Where(x => x.Count() == groupSize).Select(x => x.Key);

                foreach (var letter in allAnswered)
                {
                    if (!answerCounts.ContainsKey(letter))
                    {
                        answerCounts.Add(letter, 0);
                    }
                    answerCounts[letter]++;
                }
            }

            Console.WriteLine($"Sum: {answerCounts.Values.Aggregate(0, (x, y) => x + y)}");
        }
    }
}
