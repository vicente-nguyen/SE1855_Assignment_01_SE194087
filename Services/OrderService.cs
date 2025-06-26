using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository irepository;
        public OrderService()
        {
            irepository = new OrderRepository();
        }
        public bool CreateOrder(Orders orders)
        {
            return irepository.CreateOrder(orders);
        }

        public bool DeleteOrder(Orders orders)
        {
            return irepository.DeleteOrder(orders);
        }

        public List<Orders> getAllOrders()
        {
            return irepository.getAllOrders();
        }

        public bool UpdateOrder(Orders orders)
        {
            return irepository.UpdateOrder(orders);
        }
    }
}
