using EmployeeWeb.Data;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWeb.Controllers
{
    [Authorize]
    public class EmployeeController(EMDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var employees = await context.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            TempData["Success"] = "Employee created successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            context.Employees.Update(employee);
            await context.SaveChangesAsync();

            TempData["Success"] = "Employee updated successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }

            TempData["Success"] = "Employee deleted successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}