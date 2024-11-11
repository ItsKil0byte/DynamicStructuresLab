namespace DynamicStructuresLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите структуру данных для работы:");
                Console.WriteLine();
                Console.WriteLine("1. Стек");
                Console.WriteLine("2. Очередь");
                Console.WriteLine("3. Связный список");
                Console.WriteLine("4. Дерево");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите число.");
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
                        Console.WriteLine();
                        Console.WriteLine("Завершение работы...");
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ошибка: опция в меню отсутсвует. Введите корректное число.");
                        Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void StackMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа со Стеком:");
                Console.WriteLine();
                Console.WriteLine("1. Использовать самодельный стек");
                Console.WriteLine("2. Использовать стандартный стек");
                Console.WriteLine("0. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int stackChoice))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите число.");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                switch (stackChoice)
                {
                    case 1:
                        CustomStackMenu();
                        break;
                    case 2:
                        StandardStackMenu();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ошибка: опция в меню отсутсвует. Введите корректное число.");
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
                Console.WriteLine("Работа с Очередью:");
                Console.WriteLine();
                Console.WriteLine("1. Использовать самодельную очередь");
                Console.WriteLine("2. Использовать стандартную очередь");
                Console.WriteLine("0. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int queueChoice))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите число.");
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
                        Console.WriteLine();
                        Console.WriteLine("Ошибка: опция в меню отсутсвует. Введите корректное число.");
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
                Console.Write("Работа со Связным списком: ");
                list.Print();

                Console.WriteLine();
                Console.WriteLine("Выберите алгоритм:");
                Console.WriteLine();

                Console.WriteLine("1. Перевернуть список");
                Console.WriteLine("2. Перенос первого элемента в конец списка");
                Console.WriteLine("3. Перенос последнего элемента в начало списка");
                Console.WriteLine("4. Подсчет уникальных элементов");
                Console.WriteLine("5. Удаление неуникальных элементов");
                Console.WriteLine("6. Вставка списка самого в себя после x");
                Console.WriteLine("7. Вставка элемента E, сохраняя упорядоченность");
                Console.WriteLine("8. Удаление всех элементов E");
                Console.WriteLine("9. Вставка F перед первым E");
                Console.WriteLine("10. Дописать список E к L");
                Console.WriteLine("11. Разделить список по x");
                Console.WriteLine("12. Удвоить список");
                Console.WriteLine("13. Поменять местами два элемента");
                Console.WriteLine("0. Вернуться в главное меню");

                Console.WriteLine();
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int listChoice))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите число.");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                switch (listChoice)
                {
                    case 1:
                        Console.WriteLine("Переворачиваем список...");
                        list.Flip();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 2:
                        Console.WriteLine("Переносим первый элемент в конец...");
                        list.MoveFirstToLast();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 3:
                        Console.WriteLine("Переносим последний элемент в начало...");
                        list.MoveLastToFirst();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 4:
                        Console.WriteLine("Подсчитываем уникальные элементы...");
                        Console.WriteLine($"Результат = {list.CountUnique()}");
                        break;
                    case 5:
                        Console.WriteLine("Удаляем неуникальные элементы...");
                        list.RemoveNonUnique();

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    case 6:
                        Console.Write("Введите X: ");
                        string? input = Console.ReadLine();

                        if (int.TryParse(input, out int targetNumber))
                        {
                            if (list.DuplicateAfter(targetNumber))
                            {
                                Console.WriteLine("X найден, вставляем список...");
                            }
                            else
                            {
                                Console.WriteLine("Х не был найден в списке.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ожидалось число.");
                        }

                        Console.Write("Результат = ");
                        list.Print();

                        break;
                    // NOTE: дописать.
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        static void CustomStackMenu()
        {
            while (true)
            {
                // ...
            }
        }

        static void StandardStackMenu()
        {
            while (true)
            {
                // ...
            }
        }
        static void StandardQueueMenu()
        {
            while (true)
            {
                // ...
            }
        }

        static void CustomQueueMenu()
        {
            while (true)
            {
                // ...
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
