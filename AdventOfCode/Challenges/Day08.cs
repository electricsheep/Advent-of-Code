using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges
{
    public class Day08
    {
        public static void Run()
        {
            var instructions = File.ReadAllLines($"{AppContext.BaseDirectory}/8.txt");
            RunPart1(instructions);
        }

        public static void RunPart1(string[] instructions)
        {
            var executedInstructions = new List<int>();
            var nextInstructionIndex = 0;
            var acc = 0;
            while (!executedInstructions.Contains(nextInstructionIndex))
            {
                executedInstructions.Add(nextInstructionIndex);
                var instruction = instructions[nextInstructionIndex];
                var parts = instruction.Split(" ");

                switch (parts[0])
                {
                    case "acc":
                        acc += ParseNumber(parts[1]);
                        nextInstructionIndex++;
                        break;
                    case "nop":
                        nextInstructionIndex++;
                        break;
                    case "jmp":
                        nextInstructionIndex += ParseNumber(parts[1]);
                        break;
                }
            }

            Console.WriteLine($"Acc: {acc}");
        }

        private static int ParseNumber(string signedNumber)
        {
            var sign = signedNumber[0];
            var number = int.Parse(signedNumber[1..]);

            return sign == '-' ? -1 * number : number;
        }
    }
}
