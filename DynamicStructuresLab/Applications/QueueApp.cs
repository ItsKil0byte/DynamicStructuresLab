using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Applications
{
    internal class QueueApp
    {
        private static CustomQueue Queue = new CustomQueue();

        public static void Start()
        {
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("Введите add чтобы добавить талон\nВведите call чтобы вызвать по последнему талону\nВведите stop чтобы закончить\nВведите list чтобы получить список талонов\n");
                string prompt = Console.ReadLine();
                switch (prompt)
                {
                    case "add":
                        string talon = random.Next(1000, 10000).ToString();
                        Queue.Enqueue(talon);
                        Console.WriteLine("\nНомер вашего талона \""+ talon + "\"\n");
                        break;
                    case "call":
                        if(!Queue.IsEmpty())
                        {
                            Console.WriteLine("\nВы вызвали талон с номером \""+Queue.Dequeue()+"\"");
                        }
                        else
                        {
                            Console.WriteLine("Некого вызывать!");
                        }
                        break;
                    case "list":
                        Console.WriteLine("\nСписок талонов:\n");
                        Queue.Print();
                        Console.WriteLine();
                        break;
                    case "stop":
                        return;
                    default:
                        Console.WriteLine("\nВведена некорректная команда!\n");
                        break;
                }
            }
        }
    }
}
