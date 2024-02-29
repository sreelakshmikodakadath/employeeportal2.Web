using EmployeePortal.Web.Data;
using EmployeePortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Web.Controllers
{
    public class Employeescontroller : Controller
    {
        public Employeescontroller(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new EmployeePortal
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Desription
            };
            await DbContext.Employees.AddAsync();
            await DbContext.SaveChangesAsync();
            return View();
        }
    }
}
