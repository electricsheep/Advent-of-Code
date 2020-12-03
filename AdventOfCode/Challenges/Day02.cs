using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges
{
    public class Day02
    {
        public static async Task Run()
        {
            var lines = await File.ReadAllLinesAsync($"{AppContext.BaseDirectory}/2.txt");
            RunPart1(lines);
            RunPart2(lines);
        }

        private static void RunPart1(string[] lines)
        {
            var validCount =
                lines.Select(line => new Part1PasswordRule(line))
                    .Count(rule => rule.IsValid());

            Console.WriteLine($"{validCount} valid passwords for part 1");
        }

        private static void RunPart2(string[] lines)
        {
            var validCount =
                lines.Select(line => new Part2PasswordRule(line))
                    .Count(rule => rule.IsValid());

            Console.WriteLine($"{validCount} valid passwords for part 2");
        }

        public class PasswordRule
        {
            protected PasswordRule(string rule)
            {
                var tokens = rule.Split(" ");
                var ruleTokens = tokens[0].Split("-");
                FirstNumber = int.Parse(ruleTokens[0]);
                SecondNumber = int.Parse(ruleTokens[1]);
                Letter = tokens[1][0];
                Password = tokens[2];
            }

            public int FirstNumber { get; set; }
            public int SecondNumber { get; set; }
            public char Letter { get; set; }
            public string Password { get; set; }
        }

        public class Part1PasswordRule : PasswordRule
        {
            public Part1PasswordRule(string rule)
                : base(rule)
            {
            }

            public virtual bool IsValid()
            {
                var letterCount = Password.Count(c => c == Letter);
                return letterCount >= FirstNumber && letterCount <= SecondNumber;
            }
        }

        public class Part2PasswordRule : PasswordRule
        {
            public Part2PasswordRule(string rule)
                : base(rule)
            {
            }

            public virtual bool IsValid()
            {
                var letterCount = 0;
                if (Password.ElementAt(FirstNumber - 1) == Letter)
                {
                    letterCount++;
                }

                if (Password.ElementAt(SecondNumber - 1) == Letter)
                {
                    letterCount++;
                }

                return letterCount == 1;
            }
        }
    }
}
