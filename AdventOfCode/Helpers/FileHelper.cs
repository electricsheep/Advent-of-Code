using System;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public class FileHelper
    {
        public static async Task<string[]> ReadLines(string filePath)
        {
            using var file = File.OpenText($"{AppContext.BaseDirectory}/{filePath}");
            var text = await file.ReadToEndAsync();
            return text.Split(Environment.NewLine);
        }
    }
}
