using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    public interface IAxis
    {
        void DoSth();
    }

    public class InovanceAxis : IAxis
    {
        public void DoSth()
        {
            Console.WriteLine("这是一个汇川的轴。");
        }
    }
    public class MutsubishiAxis : IAxis
    {
        public void DoSth()
        {
            Console.WriteLine("这是一个三菱的轴。");
        }
    }
}
