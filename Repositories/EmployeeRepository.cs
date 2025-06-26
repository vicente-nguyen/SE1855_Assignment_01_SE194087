using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();
        public bool AuthEmployee(Employees employees)
        {
            return employeeDAO.AuthEmployee(employees);
        }
    }
}
