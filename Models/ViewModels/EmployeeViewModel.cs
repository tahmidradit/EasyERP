using System.Collections.Generic;

namespace EasyERP.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
