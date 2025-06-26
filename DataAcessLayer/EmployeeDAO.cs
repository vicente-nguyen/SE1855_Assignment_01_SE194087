using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAcessLayer
{
    public class EmployeeDAO
    {
        private const string ConnectionString = @"server=localhost;database=Lucy_SalesData;uid=sa;pwd=12345";
        lucyDataContext context = new lucyDataContext(ConnectionString);
        public bool AuthEmployee(Employees employees)
        {
            Employee old = context.Employees.FirstOrDefault(e => e.UserName.Equals(employees.UserName) && e.Password.Equals(employees.Password));
            if (old != null)
            {
                return true;
            }
            return false;
        }
    }
}
