using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab
{
    public class CustomStack<T> : IEnumerable<T>, IStack<T>
    {
        CustomLinkedList<T> stack = new CustomLinkedList<T>();
        int count;

        public bool IsEmpty{ get { return stack.IsEmpty ; } }
        public int Count { get { return stack.Count; } }

        public void Push(T item)
        {
            stack.AddFirst(item);
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            T res = stack.First<T>();
            stack.RemoveFirst();

            return res;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return stack.First<T>();
        }

        public void Print()
        {
            Console.WriteLine("Содержимое стека: ");
            foreach (var item in this)
            {
                Console.WriteLine($"{item}");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach(var item in stack)
            {
                yield return item;
            }
        }
    }
}
