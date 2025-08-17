using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    public interface IAxisFactory
    {
        IAxis CreateAxis();
    }

    public class InovanceAxisFactory : IAxisFactory
    {
        public IAxis CreateAxis()
        {
            return new InovanceAxis();
        }
    }
    public class MutsubishiAxisFactory : IAxisFactory
    {
        public IAxis CreateAxis()
        {
            return new MutsubishiAxis();
        }
    }

}
