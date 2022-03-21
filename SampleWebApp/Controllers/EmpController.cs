using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class EmpController : Controller
    {
        EmployeeEnts employees;

        public EmpController()  
        {
            employees = new EmployeeEnts();
        }
        public IActionResult Index()
        {
            return View(employees);
        }
    }
}
