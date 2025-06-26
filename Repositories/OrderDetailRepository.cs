using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
        public bool CreateOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailDAO.CreateOrderDetail(orderDetails);
        }

        public bool DeleteOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailDAO.DeleteOrderDetail(orderDetails);
        }

        public List<OrderDetails> getAllOrderDetails()
        {
            return orderDetailDAO.getAllOrderDetails();
        }

        public List<Order_Detail> GetDetailsByOrder(int orderID)
        {
            return orderDetailDAO.GetDetailsByOrder(orderID);
        }

        public bool UpdateOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailDAO.UpdateOrderDetail(orderDetails);
        }
    }
}
