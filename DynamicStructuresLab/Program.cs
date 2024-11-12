using DynamicStructuresLab.Controllers;

namespace DynamicStructuresLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите структуру данных для работы:\n");

                Console.WriteLine("1. Стек.");
                Console.WriteLine("2. Очередь.");
                Console.WriteLine("3. Связный список.");
                Console.WriteLine("4. Дерево.");
                Console.WriteLine("0. Выход.\n");

                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        StackMenu();
                        break;
                    case 2:
                        QueueMenu();
                        break;
                    case 3:
                        LinkedListMenu();
                        break;
                    case 4:
                        TreeMenu();
                        break;
                    case 0:
                        Console.WriteLine("\nЗавершение работы...");
                        return;
                    default:
                        Console.WriteLine("\nОшибка: опция в меню отсутсвует. Введите корректное число.\n");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static int GetUserChoice()
        {
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                Console.ReadKey();
                return -1;
            }
            return choice;
        }

        static void StackMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа со Стеком:\n");
                Console.WriteLine("1. Использовать самодельный стек.");
                Console.WriteLine("2. Использовать стандартный стек.");
                Console.WriteLine("0. Вернуться в главное меню.\n");
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int stackChoice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (stackChoice)
                {
                    case 1:
                        StackMenu(true);
                        break;
                    case 2:
                        StackMenu(false);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nОшибка: опция в меню отсутсвует. Введите корректное число.\n");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void QueueMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа с Очередью:\n");
                Console.WriteLine("1. Использовать самодельную очередь.");
                Console.WriteLine("2. Использовать стандартную очередь.");
                Console.WriteLine("0. Вернуться в главное меню.\n");
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int queueChoice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (queueChoice)
                {
                    case 1:
                        CustomQueueMenu();
                        break;
                    case 2:
                        StandardQueueMenu();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nОшибка: опция в меню отсутсвует. Введите корректное число.\n");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void LinkedListMenu()
        {
            CustomLinkedList<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            while (true)
            {
                Console.Clear();
                Console.Write("Работа со Связным списком -> ");
                list.Print();

                Console.WriteLine("\nВыберите алгоритм:\n");
                Console.WriteLine("1. Перевернуть список.");
                Console.WriteLine("2. Перенос первого элемента в конец списка.");
                Console.WriteLine("3. Перенос последнего элемента в начало списка.");
                Console.WriteLine("4. Подсчет уникальных элементов.");
                Console.WriteLine("5. Удаление неуникальных элементов.");
                Console.WriteLine("6. Вставка списка самого в себя после x.");
                Console.WriteLine("7. Вставка элемента E, сохраняя упорядоченность.");
                Console.WriteLine("8. Удаление всех элементов E.");
                Console.WriteLine("9. Вставка F перед первым E.");
                Console.WriteLine("10. Дописать список E к текущему списку.");
                Console.WriteLine("11. Разделить список по X.");
                Console.WriteLine("12. Удвоить список.");
                Console.WriteLine("13. Поменять местами два элемента.");
                Console.WriteLine("0. Вернуться в главное меню.");
                Console.WriteLine();
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int listChoice))
                {
                    Console.WriteLine();
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                switch (listChoice) // Лютый хардкод, убейте меня. Это пиздец... Боги такого не простят
                {
                    case 1:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пуст!");
                            break;
                        }

                        Console.WriteLine("Переворачиваем список...");
                        list.Flip();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 2:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пуст!");
                            break;
                        }

                        Console.WriteLine("Переносим первый элемент в конец...");
                        list.MoveFirstToLast();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 3:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пуст!");
                            break;
                        }

                        Console.WriteLine("Переносим последний элемент в начало...");
                        list.MoveLastToFirst();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 4:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пуст!");
                            break;
                        }

                        Console.WriteLine("Подсчитываем уникальные элементы...");
                        Console.WriteLine($"Результат = {list.CountUnique()}");

                        break;
                    case 5:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пустой!");
                            break;
                        }

                        Console.WriteLine("Удаляем неуникальные элементы...");
                        list.RemoveNonUnique();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 6:
                        {
                            if (list.IsEmpty)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }

                            Console.Write("Введите X: ");
                            string? input = Console.ReadLine();

                            Console.WriteLine();

                            if (int.TryParse(input, out int x))
                            {
                                if (list.DuplicateAfter(x))
                                {
                                    Console.WriteLine($"{x} найден, вставляем список...");
                                    Console.Write("Результат = ");
                                    list.Print();

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{x} не был найден в списке.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести числовое значение.");
                                break;
                            }
                        }
                    case 7:
                        {
                            Console.Write("Введите Е: ");
                            string? input = Console.ReadLine();

                            Console.WriteLine();

                            if (int.TryParse(input, out int e))
                            {
                                Console.WriteLine($"Вставляем {e} в нужное место...");
                                list.AddInOrder(e);
                                Console.Write("Результат = ");
                                list.Print();

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести числовое значение.");

                                break;
                            }
                        }
                    case 8:
                        {
                            if (list.IsEmpty)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }

                            Console.Write("Введите E: ");
                            string? input = Console.ReadLine();

                            Console.WriteLine();

                            if (int.TryParse(input, out int e))
                            {
                                if (list.RemoveAll(e))
                                {
                                    Console.WriteLine($"Удаляем все вхождения {e}...");
                                    Console.Write("Результат = ");
                                    list.Print();

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Нечего удалять.");

                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести числовое значение.");

                                break;
                            }
                        }
                    case 9:
                        {
                            if (list.IsEmpty)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }

                            Console.Write("Введите значения F и E через пробел (например, '5 10'): ");
                            string? input = Console.ReadLine();

                            string[] parts = input!.Split(' ');

                            Console.WriteLine();

                            if (parts.Length == 2 && int.TryParse(parts[1], out int e) && int.TryParse(parts[0], out int f))
                            {
                                if (list.AddBefore(e, f))
                                {
                                    Console.WriteLine($"Вставляяем {f} перед первым вхождением {e}...");
                                    Console.Write("Результат = ");
                                    list.Print();

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Значение {e} не найдено в списке.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести два числовых значения, разделённых пробелом.");
                                break;
                            }
                        }
                    case 10:
                        {
                            Console.Write("Введите значения для E через пробел (например, '1 2 3 ...'): ");
                            string? input = Console.ReadLine();

                            string[] parts = input!.Split(' ');
                            CustomLinkedList<int> newList = [];
                            bool inputCorrect = true;

                            Console.WriteLine();

                            foreach (string part in parts)
                            {
                                if (int.TryParse(part, out int number))
                                {
                                    newList.Add(number);
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: необходимо ввести числовые значения через пробел");
                                    inputCorrect = false;
                                    break;
                                }
                            }

                            if (!inputCorrect)
                            {
                                break;
                            }

                            Console.WriteLine($"Дописываем новый список к исходному...");
                            list.AddLinkedList(newList);

                            Console.Write("Результат = ");
                            list.Print();

                            break;
                        }
                    case 11:
                        {
                            if (list.IsEmpty)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }

                            Console.Write("Введите X: ");
                            string? input = Console.ReadLine();

                            Console.WriteLine();

                            if (int.TryParse(input, out int x))
                            {
                                CustomLinkedList<int> newList = [];

                                Console.WriteLine($"Разделяем список по {x}...");
                                Console.Write("Старый список = ");
                                list.Print();

                                newList = list.Split(x);
                                Console.Write("Новый список = ");
                                newList.Print();

                                list = newList;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести числовое значение.");
                                break;
                            }
                        }
                    case 12:
                        if (list.IsEmpty)
                        {
                            Console.WriteLine("Список пуст!");
                            break;
                        }

                        Console.WriteLine("Удваиваем список...");
                        list.Duplicate();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 13:
                        {
                            if (list.IsEmpty)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }

                            Console.Write("Введите значения два числа через пробел (например, '5 10'): ");
                            string? input = Console.ReadLine();

                            string[] parts = input!.Split(' ');

                            Console.WriteLine();

                            if (parts.Length == 2 && int.TryParse(parts[1], out int x) && int.TryParse(parts[0], out int y))
                            {
                                if (list.Swap(x, y))
                                {
                                    Console.WriteLine($"Меням местами {x} и {y}...");
                                    Console.Write("Результат = ");
                                    list.Print();

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Пара значений не найдена в списке.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: необходимо ввести два числовых значения, разделённых пробелом.");
                                break;
                            }
                        }
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        static void StackMenu(bool useCustomStack)
        {
            StackController<string> stack = new StackController<string>();
            FileProcessor fileProcessor = new FileProcessor();
            string stackTypeMessage;

            if (useCustomStack)
            {
                stack.SetCustomStack();
                stackTypeMessage = "Работа с самодельным стеком";
            }
            else
            {
                stack.SetDefaulStack();
                stackTypeMessage = "Работа со стандартным стеком";
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{stackTypeMessage}:\n");
                Console.WriteLine("1. Добавление элемента.");
                Console.WriteLine("2. Извлечение элемента.");
                Console.WriteLine("3. Просмотр верхнего элемента.");
                Console.WriteLine("4. Проверка на пустоту.");
                Console.WriteLine("5. Печать всех элементов.");
                Console.WriteLine("6. Печать количества элементов в стеке.");
                Console.WriteLine("7. Обработать файл input.txt.");
                Console.WriteLine("0. Вернуться в меню очереди.\n");
                Console.Write("Введите номер: ");
                
                int choice = GetUserChoice();
                if (choice == -1)
                {
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите элемент для вставки: ");
                        stack.Push(Console.ReadLine());
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        stack.Peek();
                        break;
                    case 4:
                        stack.IsEmpty();
                        break;
                    case 5:
                        stack.Print();
                        break;
                    case 6:
                        stack.Count();
                        break;
                    case 0:
                        return;
                }
            }
        }

        
        static void StandardQueueMenu()
        {
            QueueStandard queue = new QueueStandard();
            FileProcessor fileProcessor = new FileProcessor(); 

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа со Стандартной Очередью:\n");
                Console.WriteLine("1. Вставка элемента.");
                Console.WriteLine("2. Удаление элемента.");
                Console.WriteLine("3. Просмотр начала очереди.");
                Console.WriteLine("4. Проверка на пустоту.");
                Console.WriteLine("5. Печать всех элементов.");
                Console.WriteLine("6. Обработать файл input.txt.");
                Console.WriteLine("0. Вернуться в меню стека.\n");
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите элемент для вставки: ");
                        string itemToAdd = Console.ReadLine();
                        queue.Enqueue(itemToAdd);
                        Console.WriteLine($"Элемент '{itemToAdd}' добавлен в очередь.");
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            string removedItem = queue.Dequeue();
                            Console.WriteLine($"Удалён элемент: {removedItem}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        try
                        {
                            string peekedItem = queue.Peek();
                            Console.WriteLine($"Начало очереди: {peekedItem}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine($"Очередь пуста: {queue.IsEmpty()}");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Элементы очереди:");
                        queue.Print();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("Введите путь к файлу: ");
                        string filePath = Console.ReadLine();
                        fileProcessor.ProcessFile(filePath, queue);
                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nОшибка: опция в меню отсутствует. Введите корректное число.\n");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        static void CustomQueueMenu()
        {
            CustomQueue queue = new CustomQueue();
            FileProcessor fileProcessor = new FileProcessor();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа с Самодельной Очередью:\n");
                Console.WriteLine("1. Вставка элемента.");
                Console.WriteLine("2. Удаление элемента.");
                Console.WriteLine("3. Просмотр начала очереди.");
                Console.WriteLine("4. Проверка на пустоту.");
                Console.WriteLine("5. Печать всех элементов.");
                Console.WriteLine("6. Обработать файл input.txt.");
                Console.WriteLine("0. Вернуться в меню очереди.\n");
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.\n");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите элемент для вставки: ");
                        string itemToAdd = Console.ReadLine();
                        queue.Enqueue(itemToAdd);
                        Console.WriteLine($"Элемент '{itemToAdd}' добавлен в очередь.");
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            string removedItem = queue.Dequeue();
                            Console.WriteLine($"Удалён элемент: {removedItem}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        try
                        {
                            string peekedItem = queue.Peek();
                            Console.WriteLine($"Начало очереди: {peekedItem}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine($"Очередь пуста: {queue.IsEmpty()}");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Элементы очереди:");
                        queue.Print();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("Введите путь к файлу: ");
                        string filePath = Console.ReadLine();
                        fileProcessor.ProcessFile(filePath, queue);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nОшибка: опция в меню отсутствует. Введите корректное число.\n");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        static void TreeMenu()
        {
            while (true)
            {
                // ...
            }
        }
    }
}
