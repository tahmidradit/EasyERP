using System.Collections.Generic;
using System.Linq;
using EasyERP.Data;
using EasyERP.Models;
using EasyERP.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyERP.RepositoryService
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> EmployeeList;
        public ApplicationDbContext Context { get; }
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.Context = context;
            EmployeeList = context.Employees.Include(m => m.Department).ToList();
        }
        public Employee Add(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee Delete(int Id)
        {
            Employee employee = EmployeeList.FirstOrDefault(m => m.Id == Id);

            if(employee != null)
            {
                EmployeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployee(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = EmployeeList.FirstOrDefault(m => m.Id == employeeChanges.Id);

            if(employee != null)
            {
                employee.FirstName = employeeChanges.FirstName;
                employee.LastName = employeeChanges.LastName;
                employee.DepartmentId = employeeChanges.DepartmentId;
                employee.Country = employeeChanges.Country;
            }
            return employee;
        }
    }
}