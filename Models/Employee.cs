using System.ComponentModel.DataAnnotations;

namespace EasyERP.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(80), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string Country { get; set; }

    }
}
