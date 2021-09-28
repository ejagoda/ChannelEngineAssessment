using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChannelEngineAssessmentLogic.Model
{
    public class CollectionOfOrders : IEnumerable<Order>
    {
        public IEnumerable<Order> Orders { get; set; }

        public CollectionOfOrders(IEnumerable<Order> orders)
        {
            Orders = orders ?? new List<Order>();
        }
        
        public Dictionary<string, int> GetTopSoldProductsIds(int number)
        {
            var order = Orders.SelectMany(o => o.Lines).GroupBy(l => l.MerchantProductNo).OrderByDescending(g => g.Sum(l => l.Quantity)).Take(number);
            return order.ToDictionary(pair => pair.Key, pair => pair.Sum(g => g.Quantity));
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return Orders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Orders.GetEnumerator();
        }
    }
}
