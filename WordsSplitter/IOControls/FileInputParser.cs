using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WordsSplitter
{
    class FileInputParser: IInputParser
    {
        const string INPUT_FILE_PATH = "Input.txt";

        public List<string> GetData(string path = "")
        {
            string filePath = INPUT_FILE_PATH;
            if (!string.IsNullOrEmpty(path))
            {
                filePath = path;
            }

            List<string> lines = new List<string>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Input file not found! Path: {0}", filePath);
            }
            else
            {
                Console.WriteLine("Trying to read data from: {0}\n", filePath);
                using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
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
