using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFilePath = "Input.txt";
            const string outputFilePath = "Output.txt";

            var started = DateTime.Now;

            Dictionary<string, HashSet<int>> words = new Dictionary<string, HashSet<int>>(StringComparer.Ordinal);

            char[] separators = new[] {',', ' ', '.', ':',';', ')', '(', '?', '!', '{', '}', '\\', '/', '"', '~', '\t', '[', ']', '-', '#', '*', '&', '%', '\'', '$', '<', '>', '+', '=' };

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found! Path: {0}", inputFilePath);
            }
            else
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(inputFilePath)))
                {
                    int lineCount = 0;
                    while (sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        if (line == null) continue;
                        lineCount++;
                        //string[] lineWords = line.ToLowerInvariant().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        string[] lineWords = Regex.Split(line.ToLower(), @"[^A-Za-z0-9]+");

                        foreach (string word in lineWords)
                        {
                            if (string.IsNullOrEmpty(word))
                                continue;

                            if (!words.ContainsKey(word))
                            {
                                words.Add(word, new HashSet<int>());
                            }
                            words[word].Add(lineCount);
                        }
                    }
                }
            }

            File.WriteAllLines(outputFilePath, words.OrderBy(i => i.Key).Select(s => $"{s.Key}: {string.Join(" ", s.Value)}\n"), Encoding.Unicode);

            Console.WriteLine("Finished in {0} ms", (DateTime.Now - started).TotalMilliseconds);

            Console.WriteLine("\n\nPress any key to quit...");
            Console.ReadKey();
        }
    }
}
