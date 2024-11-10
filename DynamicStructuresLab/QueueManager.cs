namespace DynamicStructuresLab
{
    public class QueueManager
    {
        private QueueList queueList;
        private QueueStandard queueStandard;

        public QueueManager()
        {
            queueList = new QueueList();
            queueStandard = new QueueStandard();
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
                queueList.Enqueue(parts[i]);
                queueStandard.Enqueue(parts[i]);
            }
        }

        private void DequeueItems()
        {
            try
            {
                Console.WriteLine("Удалён из списка: " + queueList.Dequeue());
                Console.WriteLine("Удалён из стандартной очереди: " + queueStandard.Dequeue());
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
                Console.WriteLine("Начало списка: " + queueList.Peek());
                Console.WriteLine("Начало стандартной очереди: " + queueStandard.Peek());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CheckIfEmpty()
        {
            Console.WriteLine("Список пуст: " + queueList.IsEmpty());
            Console.WriteLine("Стандартная очередь пуста: " + queueStandard.IsEmpty());
        }

        private void PrintItems()
        {
            Console.WriteLine("Элементы списка:");
            queueList.Print();
            Console.WriteLine("Элементы стандартной очереди:");
            queueStandard.Print();
        }
    }
}
