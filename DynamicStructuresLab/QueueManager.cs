namespace DynamicStructuresLab
{
    public class QueueManager
    {
        private CustomQueue _customQueue;
        private QueueStandard _queueStandard;

        public QueueManager()
        {
            _customQueue = new CustomQueue();
            _queueStandard = new QueueStandard();
        }

        public void ProcessCommands(string[] operations)
        {
            foreach (var operation in operations)
            {
                switch (operation[0])
                {
                    case '1': // Вставка
                        EnqueueItems(operation);
                        break;
                    case '2': // Удаление
                        DequeueItems();
                        break;
                    case '3': // Просмотр начала очереди
                        PeekItems();
                        break;
                    case '4': // Проверка на пустоту
                        CheckIfEmpty();
                        break;
                    case '5': // Печать
                        PrintItems();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда: " + operation);
                        break;
                }
            }
        }

        private void EnqueueItems(string operation)
        {
            string[] parts = operation.Split(',');
            for (int i = 1; i < parts.Length; i++)
            {
                _customQueue.Enqueue(parts[i]);
                _queueStandard.Enqueue(parts[i]);
            }
        }

        private void DequeueItems()
        {
            try
            {
                Console.WriteLine("Удалён из списка: " + _customQueue.Dequeue());
                Console.WriteLine("Удалён из стандартной очереди: " + _queueStandard.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PeekItems()
        {
            try
            {
                Console.WriteLine("Начало списка: " + _customQueue.Peek());
                Console.WriteLine("Начало стандартной очереди: " + _queueStandard.Peek());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CheckIfEmpty()
        {
            Console.WriteLine("Список пуст: " + _customQueue.IsEmpty());
            Console.WriteLine("Стандартная очередь пуста: " + _queueStandard.IsEmpty());
        }

        private void PrintItems()
        {
            Console.WriteLine("Элементы списка:");
            _customQueue.Print();
            Console.WriteLine("Элементы стандартной очереди:");
            _queueStandard.Print();
        }
    }
}
