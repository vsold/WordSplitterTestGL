using System;
using System.Collections.Generic;
using System.IO;

namespace WordsSplitter
{
    class FileInputParser: IInputParser
    {
        const string inputFilePath = "Input.txt";

        public List<string> GetData()
        {
            List<string> lines = new List<string>();

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found! Path: {0}", inputFilePath);
            }
            else
            {
                Console.WriteLine("Trying to read data from: {0}\n", inputFilePath);
                using (StreamReader sr = new StreamReader(File.OpenRead(inputFilePath)))
                {
                    while (sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        if (line == null) continue;
                        lines.Add(line);
                    }
                }
                Console.WriteLine("{0} lines readed from file.\n", lines.Count);
            }

            return lines;
        }
    }
}
