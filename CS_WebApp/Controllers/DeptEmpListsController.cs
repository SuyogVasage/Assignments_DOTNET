using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CS_WebApp.Controllers
{
    public class DeptEmpListsController : Controller
    {
        private readonly IService<Department, int> deptServ;
        private readonly IService<Employee, int> empServ;
        List<Employee> empList = new List<Employee>();
        List<Department> deptList = new List<Department>(); 
        public DeptEmpListsController(IService<Department, int> deptServ, IService<Employee, int> empServ)
        {
            this.deptServ = deptServ;
            this.empServ = empServ;
        }
        public IActionResult Index(int id = 0)
        {

            var deptemp = new DeptEmpList();
            deptemp.Departments = deptServ.GetAsync().Result.ToList();
            if (id == 0)
            {
                ViewBag.Department = new SelectList(deptServ.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                deptemp.Employees = empServ.GetAsync().Result.ToList();
            }
            else
            {
                ViewBag.Department = new SelectList(deptServ.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                deptemp.Employees = empServ.GetAsync().Result.Where(e => e.DeptNo == id).ToList();
            }

            var Resultant = from e in deptemp.Employees
                            join d in deptemp.Departments on
                            e.DeptNo equals d.DeptNo
                            select new
                            {
                                EmpNo = e.EmpNo,
                                EmpName = e.EmpName,
                                Salary = e.Salary,
                                Designation = e.Designation,
                                DeptName = d.DeptName,
                                Tax = e.Tax,
                                Email = e.Email
                            };
            deptemp.EmployeeDatas = new List<EmployeeData>();
            foreach (var d in Resultant)
            {
                deptemp.EmployeeDatas.Add(new EmployeeData() { EmpNo = d.EmpNo, EmpName = d.EmpName, Salary = d.Salary, Designation = d.Designation, DeptName = d.DeptName, Tax = d.Tax, Email = d.Email });
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

