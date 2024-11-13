using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Applications
{
    internal class TreeApp
    {
        private static MyTree Tree = new MyTree();
        public static void Start()
        {
            while (true)
            {
                Tree.DrawTree();
                Console.WriteLine("\nВведите add чтобы добавить каталог\nВведите stop чтобы закончить\n");
                switch (Console.ReadLine())
                {
                    case "add":
                        Console.WriteLine("Введите каталог для добавления в формате Program files/yandex/bin");
                        Tree.AddNode(Console.ReadLine());
                        break;
                    case "stop":
                        return;
                    default:
                        Console.WriteLine("\nВведена некорректная команда!");
                        Console.WriteLine("\nНажмите любую кнопку чтобы продолжить...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        public static void AddFolder(string path)
        {
            string[] parsedPath = path.Split('/');
            
        }
    }
    class MyTree
    {
        public MyTreeNode Root { get; set; }
        public MyTree()
        {
            Root = new MyTreeNode("root");
        }

        public void AddNode(string path)
        {
            string[] parsedPath = path.Split('/');
            MyTreeNode current = this.Root;
            foreach(string folder in parsedPath)//проход по a/b/c/d
            {
                bool hasThisName = false;
                for(int currChild = 0;currChild < current.Children.Count; currChild++)// проход по current.children[]
                {
                    if (current.Children[currChild].Name == folder)
                    {
                        current = current.Children[currChild];
                        hasThisName = true;
                        break;
                    }
                }
                if (!hasThisName)
                {
                    current.Children.Add(new MyTreeNode(folder));
                    foreach (MyTreeNode child in current.Children)
                    {
                        if (child.Name == folder)
                        {
                            current = child;
                        }
                    }
                }

            }

        }
        public void DrawTree()
        {
            Console.WriteLine(Root.Name);
            string indent = AppendIndent(Root.Name.Length-1);
            DrawChildren(Root.Children, indent);
        }

        private void DrawChildren(List<MyTreeNode> children,string indent)
        {
            foreach (MyTreeNode child in children)
            {
                if (children.Last() == child)
                {
                    Console.WriteLine(indent + "└─" + child.Name);
                    DrawChildren(child.Children, indent + " " + AppendIndent(child.Name.Length));
                }
                else
                {
                    Console.WriteLine(indent + "├─" + child.Name);
                    DrawChildren(child.Children, indent + "│" + AppendIndent(child.Name.Length));
                }
                
            }
        }

        private string AppendIndent(int amount)
        {
            string subindent = "";
            for(int i = 0; i < amount; i++)
            {
                subindent += " ";
            }
            return subindent;
        }
    }
    class MyTreeNode
    {
        public string? Name { get; set; }
        public List<MyTreeNode>? Children { get; set; }
        public MyTreeNode(string name)
        {
            Name = name;
            Children = new List<MyTreeNode>();
        }
    }
}
