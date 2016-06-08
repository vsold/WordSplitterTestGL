using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordsSplitter
{
    class FileOutputWriter: IOutputProvider
    {
        const string outputFilePath = "Output.txt";
        public void OutputData(Dictionary<string, HashSet<int>> data)
        {
            Console.WriteLine("\nWriting results in {0}\n", outputFilePath);
            File.WriteAllLines(outputFilePath, 
                data.OrderBy(i => i.Key).Select(s => $"{s.Key}: {string.Join(" ", s.Value)}\n"), 
                Encoding.Unicode);
        }
    }
}
