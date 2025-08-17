using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    public interface IFactory
    {
        IAxis CreateAxis();
        IIO CreateIO();
    }

    public class InovanceFactory : IFactory
    {
        public IAxis CreateAxis()
        {
            return new InovanceAxis();
        }

        public IIO CreateIO()
        {
            return new InovanceIO();
        }
    }
    public class MutsubishiFactory : IFactory
    {
        public IAxis CreateAxis()
        {
            return new MutsubishiAxis();
        }

        public IIO CreateIO()
        {
            return new MutsubishiIO();
        }
    }
}
