using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public interface ICustomer
    {
        string Name { get; set; }

         void GetProduct(string msg);
    }
}
