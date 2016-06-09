using System;
using System.Collections.Generic;

namespace WordsSplitter
{
    class ConsoleInputParser: IInputParser
    {
        public List<string> GetData(string path="")
        {
            List<string> lines = new List<string>();

            while (true)
            {
                Console.WriteLine("\nEnter your text, please! Enter \"exit\" when you're done."); // Prompt
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }
                lines.Add(line);
            }
            
            Console.WriteLine("\nInput mode terminated!\n");

            return lines;
        }
    }
}
