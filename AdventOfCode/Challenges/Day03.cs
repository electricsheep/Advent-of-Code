using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public class Day03
    {
        public static void Run()
        {
            var lines = File.ReadAllLines($"{AppContext.BaseDirectory}/3.txt");
            var map = lines.Select(x => x.ToCharArray()).ToArray();

            RunPart1(map);
            RunPart2(map);
        }

        private static void RunPart1(char[][] map)
        {
            var treeCount = CountTrees(map, 3, 1);

            Console.WriteLine($"Part1: Total trees: {treeCount}");
        }

        private static void RunPart2(char[][] map)
        {
            var treeCount = CountTrees(map, 1, 1)
                            * CountTrees(map, 3, 1)
                            * CountTrees(map, 5, 1)
                            * CountTrees(map, 7, 1)
                            * CountTrees(map, 1, 2);

            Console.WriteLine($"Part 2: Total trees: {treeCount}");
        }

        private static long CountTrees(char[][] map, int xInc, int yInc)
        {
            var treeCount = 0;

            for (int x = 0, y = 0; y < map.Length; x = (x + xInc) % map[0].Length, y += yInc)
            {
                if (map[y][x] == '#') treeCount++;
            }

            return treeCount;
        }
    }
}
