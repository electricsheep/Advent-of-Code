using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public class Day04
    {
        private static string[] _fields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public static void Run()
        {
            var text = File.ReadAllText($"{AppContext.BaseDirectory}/4.txt");
            var passports = text.Split($"{Environment.NewLine}{Environment.NewLine}");
            var validPassports = passports.Count(p => _fields.All(p.Contains));

            Console.WriteLine($"Valid passports: {validPassports}");
        }
    }
}
