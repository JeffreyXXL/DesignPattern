using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Observe
{
    public class EventBus
    {
        private static readonly Lazy<EventBus> _eventBus = new Lazy<EventBus>(() => new EventBus());

        public static EventBus Instance => _eventBus.Value;

        private readonly ConcurrentDictionary<ProductType, List<Action<string>>> _subscribers = new ConcurrentDictionary<ProductType, List<Action<string>>>();

        public void Subscribe(ProductType productType, Action<string> action)
        {
            var actions = _subscribers.GetOrAdd(productType, x => new List<Action<string>>());
            lock (actions)
            {
                actions.Add(action);
            }
        }

        public void Unsubscribe(ProductType productType, Action<string> action)
        {

            _subscribers.TryGetValue(productType, out var actions);
            lock (actions)
            {
                actions?.Remove(action);
            }
        }

        public void Publish(ProductType productType, string msg)
        {
            if (_subscribers.TryGetValue(productType, out var actions))
            {
                lock (actions)
                {
                    foreach (var action in actions)
                    {
                        action.Invoke(msg);
                    }
                }
            }
        }
    }

    public enum ProductType
    {
        ProductA,
        ProductB,
        ProductC
    }
}
