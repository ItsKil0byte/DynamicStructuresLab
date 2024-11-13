using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Token
    {
        protected static readonly Dictionary<string, int> getPriority = new Dictionary<string, int>(){
        {"^", 3},
        {"*", 2},
        {"/", 2},
        {"+", 1},
        {"-", 1},
    };
    }
}
