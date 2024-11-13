using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Function : Token
    {
        public string name;
        public string firstExpression = "";
        public string secondExpression = "";
        public Function(string name, string firstExpression)
        {
            this.name = name;
            this.firstExpression = firstExpression;
        }

        public Function(string name, string firstExpression, string secondExpression)
        {
            this.name = name;
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
        }
    }
}
