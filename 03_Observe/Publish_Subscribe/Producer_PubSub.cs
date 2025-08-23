using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public class Producer_PubSub
    {
        public void Publish(ProductType productType,string msg)
        {
            EventBus.Instance.Publish(productType, msg);
        }

    }
}
