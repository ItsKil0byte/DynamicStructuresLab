using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Applications
{
    internal class LListApp
    {
        private static CustomLinkedList<LListData> LList = new CustomLinkedList<LListData>();
        public static void Start()
        {
            string fullname, filter;
            int course;
            string[] debts;

            while (true)
            {
                Console.WriteLine("Список должников:");
                foreach (LListData data in LList)
                {
                    Console.WriteLine(data.GetSmallInfo());
                }
                Console.WriteLine("\nВведите add чтобы добавить должника\nВведите rem чтобы удалить должника\nВведите list чтобы увидеть список задолженностей ученика\nВведите stop чтобы закончить\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "add":
                        Console.Write("\nВведите ФИО должника: ");
                        fullname = Console.ReadLine();
                        Console.Write("Введите курс должника: ");
                        course = int.Parse(Console.ReadLine());
                        Console.Write("Введите задолженности через запятую: ");
                        debts = Console.ReadLine().Split(',');
                        LList.Add(new LListData(fullname, course, debts));
                        break;
                    case "rem":
                        Console.Write("\nВведите критерий фио для удаления: ");
                        filter = Console.ReadLine();
                        foreach (LListData data in LList)
                        {
                            if (data.FullName.Contains(filter))
                                LList.Remove(data);
                        }
                        break;
                    case "list":
                        Console.Write("\nВведите фио ученика: ");
                        filter = Console.ReadLine();
                        Console.WriteLine();
                        foreach(LListData data in LList)
                        {
                            if (data.FullName == filter)
                                Console.WriteLine(data.GetFullInfo());
                        }
                        break;
                    case "stop":
                        return;
                    default:
                        Console.WriteLine("\nВведена некорректная команда!");
                        break;
                }
                Console.WriteLine("\nНажмите любую кнопку чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }

            //
        }
    }
    class LListData(string fullname, int course, string[] debts)
    {
        public string FullName { get; set; } = fullname;
        public int Course { get; set; } = course;
        public string[] Debts { get; set; } = debts;
        public string GetSmallInfo()
        {
            return ("Имя: "+FullName+" Курс: "+Course.ToString()+" Задолженности: "+Debts.Length.ToString());
        }
        public string GetFullInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSmallInfo());
            foreach (string s in Debts)
            {
                sb.Append("\n"+s);
            }
            return sb.ToString();
        }
    }
}
