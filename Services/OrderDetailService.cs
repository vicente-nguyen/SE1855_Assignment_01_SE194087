using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;
using Repositories;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailRepository irepository;
        public OrderDetailService()
        {
            irepository = new OrderDetailRepository();
        }
        public bool CreateOrderDetail(OrderDetails orderDetails)
        {
            return irepository.CreateOrderDetail(orderDetails);
        }

        public bool DeleteOrderDetail(OrderDetails orderDetails)
        {
            return irepository.DeleteOrderDetail(orderDetails);
        }

        public List<OrderDetails> getAllOrderDetails()
        {
            return irepository.getAllOrderDetails();
        }

        public List<Order_Detail> GetDetailsByOrder(int orderID)
        {
            return irepository.GetDetailsByOrder(orderID);
        }

        public bool UpdateOrderDetail(OrderDetails orderDetails)
        {
            return irepository.UpdateOrderDetail(orderDetails);
        }
    }
}
