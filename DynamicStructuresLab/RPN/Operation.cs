using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Operation : Token
    {
        public string value;
        public int priority;
        public Operation(string value)
        {
            this.value = value;
            this.priority = getPriority[value];
        }
    }
}
