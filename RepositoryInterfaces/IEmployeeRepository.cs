using System.Collections.Generic;
using EasyERP.Models;

namespace EasyERP.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
         Employee GetEmployee(int Id);
         IEnumerable<Employee> GetAllEmployee();
         Employee Add(Employee employee);
         Employee Update(Employee employeeChanges);
         Employee Delete(int Id);
    }
}