using EmployeeWeb.Data;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmployeeWeb.Controllers
{
    public class AccountController(EMDbContext context) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var admin = await context.Admins
                .FirstOrDefaultAsync(a => a.Username == model.Username
                                       && a.Password == model.Password);

            if (admin == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View(model);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, admin.Username ?? string.Empty)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}