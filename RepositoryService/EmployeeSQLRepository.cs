using System.Collections.Generic;
using EasyERP.Data;
using EasyERP.Models;
using EasyERP.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyERP.RepositoryService
{
    public class EmployeeSQLRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeSQLRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);

            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees.Include(m => m.Department);
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}