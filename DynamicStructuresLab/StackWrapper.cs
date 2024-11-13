using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab
{
    public class StackWrapper<T> : IStack<T>
    {
        private readonly Stack<T> _stack;

        public StackWrapper()
        {
            _stack = new Stack<T>();
        }

        public void Push(T item)
        {
            _stack.Push(item);
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }

        public void Print()
        {
            Console.WriteLine("Содержимое стека: ");
            foreach (var item in _stack)
            {
                Console.WriteLine($"{item}");
            }
        }

        public bool IsEmpty => _stack.Count == 0;

        public int Count => _stack.Count;
    }
}
