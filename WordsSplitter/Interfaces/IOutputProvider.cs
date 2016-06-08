using System.Collections.Generic;

namespace WordsSplitter
{
    interface IOutputProvider
    {
       void OutputData(Dictionary<string, HashSet<int>> data);
    }
}
