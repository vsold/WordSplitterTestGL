using System.Collections.Generic;

namespace WordsSplitter
{
    interface IInputParser
    {
        List<string> GetData(string path = "");
    }
}
