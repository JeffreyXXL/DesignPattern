using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    public interface IIO
    {
        void DoSth();
    }

    public class InovanceIO : IIO
    {
        public void DoSth()
        {
            Console.WriteLine("这是一个汇川的IO。");
        }
    }
    public class MutsubishiIO : IIO
    {
        public void DoSth()
        {
            Console.WriteLine("这是一个三菱的IO。");
        }
    }
}
