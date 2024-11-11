namespace DynamicStructuresLab
{
    public class CustomQueue
    {
        private Node<string>? head;
        private Node<string>? tail;

        public CustomQueue()
        {
            head = null;
            tail = null;
        }

        public void Enqueue(string item)
        {
            var newNode = new Node<string>(item);
            if (tail != null)
            {
                tail.Next = newNode;
            }
            tail = newNode;
            if (head == null)
            {
                head = tail;
            }
        }

        public string Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException("Очередь пуста.");
            string item = head.Data;
            head = head.Next;
            if (head == null)
            {
                tail = null; // Если очередь пуста, обновляем tail
            }
            return item;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public string Peek()
        {
            if (head == null)
                throw new InvalidOperationException("Очередь пуста.");
            return head.Data;
        }

        public void Print()
        {
            Node<string>? current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}