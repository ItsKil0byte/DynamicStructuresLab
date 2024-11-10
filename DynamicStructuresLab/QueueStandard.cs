﻿namespace DynamicStructuresLab
{
    public class QueueStandard
    {
        private Queue<string> _queue;

        public QueueStandard()
        {
            _queue = new Queue<string>();
        }

        public void Enqueue(string item)
        {
            _queue.Enqueue(item);
        }

        public string Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("Очередь пуста.");
            return _queue.Dequeue();
        }

        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        public string Peek()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("Очередь пуста.");
            return _queue.Peek();
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", _queue));
        }
    }
}