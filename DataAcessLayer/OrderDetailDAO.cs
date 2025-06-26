using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAcessLayer
{
    public class OrderDetailDAO
    {
        private const string ConnectionString = @"server=localhost;database=Lucy_SalesData;uid=sa;pwd=12345";
        lucyDataContext context = new lucyDataContext(ConnectionString);
        public List<OrderDetails> getAllOrderDetails()
        {
            return context.Order_Details
                .Select(od => new OrderDetails
                {
                    OrderID = od.OrderID,
                    ProductID = od.ProductID,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
                .ToList();
        }
        public bool CreateOrderDetail(OrderDetails orderDetails)
        {
            Order_Detail old = context.Order_Details.FirstOrDefault(od => od.OrderID == orderDetails.OrderID && od.ProductID == orderDetails.ProductID);
            if (old != null)
            {
                return false;
            }
            Order_Detail newOrderDetail = new Order_Detail
            {
                OrderID = orderDetails.OrderID,
                ProductID = orderDetails.ProductID,
                UnitPrice = orderDetails.UnitPrice,
                Quantity = (short)orderDetails.Quantity,
                Discount = (float)orderDetails.Discount
            };
            context.Order_Details.InsertOnSubmit(newOrderDetail);
            context.SubmitChanges();
            return true;
        }
        public bool UpdateOrderDetail(OrderDetails orderDetails)
        {
            Order_Detail old = context.Order_Details.FirstOrDefault(od => od.OrderID == orderDetails.OrderID && od.ProductID == orderDetails.ProductID);
            if (old == null)
            {
                return false;
            }
            old.UnitPrice = orderDetails.UnitPrice;
            old.Quantity = (short)orderDetails.Quantity;
            old.Discount = (float)orderDetails.Discount;
            context.SubmitChanges();
            return true;
        }
        public bool DeleteOrderDetail(OrderDetails orderDetails)
        {
            Order_Detail old = context.Order_Details.FirstOrDefault(od => od.OrderID == orderDetails.OrderID && od.ProductID == orderDetails.ProductID);
            if (old == null)
            {
                return false;
            }
            context.Order_Details.DeleteOnSubmit(old);
            context.SubmitChanges();
            return true;
        }
        public List<Order_Detail> GetDetailsByOrder(int orderID)
        {
            var ls = context.Order_Details.Where(p => p.OrderID == orderID).ToList();
            return ls;
        }
    }
}
