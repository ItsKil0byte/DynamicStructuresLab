using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.Controllers
{
    public interface IBinaryTreeController
    {
        public void Insert(string item);
        public void Has(string item);
        public void InOrderTraversal();
        public void Print();
        public void Depth();
    }
}
