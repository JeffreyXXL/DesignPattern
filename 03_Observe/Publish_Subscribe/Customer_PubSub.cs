using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public class Customer_PubSub
    {
        public string Name { get; set; }

        public Customer_PubSub(string name)
        {
            Name = name;
        }

        public void Subscribe(ProductType productType)
        {
            Console.WriteLine($"{Name}订阅了产品{productType}");
            EventBus.Instance.Subscribe(productType, GetProduct);
        }

        public void Unsubscribe(ProductType productType)
        {
            Console.WriteLine($"{Name}取消订阅了产品{productType}");
            EventBus.Instance.Unsubscribe(productType, GetProduct);
        }

        private void GetProduct(string msg)
        {
            Console.WriteLine($"订阅者{Name}收到产品-{msg}。");
        }
    }
}
