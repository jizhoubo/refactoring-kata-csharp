using System.Collections.Generic;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();
        public IList<Order> AllOrders => _orders;
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public Order GetOrder(int i)
        {
            return _orders[i];
        }
    }
}
