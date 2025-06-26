using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAcessLayer
{
    public class OrderDAO
    {
        private const string ConnectionString = @"server=localhost;database=Lucy_SalesData;uid=sa;pwd=12345";
        lucyDataContext context = new lucyDataContext(ConnectionString);
        public List<Orders> getAllOrders()
        {
            return context.Orders
                .Select(p => new Orders
                {
                    OrderID = p.OrderID,
                    CustomerID = p.CustomerID,
                    EmployeeID = p.EmployeeID,
                    OrderDate = p.OrderDate
                })
                .ToList();
        }

        public bool CreateOrder(Orders orders)
        {
            Order old = context.Orders.FirstOrDefault(o => o.OrderID == orders.OrderID);
            if (old != null)
            {
                return false;
            }
            Order newOrder = new Order
            {
                OrderID = orders.OrderID,
                CustomerID = orders.CustomerID,
                EmployeeID = orders.EmployeeID,
                OrderDate = orders.OrderDate
            };
            context.Orders.InsertOnSubmit(newOrder);
            context.SubmitChanges();
            return true;
        }

        public bool UpdateOrder(Orders orders)
        {
            Order old = context.Orders.FirstOrDefault(o => o.OrderID == orders.OrderID);
            if (old == null)
            {
                return false;
            }
            old.OrderID = orders.OrderID;
            old.CustomerID = orders.CustomerID;
            old.EmployeeID = orders.EmployeeID;
            old.OrderDate = orders.OrderDate;
            context.SubmitChanges();
            return true;
        }

        public bool DeleteOrder(Orders orders)
        {
            Order old = context.Orders.FirstOrDefault(o => o.OrderID == orders.OrderID);
            if (old == null)
            {
                return false;
            }
            context.Orders.DeleteOnSubmit(old);
            context.SubmitChanges();
            return true;
        }
    }
}
