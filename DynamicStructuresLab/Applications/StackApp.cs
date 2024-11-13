using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Applications
{
    internal class StackApp
    {
        private static CustomStack<uint> Stack = new CustomStack<uint>();

        public static void Start()
        {
            uint number, numeralSystem;
            try
            {
                Console.Write("Введите целое, неотрицательное число в десятичной системе счисления: ");
                number = uint.Parse(Console.ReadLine());
                Console.Write("Введите желаемую систему счисления: ");
                numeralSystem = uint.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            while (number >= numeralSystem)
            {
                Stack.Push(number % numeralSystem);
                number /= numeralSystem;
            }
            Stack.Push(number);

            while (!Stack.IsEmpty)
            {
                Console.Write(Stack.Pop());
            }
        }
    }
}
