using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public class Day05
    {
        public static void Run()
        {
            var seats = File.ReadAllLines($"{AppContext.BaseDirectory}/5.txt");
            RunPart1(seats);
            RunPart2(seats);
        }

        public static void RunPart1(string[] seats)
        {
            var seatNumbers = ConvertSeatsToBinary(seats);

            var highestSeat = seatNumbers.OrderByDescending(x => x).First();
            Console.WriteLine($"Highest id: {highestSeat}");
        }

        public static void RunPart2(string[] seats)
        {
            var orderedSeats = ConvertSeatsToBinary(seats).OrderBy(x => x).ToList();
            var lastSeat = orderedSeats.First();

            foreach (var seat in orderedSeats.Skip(1))
            {
                if (seat != lastSeat + 1)
                {
                    Console.WriteLine($"Gap between {lastSeat} and {seat}");
                }

                lastSeat = seat;
            }
        }

        private static IEnumerable<int> ConvertSeatsToBinary(IEnumerable<string> seats)
        {
            var seatNumbers = new List<int>();

            foreach (var seat in seats)
            {
                var binary = seat.Select(x => (x == 'B' || x == 'R') ? '1' : '0').ToArray();
                seatNumbers.Add(Convert.ToInt32(new string(binary), 2));
            }

            return seatNumbers;
        }
    }
}
