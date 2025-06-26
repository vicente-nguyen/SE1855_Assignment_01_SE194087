using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAcessLayer
{

    public class CustomerDAO
    {
        private const string ConnectionString = @"server=localhost;database=Lucy_SalesData;uid=sa;pwd=12345";
        lucyDataContext context = new lucyDataContext(ConnectionString);

        public bool AuthCustomer(Customers customer)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.Phone.Equals(customer.Phone));
            if (old != null)
            {
                return true;
            }
            return false;
        }

        public List<Customers> getAllCustomers()
        {
            return context.Customers
                .Select(c => new Customers
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    Phone = c.Phone
                })
                .ToList();
        }

        public bool CreateCustomer(Customers customer)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (old != null)
            {
                return false;
            }

            // Map BusinessObjects.Customers to DataAcessLayer.Customer
            Customer newCustomer = new Customer
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                Phone = customer.Phone
            };

            context.Customers.InsertOnSubmit(newCustomer);
            context.SubmitChanges();
            return true;
        }

        public bool UpdateCustomer(Customers customer)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (old == null)
            {
                return false;
            }
            old.CompanyName = customer.CompanyName;
            old.ContactName = customer.ContactName;
            old.ContactTitle = customer.ContactTitle;
            old.Address = customer.Address;
            old.Phone = customer.Phone;
            context.SubmitChanges();
            return true;
        }

        public bool DeleteCustomer(Customers customer)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (old == null)
            {
                return false;
            }
            context.Customers.DeleteOnSubmit(old);
            context.SubmitChanges();
            return true;
        }
        public Customers GetCustByPhone(string phone)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.Phone.Equals(phone));
            if (old == null) return null;
            // Map DataAcessLayer.Customer to BusinessObjects.Customers
            return new Customers
            {
                CustomerID = old.CustomerID,
                CompanyName = old.CompanyName,
                ContactName = old.ContactName,
                ContactTitle = old.ContactTitle,
                Address = old.Address,
                Phone = old.Phone
            };
        }
        public Customers GetCustomerById(int id)
        {
            Customer old = context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (old == null) return null;
            // Map DataAcessLayer.Customer to BusinessObjects.Customers
            return new Customers
            {
                CustomerID = old.CustomerID,
                CompanyName = old.CompanyName,
                ContactName = old.ContactName,
                ContactTitle = old.ContactTitle,
                Address = old.Address,
                Phone = old.Phone
            };
        }
    }
}
