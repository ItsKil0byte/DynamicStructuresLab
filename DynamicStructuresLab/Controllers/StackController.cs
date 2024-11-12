using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Controllers
{
    public class StackController<T>
    {
        private IStack<T>? stack;
        public void SetCustomStack()
        {
            this.stack = new CustomStack<T>();
        }

        public void SetDefaulStack() 
        { 
            this.stack = new StackWrapper<T>(); 
        }

        public void Push(T item)
        {
            this.stack?.Push(item);
            Console.WriteLine($"Добавили в стек: {item}");
        }

        public void Pop()
        {
            T item = this.stack.Pop();
            Console.WriteLine($"Вытащили из стека: {item}");
        }

        public void Peek()
        {
            T item = this.stack.Peek();
            Console.WriteLine($"Верхний элемент в стеке: {item}");
        }

        public void Print()
        {
            this.stack.Print();
        }

        public void IsEmpty()
        {
            bool isEmpty = this.stack.IsEmpty;
            if ( isEmpty )
            {
                Console.WriteLine("Стек пуст");
            }
            else
            {
                Console.WriteLine("Стек не пуст");
            }
        }

        public void Count()
        {
            Console.WriteLine($"Размер стека: {this.stack.Count}");
        }
    }
}
