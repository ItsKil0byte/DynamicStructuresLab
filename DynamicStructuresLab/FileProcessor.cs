using DynamicStructuresLab.Controllers;

namespace DynamicStructuresLab
{
    public class FileProcessor
    {
        public void ProcessFile(string filePath, IQueue queue)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Ошибка: файл не найден.");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            string line = File.ReadAllText(filePath);
            string[] operations = line.Split(' ');

            ProcessCommands(operations, queue);
        }

        public void ProcessFile(string filePath, StackController<string> stack)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Ошибка: файл не найден.");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            string line = File.ReadAllText(filePath);
            string[] operations = line.Split(' ');

            ProcessCommands(operations, stack);
        }

        public void ProcessCommands(string[] operations, StackController<string> stackController)
        {
            Console.WriteLine("\nОбработка команд:\n");
            foreach (var operation in operations)
            {
                switch (operation[0])
                {
                    case '1': // Вставка
                        stackController.Push(operation.Split(",")[1]);
                        break;
                    case '2': // Удаление
                        stackController.Pop();
                        break;
                    case '3': // Просмотр начала очереди
                        stackController.Peek();
                        break;
                    case '4': // Проверка на пустоту
                        stackController.IsEmpty();
                        break;
                    case '5': // Печать
                        stackController.Print();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда: " + operation);
                        break;
                }
            }
        }


        public void ProcessCommands(string[] operations, IQueue queue)
        {
            Console.WriteLine("\nОбработка команд:\n");
            foreach (var operation in operations)
            {
                switch (operation[0])
                {
                    case '1': // Вставка
                        EnqueueItems(operation, queue);
                        break;
                    case '2': // Удаление
                        DequeueItems(queue);
                        break;
                    case '3': // Просмотр начала очереди
                        PeekItems(queue);
                        break;
                    case '4': // Проверка на пустоту
                        CheckIfEmpty(queue);
                        break;
                    case '5': // Печать
                        PrintItems(queue);
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда: " + operation);
                        break;
                }
            }
        }

        private void EnqueueItems(string operation, IQueue queue)
        {
            string[] parts = operation.Split(',');
            for (int i = 1; i < parts.Length; i++)
            {
                string item = parts[i];
                queue.Enqueue(item);
                Console.WriteLine($"Добавлен элемент: {item}");
            }
        }

        private void DequeueItems(IQueue queue)
        {
            try
            {
                Console.WriteLine("Удалён элемент: " + queue.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PeekItems(IQueue queue)
        {
            try
            {
                Console.WriteLine("Начало очереди: " + queue.Peek());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CheckIfEmpty(IQueue queue)
        {
            Console.WriteLine("Очередь пустая: " + queue.IsEmpty());
        }

        private void PrintItems(IQueue queue)
        {
            Console.Write("Элементы очереди: ");
            queue.Print();
        }
    }
}
