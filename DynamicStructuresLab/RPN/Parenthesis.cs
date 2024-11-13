using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Parenthesis : Token
    {
        public bool isOpening;
        public Parenthesis(bool isOpening)
        {
            this.isOpening = isOpening;
        }
    }
}
