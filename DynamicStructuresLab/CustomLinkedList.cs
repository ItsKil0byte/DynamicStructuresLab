using System.Collections;

namespace DynamicStructuresLab
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? first;
        private Node<T>? last;
        private int count;

        public int Count { get { return count; } }

        public void Add(T data)
        {
            Node<T> node = new(data);

            if (first == null)
            {
                first = node;
            }
            else
            {
                last!.Next = node;
            }

            last = node;
            count++;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new(data);
            node.Next = first;
            first = node;

            if (count == 0)
            {
                last = first;
            }

            count++;
        }

        public bool Remove(T data)
        {
            Node<T>? current = first;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        first = first?.Next;

                        if (first == null)
                        {
                            last = null;
                        }
                    }

                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void Print(string separator = " ")
        {
            Node<T>? current = first;

            while (current != null)
            {
                if (current.Next == null)
                {
                    Console.Write(current.Data);
                    break;
                }

                Console.Write(current.Data + separator);
                current = current.Next;
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
