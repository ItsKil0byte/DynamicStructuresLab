using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Controllers
{
    public class Controller
    {
        private bool _fromFile = false;

        public void SetFromFile()
        {
            this._fromFile = true;
        }

        public void SetFromConsole()
        {
            this._fromFile = false;
        }

        protected void WaitUser()
        {
            if (this._fromFile) 
            {
                return;
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }
}
