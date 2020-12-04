using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            RunPart1(passports);
            RunPart2(passports);
        }

        public static void RunPart1(string[] passports)
        {
            var validPassports = passports.Count(p => _fields.All(p.Contains));

            Console.WriteLine($"Valid passports: {validPassports}");
        }

        public static void RunPart2(string[] passportText)
        {
            var passports = passportText.Select(p => new Passport(p));
            var validPassports = passports.Count(p => p.IsValid());

            Console.WriteLine($"Valid passports: {validPassports}");
        }

        public class Passport
        {
            public Passport(string data)
            {
                var tokens = data.Split(new [] {Environment.NewLine, " "}, StringSplitOptions.RemoveEmptyEntries);
                var dictionary = tokens.ToDictionary(k => k.Substring(0, 3), v => v.Substring(4));

                BirthYear = dictionary.GetValueOrDefault("byr");
                IssueYear = dictionary.GetValueOrDefault("iyr");
                ExpirationYear = dictionary.GetValueOrDefault("eyr");
                Height = dictionary.GetValueOrDefault("hgt");
                HairColor = dictionary.GetValueOrDefault("hcl");
                EyeColor = dictionary.GetValueOrDefault("ecl");
                PassportId = dictionary.GetValueOrDefault("pid");
            }

            [Required]
            [Range(1920, 2002)]
            public string BirthYear { get; set; }

            [Required]
            [Range(2010, 2020)]
            public string IssueYear { get; set; }

            [Required]
            [Range(2020, 2030)]
            public string ExpirationYear { get; set; }

            [Required]
            [RegularExpression("^((1[5-8]{1}[0-9]{1}|19[0-3]{1})cm)|((59|6[0-9]{1}|7[0-6]{1})in)$")]
            public string Height { get; set; }

            [Required]
            [RegularExpression("^#[0-9a-f]{6}$")]
            public string HairColor { get; set; }

            [Required]
            [RegularExpression("^amb|blu|brn|gry|grn|hzl|oth$")]
            public string EyeColor { get; set; }

            [Required]
            [MinLength(9)]
            [MaxLength(9)]
            public string PassportId { get; set; }

            public bool IsValid()
            {
                var ctx = new ValidationContext(this);
                var results = new List<ValidationResult>();
                return Validator.TryValidateObject(this, ctx, results, true);
            }
        }
    }
}
