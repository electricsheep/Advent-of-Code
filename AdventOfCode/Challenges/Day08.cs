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
            RunPart2(instructions);
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

        public static void RunPart2(string[] instructions)
        {
            foreach (var nopInstruction in instructions.Where(x => x.Contains("nop")))
            {
                RunProgram(instructions, nopInstruction, "nop", "jmp");
            }

            foreach (var jmpInstruction in instructions.Where(x => x.Contains("jmp")))
            {
                RunProgram(instructions, jmpInstruction, "jmp", "nop");
            }
        }

        private static void RunProgram(string[] instructions, string instructionToReplace, string instructionFrom, string instructionTo)
        {
            var executedInstructions = new List<int>();
            var nextInstructionIndex = 0;
            var acc = 0;

            while (!executedInstructions.Contains(nextInstructionIndex))
            {
                if (nextInstructionIndex == instructions.Length - 1)
                {
                    Console.WriteLine("Program complete!");
                    Console.WriteLine($"Acc: {acc}");
                    return;
                }

                executedInstructions.Add(nextInstructionIndex);
                var instruction = instructions[nextInstructionIndex];
                if (instruction == instructionToReplace)
                {
                    instruction = instruction.Replace(instructionFrom, instructionTo);
                }

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
        }

        private static int ParseNumber(string signedNumber)
        {
            var sign = signedNumber[0];
            var number = int.Parse(signedNumber[1..]);

            return sign == '-' ? -1 * number : number;
        }
    }
}
