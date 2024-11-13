using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Controllers
{
    public class BinaryTreeController<T> : Controller, IBinaryTreeController
        where T : IComparable<T>
    {
        public CustomBinaryTree<T> BinaryTree;
        

        public BinaryTreeController()
        {
            BinaryTree = new CustomBinaryTree<T>();
        }

        public void Insert(string item)
        {
            this.BinaryTree.Insert((T)Convert.ChangeType(item, typeof(T)));
            Console.WriteLine($"Добавили в дерево: {item}");
            WaitUser();
        }

        public void Has(string item)
        {
            Console.WriteLine("Введите элемент который хотите найти: ");
            if (this.BinaryTree.Search((T)Convert.ChangeType(item, typeof(T))))
            {
                Console.WriteLine($"Элемент {item} находится в дереве");
            }
            else
            {
                Console.WriteLine($"Элемента {item} нет в дереве");
            }
            WaitUser();
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("Бинарное дерево: ");
            this.BinaryTree.InOrderTraversal();
            WaitUser();
        }

        public void Print()
        {
            Console.WriteLine("Схема бинарного дерева: ");
            this.BinaryTree.PrintTree();
            WaitUser();
        }

        public void Depth() 
        {
            Console.WriteLine($"Глубина дерева: {this.BinaryTree.GetDepth()}");
            WaitUser();
        }
    }
}
