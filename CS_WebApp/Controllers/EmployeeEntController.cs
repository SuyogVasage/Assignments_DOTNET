using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
namespace CS_WebApp.Controllers
{
    public class EmployeeEntController : Controller
    {
        EmployeeEnts employees;

        public EmployeeEntController()
        {
            employees = new EmployeeEnts();
        }
        public IActionResult Index()
        {
            return View(employees);
        }
    }
}
