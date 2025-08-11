using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1、普通调用
            var instance1 = new Common();
            var instance2 = new Common();
            CheckInstance(instance1, instance2);

            //2、懒汉式加载
            var lazyInstance1 = Singleton_Lazy_DoubleCheck.GetInstance();
            var lazyInstance2 = Singleton_Lazy_DoubleCheck.GetInstance();
            CheckInstance(lazyInstance1, lazyInstance2);

            //3、饿汉式加载
            var eagerInstance1 = Singleton_Eager.Instance;
            var eagerInstance2 = Singleton_Eager.Instance;
            CheckInstance(eagerInstance1, eagerInstance2);

            //4、Lazy<T>延时加载
            var lazyTInstance1 = Singleton_LazyT.Instance;
            var lazyTInstance2 = Singleton_LazyT.Instance;
            CheckInstance(lazyTInstance1, lazyTInstance2);

            //5、容器加载
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Singleton_Container>().SingleInstance();
            builder.RegisterType<Common_Container>();

            //容器单例
            IContainer container = builder.Build();
            var containerInstance1 = container.Resolve<Singleton_Container>();
            var containerInstance2 = container.Resolve<Singleton_Container>();
            CheckInstance(containerInstance1, containerInstance2);

            //容器普通
            var containerCommonInstance1 = container.Resolve<Common_Container>();
            var containerCommonInstance2 = container.Resolve<Common_Container>();
            CheckInstance(containerCommonInstance1, containerCommonInstance2);

            Console.Read();
        }

        /// <summary>
        /// 判断是否式同一个实例
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        private static void CheckInstance(object obj1, object obj2)
        {
            Console.WriteLine($"************************【{obj1.GetType().Name}】************************");
            //检查是不是同一个实例
            Console.WriteLine($"两个实例是否是相同实例：{object.ReferenceEquals(obj1, obj2)}");
            //查看哈希地址
            int hash1 = RuntimeHelpers.GetHashCode(obj1);
            int hash2 = RuntimeHelpers.GetHashCode(obj2);
            Console.WriteLine($"obj1 的哈希地址是{hash1}");
            Console.WriteLine($"obj2 的哈希地址是{hash2}");
            if (hash1 == hash2)
            {
                Console.WriteLine($"********** obj1 和 obj2 的哈希地址相同");
            }
            else
            {
                Console.WriteLine($"********** obj1 和 obj2 的哈希地址不同");
            }
            Console.WriteLine("");
        }
    }
}
