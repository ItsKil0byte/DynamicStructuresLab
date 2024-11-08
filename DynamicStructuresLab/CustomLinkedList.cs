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

        public void Flip()
        {
            Node<T>? previous = null;
            Node<T>? current = first;

            while (current != null)
            {
                Node<T>? next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            first = previous;
        }

        public void Swap()
        {
            if (first == null || first.Next == null)
            {
                return;
            }

            Node<T> last = first;
            Node<T>? nextToLast = null;
            Node<T> second = first.Next;

            while (last.Next != null)
            {
                nextToLast = last;
                last = last.Next;
            }

            nextToLast!.Next = first;
            last.Next = second;
            first.Next = null;
            first = last;
        }

        public int CountUnique()
        {
            // NOTE: Возможно стоит его переписать, потому что в текущем варианте сложность целых O(n^2)

            int count = 0;
            Node<T>? current = first;

            while (current != null)
            {
                bool isUnique = true;
                Node<T>? checker = first;

                while (checker != current)
                {
                    if (checker!.Data!.Equals(current.Data))
                    {
                        isUnique = false;
                        break;
                    }

                    checker = checker.Next;
                }

                if (isUnique)
                {
                    count++;
                }

                current = current.Next;
            }

            return count;
        }

        public void RemoveNonUnique()
        {
            // Опять O(n^2)

            Node<T>? current = first;

            while (current != null)
            {
                Node<T> previous = current;
                Node<T>? checker = current.Next;

                while (checker != null)
                {
                    if (checker.Data!.Equals(current.Data))
                    {
                        previous.Next = checker.Next;
                    }
                    else
                    {
                        previous = checker;
                    }

                    checker = checker.Next;
                }

                current = current.Next;
            }
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void Print(string separator = " ")
        {
            Console.WriteLine(String.Join<T>(separator, this));
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
