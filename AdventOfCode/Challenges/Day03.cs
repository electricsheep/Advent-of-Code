using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges
{
    public class Day03
    {
        public static void Run()
        {
            var lines = File.ReadAllLines($"{AppContext.BaseDirectory}/3.txt");
            var map = lines.Select(x => x.ToCharArray()).ToArray();

            RunPart1(map);
        }

        private static void RunPart1(char[][] map)
        {
            var treeCount = 0;

            for (int x = 0, y = 0; y < map.Length; x = (x + 3) % map[0].Length, y++)
            {
                Console.WriteLine($"row: {y}, col: {x}, square: {map[y][x]}");
                if (map[y][x] == '#') treeCount++;
            }

            Console.WriteLine($"Total trees: {treeCount}");
        }
    }
}
