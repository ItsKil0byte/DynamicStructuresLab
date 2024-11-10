namespace DynamicStructuresLab
{
    public class QueueList
    {
        private List<string> _elements;

        public QueueList()
        {
            _elements = new List<string>();
        }

        public void Enqueue(string item)
        {
            _elements.Add(item);
        }

        public string Dequeue()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException("Очередь пуста.");
            string item = _elements[0];
            _elements.RemoveAt(0);
            return item;
        }

        public bool IsEmpty()
        {
            return _elements.Count == 0;
        }

        public string Peek()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException("Очередь пуста.");
            return _elements[0];
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", _elements));
        }
    }
}