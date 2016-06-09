using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordsSplitter
{
    class FileOutputWriter: IOutputProvider
    {
        const string OUTPUT_FILE_PATH = "Output.txt";
        public void OutputData(Dictionary<string, HashSet<int>> data, string path = "")
        {
            string outFilePath = OUTPUT_FILE_PATH;
            if (!string.IsNullOrEmpty(path))
            {
                outFilePath = path;
            }
            Console.WriteLine("\nWriting results in {0}\n", outFilePath);
            File.WriteAllLines(outFilePath, 
                data.OrderBy(i => i.Key).Select(s => string.Format("{0}: {1}\n", s.Key, string.Join(" ", s.Value))), 
                Encoding.Unicode);
            Console.WriteLine("\n{0} lines has been written\n", data.Count);
        }
    }
}
