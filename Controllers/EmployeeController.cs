using EasyERP.Data;
using EasyERP.Models;
using EasyERP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EasyERP.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await context.Employees.Include(m => m.Department).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var findById = await context.Employees.SingleOrDefaultAsync(m => m.Id == id);

            if (findById == null)
            {
                return NotFound();
            }

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = findById,
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel, int? id)
        {
            if (ModelState.IsValid)
            {
                var findById = await context.Employees.FindAsync(id);
                findById.FirstName = employeeViewModel.Employee.FirstName;
                findById.LastName = employeeViewModel.Employee.LastName;
                findById.DepartmentId = employeeViewModel.Employee.DepartmentId;
                findById.Country = employeeViewModel.Employee.Country;
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var findById = await context.Employees.SingleOrDefaultAsync(m => m.Id == id);

            if (findById == null)
            {
                return NotFound();
            }

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Employee = findById,
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeViewModel, int? id)
        {
            if (ModelState.IsValid)
            {
                var findById = await context.Employees.FindAsync(id);
                context.Employees.Remove(findById);
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(employeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> RetriveData()
        {
            return Json(new { data = await context.Employees.Include(m => m.Department).ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJson(int id)
        {
            var findById = await context.Employees.FindAsync(id);
            if (findById == null)
            {
                return Json(new { success = false, message = "Not Found !" });
            }

            context.Remove(findById);
            await context.SaveChangesAsync();

            return Json(new { success = true, message = "Successfully Deleted!!!!" });
        }

    }
}
