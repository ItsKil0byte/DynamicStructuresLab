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
        Node<T>? head;
        int count;

        public bool IsEmpty{ get { return count == 0; } }
        public int Count { get { return count; } }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            Node<T>? temp = head;
            head = head!.Next;
            count--;
            return temp!.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return head!.Data;
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
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
