using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsSplitter
{
    class ConsoleOutputWriter: IOutputProvider
    {
        public void OutputData(Dictionary<string, HashSet<int>> data)
        {
            foreach (var word in data.OrderBy(i => i.Key))
            {
                Console.WriteLine("{0}: {1}", word.Key, string.Join(" ", word.Value));
            }
        }
    }
}
