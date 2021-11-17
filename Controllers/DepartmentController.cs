using EasyERP.Data;
using EasyERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EasyERP.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext context;

        public DepartmentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await context.Departments.ToListAsync();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            
            if(ModelState.IsValid)
            {
                await context.Departments.AddAsync(department);
                await context.SaveChangesAsync();
                
            }
            return View();
        }
    }
}
