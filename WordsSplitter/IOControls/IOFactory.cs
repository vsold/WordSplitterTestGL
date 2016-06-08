using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsSplitter
{
    class IOFactory
    {
        public IInputParser GetInputParser(IOType ioType)
        {
            switch (ioType)
            {
                case IOType.File:
                    return new FileInputParser();
                case IOType.Console:
                    return new ConsoleInputParser();
                default:
                    return new ConsoleInputParser();
                        
            }
        }

        public IOutputProvider GetOutputProvider(IOType ioType)
        {
            switch (ioType)
            {
                case IOType.File:
                    return new FileOutputWriter();
                case IOType.Console:
                    return new ConsoleOutputWriter();
                default:
                    return new ConsoleOutputWriter();

            }
        }
    }
}
