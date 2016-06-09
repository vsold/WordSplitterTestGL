using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace WordsSplitter
{
    public enum IOType
    {
        File,
        Console
    }

    class Program
    {
        private static IOType input = IOType.File;
        private static IOType output = IOType.File;

        private static string inputFileName = "";
        private static string outputFileName = "";

        static void Main(string[] args)
        {
            InitUserParams(args);

            Dictionary<string, HashSet<int>> words = new Dictionary<string, HashSet<int>>(StringComparer.Ordinal);

            var ioFactory = new IOFactory();
            var started = DateTime.Now;
            List<string> lines = GetInputLines(ioFactory);
            Console.WriteLine("\nData read finished in {0} ms\n\n", (DateTime.Now - started).TotalMilliseconds);

            started = DateTime.Now;
            FillWordsChart(lines, words);
            Console.WriteLine("\nWords parsing finished in {0} ms\n\n", (DateTime.Now - started).TotalMilliseconds);

            started = DateTime.Now;
            OutputResults(ioFactory, words);
            Console.WriteLine("\nData write finished in {0} ms\n\n", (DateTime.Now - started).TotalMilliseconds);

            Console.WriteLine("\n\nPress any key to quit...");
            Console.ReadKey();
        }

        private static void InitUserParams(string[] args)
        {
            if (args.Length <= 0)
            {
                return;
            }
            inputFileName = args[0];
            if (args.Length > 1)
            {
                outputFileName = args[1];
            }
        }

        private static List<string> GetInputLines(IOFactory factory)
        {
            return factory.GetInputParser(input).GetData(inputFileName);
        }

        private static void FillWordsChart(List<string> lines, Dictionary<string, HashSet<int>> wordsChart)
        {
            char[] separators = new[] { ',', ' ', '.', ':', ';', ')', '(', '?', '!', '{', '}', '\\', '/', '"', '~', '\t', '[', ']', '-', '#', '*', '&', '%', '\'', '$', '<', '>', '+', '=', '—' };

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];

                string[] lineWords = line.ToLowerInvariant().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                //string[] lineWords = Regex.Split(line.ToLower(), @"[^A-Za-z0-9]+");

                foreach (string word in lineWords)
                {
                    if (string.IsNullOrEmpty(word))
                        continue;

                    if (!wordsChart.ContainsKey(word))
                    {
                        wordsChart.Add(word, new HashSet<int>());
                    }
                    wordsChart[word].Add(i);
                }
            }
        }

        private static void OutputResults(IOFactory factory, Dictionary<string, HashSet<int>> data)
        {
            factory.GetOutputProvider(output).OutputData(data, outputFileName);
        }
    }
}
