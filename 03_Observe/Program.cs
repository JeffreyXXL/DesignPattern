using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************观察者模式***********************");
            Producer_Obs productFactory = new Producer_Obs();
            Customer_Obs customerA = new Customer_Obs("客户A");
            Customer_Obs customerB = new Customer_Obs("客户B");
            Customer_Obs customerC = new Customer_Obs("客户C");
            Console.WriteLine("客户订阅***********************");
            productFactory.Subscribe(customerA);
            productFactory.Subscribe(customerB);
            productFactory.Subscribe(customerC);
            productFactory.Publish("新产品1");
            productFactory.Unsubscribe(customerB);
            productFactory.Publish("新产品2");

            Console.WriteLine();
            Console.WriteLine("***********************发布订阅模式***********************");
            Producer_PubSub producer_PubSub = new Producer_PubSub();
            Customer_PubSub customer_PubSubA = new Customer_PubSub("订阅者A");
            Customer_PubSub customer_PubSubB = new Customer_PubSub("订阅者B");
            Customer_PubSub customer_PubSubC = new Customer_PubSub("订阅者C");
            customer_PubSubA.Subscribe(ProductType.ProductA);
            customer_PubSubA.Subscribe(ProductType.ProductB);
            customer_PubSubA.Subscribe(ProductType.ProductC);
            customer_PubSubB.Subscribe(ProductType.ProductB);
            customer_PubSubB.Subscribe(ProductType.ProductC);
            customer_PubSubC.Subscribe(ProductType.ProductC);
            producer_PubSub.Publish(ProductType.ProductA, "产品A型号1");
            producer_PubSub.Publish(ProductType.ProductB, "产品B型号1");
            producer_PubSub.Publish(ProductType.ProductC, "产品C型号1");
            customer_PubSubA.Unsubscribe(ProductType.ProductC);
            customer_PubSubB.Unsubscribe(ProductType.ProductC);
            customer_PubSubC.Unsubscribe(ProductType.ProductC);
            producer_PubSub.Publish(ProductType.ProductA, "产品A型号2");
            producer_PubSub.Publish(ProductType.ProductB, "产品B型号2");
            producer_PubSub.Publish(ProductType.ProductC, "产品C型号2");
        }
    }
}
