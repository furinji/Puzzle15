using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzle15
{
    public interface ILoopTask
    {
        void DoTask();
        bool IsComplete { get; }
    }
}
