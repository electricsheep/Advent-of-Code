using System;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Challenges
{
    public class Two
    {
        public static async Task Run()
        {
            var lines = await FileHelper.ReadLines("2.txt");
            var validCount =
                lines.Select(line => new PasswordRule(line))
                    .Count(rule => rule.IsValid());

            Console.WriteLine($"{validCount} valid passwords");
        }

        public class PasswordRule
        {
            public PasswordRule(string rule)
            {
                var tokens = rule.Split(" ");
                var ruleTokens = tokens[0].Split("-");
                LowerLimit = int.Parse(ruleTokens[0]);
                UpperLimit = int.Parse(ruleTokens[1]);
                Letter = tokens[1][0];
                Password = tokens[2];
            }

            public int LowerLimit { get; set; }
            public int UpperLimit { get; set; }
            public char Letter { get; set; }
            public string Password { get; set; }

            public bool IsValid()
            {
                var letterCount = Password.Count(c => c == Letter);
                return letterCount >= LowerLimit && letterCount <= UpperLimit;
            }
        }
    }
}
