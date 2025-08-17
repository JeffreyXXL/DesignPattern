using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Factory
{
    public class SimpleAxisFactory
    {
        public IAxis CreateAxis(string type)
        {
            switch (type)
            {
                case "Inovance":
                    return new InovanceAxis();

                case "Mutsubishi":
                    return new MutsubishiAxis();

                default:
                    throw new Exception($"{type}类型未配置");
            }
        }
    }

    public class SimpleAxisFactory_Ref
    {
        public IAxis CreateAxis(string type)
        {
            var instanceType = Type.GetType("_02_Factory." + type + "Axis");
            if (instanceType != null && typeof(IAxis).IsAssignableFrom(instanceType))
            {
                var axisInstance = (IAxis)Activator.CreateInstance(instanceType);
                return axisInstance;
            }
            else
            {
                throw new Exception($"{type}类型未配置");
            }
        }
    }
}
