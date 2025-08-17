using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************简单工厂***********************");
            SimpleAxisFactory _simpleAxisFactory = new SimpleAxisFactory();
            try
            {
                var axis1 = _simpleAxisFactory.CreateAxis("Inovance");
                axis1.DoSth();
                var axis2 = _simpleAxisFactory.CreateAxis("Mutsubishi");
                axis2.DoSth();
                var axis3 = _simpleAxisFactory.CreateAxis("Pansonic");
                axis3.DoSth();
            }
            catch (Exception e)
            {
                Console.WriteLine($"创建失败，【{e.Message}】");
            }

            Console.WriteLine("");
            Console.WriteLine("***********************简单工厂_反射***********************");
            SimpleAxisFactory_Ref _simpleAxisFactory_Ref = new SimpleAxisFactory_Ref();
            try
            {
                var axis1 = _simpleAxisFactory_Ref.CreateAxis("Inovance");
                axis1.DoSth();
                var axis2 = _simpleAxisFactory_Ref.CreateAxis("Mutsubishi");
                axis2.DoSth();
                var axis3 = _simpleAxisFactory_Ref.CreateAxis("Pansonic");
                axis3.DoSth();
            }
            catch (Exception e)
            {
                Console.WriteLine($"创建失败，【{e.Message}】");
            }

            Console.WriteLine("");
            Console.WriteLine("***********************工厂方法***********************");
            IAxisFactory _axisFactory;
            _axisFactory = new InovanceAxisFactory();
            var axis11 = _axisFactory.CreateAxis();
            axis11.DoSth();
            _axisFactory = new MutsubishiAxisFactory();
            var axis12 = _axisFactory.CreateAxis();
            axis12.DoSth();

            Console.WriteLine("");
            Console.WriteLine("***********************抽象工厂***********************");
            IFactory _factory;
            _factory = new InovanceFactory();
            var axis21 = _factory.CreateAxis();
            var io1 = _factory.CreateIO();
            axis11.DoSth();
            io1.DoSth();
            _factory = new MutsubishiFactory();
            var axis22 = _factory.CreateAxis();
            var io2 = _factory.CreateIO();
            axis12.DoSth();
            io2.DoSth();

            Console.ReadLine();
        }
    }
}
