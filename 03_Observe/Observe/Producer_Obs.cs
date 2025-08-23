using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public class Producer_Obs
    {
        private readonly List<ICustomer> _customers = new List<ICustomer>();

        public void Subscribe(ICustomer customer)
        {
            _customers.Add(customer);
            Console.WriteLine($"观察者{customer.Name}直接订阅。");
        }

        public void Unsubscribe(ICustomer customer)
        {
            _customers.Remove(customer);
            Console.WriteLine($"观察者{customer.Name}取消订阅。");
        }

        public void Publish(string msg)
        {
            Console.WriteLine($"*****************发布{msg}。");
            foreach (ICustomer customer in _customers)
            {
                customer.GetProduct(msg);
            }
        }
    }
}
