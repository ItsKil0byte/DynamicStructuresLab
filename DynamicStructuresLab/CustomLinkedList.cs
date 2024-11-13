using System.Collections;

namespace DynamicStructuresLab
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? first;
        private Node<T>? last;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

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

        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Linked list is empty.");
            }
            first = first!.Next;

            if (first == null)
            {
                last = null;
            }
            count--;
        }

            public bool Remove(T data)
        {
            Node<T>? current = first;
            Node<T>? previous = null;

            while (current != null)
            {
                if (current.Data!.Equals(data))
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
            if (count <= 1)
            {
                return;
            }

            Node<T>? previous = null;
            Node<T>? current = first;
            last = first;

            while (current != null)
            {
                Node<T>? next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            first = previous;
        }

        public void MoveLastToFirst()
        {
            if (first == null || first.Next == null)
            {
                return;
            }

            Node<T>? nextToLast = first;

            while (nextToLast!.Next != last)
            {
                nextToLast = nextToLast.Next;
            }

            last!.Next = first;
            first = last;
            nextToLast!.Next = null;
            last = nextToLast;
        }

        public void MoveFirstToLast()
        {
            if (first == null || first.Next == null)
            {
                return;
            }

            Node<T> node = first;
            first = first.Next;

            last!.Next = node;
            last = node;
            last.Next = null;
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
                        count--;
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

        public bool RemoveAll(T data)
        {
            Node<T>? current = first;
            Node<T>? previous = null;
            bool isRemoved = false;

            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    if (previous == null)
                    {
                        first = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    isRemoved = true;
                    count--;
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }

            if (previous == null)
            {
                last = null;
            }
            else if (previous.Next == null)
            {
                last = previous;
            }

            return isRemoved;
        }

        public bool AddBefore(T target, T data)
        {
            Node<T>? current = first;
            Node<T>? previous = null;

            while (current != null)
            {
                if (current.Data!.Equals(target))
                {
                    Node<T> node = new(data)
                    {
                        Next = current
                    };

                    if (previous == null)
                    {
                        first = node;
                    }
                    else
                    {
                        previous.Next = node;
                    }

                    count++;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void AddLinkedList(CustomLinkedList<T> list)
        {
            if (list.first == null)
            {
                return;
            }

            if (first == null)
            {
                first = list.first;
                last = list.last;
            }
            else
            {
                last!.Next = list.first;
                last = list.last;
            }

            count += list.count;
        }

        public CustomLinkedList<T> Split(T target)
        {
            Node<T>? current = first;
            Node<T>? previous = null;
            CustomLinkedList<T> result = [];
            int count = 1;

            while (current != null)
            {
                if (current.Data!.Equals(target))
                {
                    if (count == 1)
                    {
                        result.first = current;
                        result.last = last;

                        first = null;
                        last = null;

                        result.count = this.count;
                        this.count = 0;

                        break;
                    }

                    result.first = current;

                    if (previous != null)
                    {
                        previous.Next = null;
                        result.last = last;
                        last = previous;
                    }
                    else
                    {
                        result.last = current;
                    }

                    result.count = count;
                    this.count -= count;

                    break;
                }

                previous = current;
                current = current.Next;
                count++;
            }

            return result;
        }

        public void Duplicate()
        {
            if (first == null)
            {
                return;
            }

            CustomLinkedList<T> duplicated = [];

            foreach(T data in this)
            {
                duplicated.Add(data);
            }

            last!.Next = duplicated.first;
            last = duplicated.last;
            count += duplicated.count;
        }

        public bool Swap(T firstData, T secondData)
        {
            if (first == null || firstData!.Equals(secondData))
            {
                return false;
            }

            Node<T>? firstCurrent = first, secondCurrent = first;
            Node<T>? firstPrevious = null, secondPrevious = null;

            while (firstCurrent != null && !firstCurrent.Data!.Equals(firstData))
            {
                firstPrevious = firstCurrent;
                firstCurrent = firstCurrent.Next;
            }

            while (secondCurrent != null && !secondCurrent.Data!.Equals(secondData))
            {
                secondPrevious = secondCurrent;
                secondCurrent = secondCurrent.Next;
            }

            if (firstCurrent == null || secondCurrent == null)
            {
                return false;
            }

            if (firstPrevious != null)
            {
                firstPrevious.Next = secondCurrent;
            }
            else
            {
                first = secondCurrent;
            }

            if (secondPrevious != null)
            {
                secondPrevious.Next = firstCurrent;
            }
            else
            {
                first = firstCurrent;
            }

            Node<T> node = firstCurrent.Next!;
            firstCurrent.Next = secondCurrent.Next;
            secondCurrent.Next = node;

            if (firstCurrent.Next == null)
            {
                last = firstCurrent;
            }
            else if (secondCurrent.Next == null)
            {
                last = secondCurrent;
            }

            return true;
        }

        public bool DuplicateAfter(T target)
        {
            Node<T>? current = first;
            CustomLinkedList<T> duplicated = [];

            while (current != null)
            {
                if (current.Data!.Equals(target))
                {
                    foreach (T data in this)
                    {
                        duplicated.Add(data);
                    }

                    Node<T>? node = current.Next;
                    current.Next = duplicated.first;
                    duplicated.last!.Next = node;

                    if (current == last)
                    {
                        last = duplicated.last;
                    }

                    count += duplicated.count;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void AddInOrder(T data)
        {
            if (first == null || ((IComparable<T>)data!).CompareTo(first.Data) <= 0)
            {
                AddFirst(data);
                return;
            }

            Node<T> node = new(data);
            Node<T> current = first;

            while (current.Next != null && ((IComparable<T>)current.Next.Data!).CompareTo(data) < 0)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;

            if (node.Next == null)
            {
                last = node;
            }

            count++;
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
