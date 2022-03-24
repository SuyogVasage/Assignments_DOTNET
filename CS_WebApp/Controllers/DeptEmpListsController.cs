using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CS_WebApp.Controllers
{
    public class DeptEmpListsController : Controller
    {
        private readonly IService<Department, int> deptServ;
        private readonly IService<Employee, int> empServ;
        public DeptEmpListsController(IService<Department, int> deptServ, IService<Employee, int> empServ)
        {
            this.deptServ = deptServ;
            this.empServ = empServ;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Department = new SelectList(deptServ.GetAsync().Result.ToList(), "DeptNo", "DeptName");
            var deptemp = new DeptEmpList();
            deptemp.Departments = deptServ.GetAsync().Result.ToList();
            if (id == 0)
            {
                deptemp.Employees = empServ.GetAsync().Result.ToList();
            }
            else
            {
                deptemp.Employees = empServ.GetAsync().Result.Where(e => e.DeptNo == id).ToList();
            }
            return View(deptemp);
        }
        public IActionResult ShowEmps(DeptEmpList dept)
        {
            int deptNo = dept.DeptNo;
            // return to Index View with a Route Parameter
            return RedirectToAction("Index", new { id = deptNo });
        }
    }
}

