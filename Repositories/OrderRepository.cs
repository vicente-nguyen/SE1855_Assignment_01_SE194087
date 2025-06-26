using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OrderDAO OrderDAO = new OrderDAO();
        public bool CreateOrder(Orders orders)
        {
            return OrderDAO.CreateOrder(orders);
        }

        public bool DeleteOrder(Orders orders)
        {
            return OrderDAO.DeleteOrder(orders);
        }

        public List<Orders> getAllOrders()
        {
            return OrderDAO.getAllOrders();
        }

        public bool UpdateOrder(Orders orders)
        {
            return OrderDAO.UpdateOrder(orders);
        }
    }
}
