using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetails> getAllOrderDetails();
        public bool CreateOrderDetail(OrderDetails orderDetails);
        public bool UpdateOrderDetail(OrderDetails orderDetails);
        public bool DeleteOrderDetail(OrderDetails orderDetails);
        public List<Order_Detail> GetDetailsByOrder(int orderID);
    }
}
