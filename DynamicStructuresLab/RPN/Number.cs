using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Number : Token
    {
        public double value;
        public Number(double value)
        {
            this.value = value;
        }
        public static Number operator +(Number left, Number right)
        {
            return new Number(left.value + right.value);
        }
        public static Number operator -(Number left, Number right)
        {
            return new Number(left.value - right.value);
        }
        public static Number operator *(Number left, Number right)
        {
            return new Number(left.value * right.value);
        }
        public static Number operator /(Number left, Number right)
        {
            return new Number(left.value / right.value);
        }
        public static Number operator ^(Number left, Number right)
        {
            return new Number(Math.Pow(left.value, right.value));
        }
    }
}
