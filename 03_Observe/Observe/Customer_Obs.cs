using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public class Customer_Obs : ICustomer
    {
        public string Name { get; set; }

        public Customer_Obs(string name)
        {
            Name = name;
        }

        public void GetProduct(string msg)
        {
            Console.WriteLine($"观察者{Name}收到产品{msg}。");
        }
    }
}
