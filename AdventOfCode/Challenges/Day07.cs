using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges
{
    public class Day07
    {
        public static void Run()
        {
            var rules = File.ReadAllLines($"{AppContext.BaseDirectory}/7.txt");
            RunPart1(rules);
            RunPart2(rules);
        }

        public static void RunPart1(IEnumerable<string> rules)
        {
            var rulesDictionary = ParseRules(rules);
            var allowedColours = FindAllowedBags(rulesDictionary, "shiny gold");
            Console.WriteLine($"Allowed colours for gold: {allowedColours.Distinct().Count()}");
        }

        private static Dictionary<string, List<string>> ParseRules(IEnumerable<string> rules)
        {
            var ruleDictionary = new Dictionary<string, List<string>>();

            foreach (var rule in rules)
            {
                var parts = rule.Split(" bags contain ");
                var parentBag = parts[0];
                var childBags = parts[1].Trim('.').Split(", ").Select(x => new Bag(x)).Where(x => x.Colour != null);

                foreach (var childBag in childBags)
                {
                    if (!ruleDictionary.ContainsKey(childBag.Colour))
                    {
                        ruleDictionary.Add(childBag.Colour, new List<string>());
                    }

                    ruleDictionary[childBag.Colour].Add(parentBag);
                }
            }

            return ruleDictionary;
        }

        private static List<string> FindAllowedBags(Dictionary<string, List<string>> rulesDictionary, string key)
        {
            if (!rulesDictionary.ContainsKey(key))
            {
                return null;
            }

            var parentBags = rulesDictionary[key];
            var bagColors = new List<string>();

            foreach (var parentBag in parentBags)
            {
                bagColors.Add(parentBag);
                var allowedBags = FindAllowedBags(rulesDictionary, parentBag);
                if (allowedBags != null)
                {
                    bagColors.AddRange(allowedBags);
                }
            }

            return bagColors;
        }


        private static void RunPart2(IEnumerable<string> rules)
        {
            var rulesDictionary = ParseRules2(rules);
            var count = CountBags(rulesDictionary, "shiny gold");

            Console.WriteLine($"Bags inside shiny gold: {count}");
        }

        private static Dictionary<string, List<Bag>> ParseRules2(IEnumerable<string> rules)
        {
            var ruleDictionary = new Dictionary<string, List<Bag>>();

            foreach (var rule in rules)
            {
                var parts = rule.Split(" bags contain ");
                var parentBag = parts[0];
                var childBags = parts[1].Trim('.').Split(", ").Select(x => new Bag(x)).Where(x => x.Colour != null).ToList();

                if (childBags.Any())
                {
                    ruleDictionary.Add(parentBag, childBags);
                }
            }

            return ruleDictionary;
        }

        private static int CountBags(Dictionary<string, List<Bag>> rulesDictionary, string colour)
        {
            if (!rulesDictionary.ContainsKey(colour))
            {
                Console.WriteLine($"{colour} contains no bags");
                return 0;
            }

            var childBags = rulesDictionary[colour];
            var total = 0;

            foreach (var bag in childBags)
            {
                total += bag.Count;
                var childBagCount = CountBags(rulesDictionary, bag.Colour);
                total += childBagCount * bag.Count;
            }

            return total;
        }

        public class Bag
        {
            public Bag(string bagText)
            {
                var parts = Regex.Split(bagText, "(^[0-9]+) ([a-z ]+) bag(s)?$");
                if (parts.Length > 2)
                {
                    Count = int.Parse(parts[1]);
                    Colour = parts[2];
                }
            }

            public int Count { get; set; }
            public string Colour { get; set; }
        }
    }
}
