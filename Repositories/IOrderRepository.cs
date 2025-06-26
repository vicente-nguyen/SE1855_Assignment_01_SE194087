using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IOrderRepository
    {
        public List<Orders> getAllOrders();
        public bool CreateOrder(Orders orders);
        public bool UpdateOrder(Orders orders);
        public bool DeleteOrder(Orders orders);
    }
}
