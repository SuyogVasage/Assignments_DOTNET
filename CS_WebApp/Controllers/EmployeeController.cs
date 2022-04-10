using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using CS_WebApp.CustomSession;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace CS_WebApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IService<Employee, int> employeeService;
        private readonly IService<Department, int> deptService;
        /// <summary>
        /// Inject The IService<Employee, int> aka EmpService in it
        /// </summary>
        public EmployeeController(IService<Employee, int> service, IService<Department, int> deptService)
        {
            employeeService = service;
            this.deptService = deptService;

        }
        public IActionResult Index()
        {
            var resEmp = employeeService.GetAsync().Result;
            var deptres = deptService.GetAsync().Result;
             var Resultant = from e in resEmp
                             join d in deptres on
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
            List<EmployeeData> employees = new List<EmployeeData>();
            foreach (var d in Resultant)
            {
                employees.Add(new EmployeeData() { EmpNo = d.EmpNo, EmpName = d.EmpName, Salary = d.Salary, Designation = d.Designation, DeptName = d.DeptName, Tax = d.Tax, Email = d.Email });
            }
            //IEnumerable<Employee> res;

           // read DeptNo from Session

            //int DeptNo = Convert.ToInt32(HttpContext.Session.GetInt32("DeptNo"));
            //// read the Dept object from the session
            //var dept = HttpContext.Session.GetObject<Department>("Dept");
            //if (DeptNo == 0)
            //{
            //    res = employeeService.GetAsync().Result;
            //}
            //else
            //{
            //    res = employeeService.GetAsync().Result.Where(e => e.DeptNo == DeptNo);
            //}
            return View(employees);
            //var result = employeeService.GetAsync().Result;
            //return View(result);
        }

        public IActionResult Create()
        {
            //Our Method for DropDownList
            ViewBag.Department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
            var emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            //try
            //{

                if (ModelState.IsValid) 
                {
                var emp = employeeService.GetAsync(employee.EmpNo);
                if (emp.Result != null)
                {
                    throw new Exception($"Employee No {employee.EmpNo} is already present");
                }
                int capacity = deptService.GetAsync().Result.ToList().Where(x => x.DeptNo == employee.DeptNo).Select(x => x.Capacity).FirstOrDefault();
                int countofemployee = employeeService.GetAsync().Result.ToList().Where(x => x.DeptNo == employee.DeptNo).Count();
                if (capacity > countofemployee)
                    {
                        var result = employeeService.CreateAsync(employee).Result;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                        ViewBag.NewMessage = "Department Capacity is full";
                        return View(employee);
                    }
                    
                }
                else
                {
                    ViewBag.Department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                    ViewBag.NewMessage = "Please Enter Correct Data";
                    return View(employee);
                }
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new ErrorViewModel()
            //    {
            //        ControllerName = RouteData.Values["controller"].ToString(),
            //        ActionName = RouteData.Values["action"].ToString(),
            //        ErrorMessage = ex.Message
            //    });
            //}
            
        }
        
        /// <summary>
        /// The http get request must pass the 
        /// Route parameter as 'id' (
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            //Sir's Method For DropDownList Using ViewBag
            var result = employeeService.GetAsync(id).Result;
            List<SelectListItem> depts = new List<SelectListItem>();
            foreach (var d in deptService.GetAsync().Result.ToList())
            {
                depts.Add(new SelectListItem(d.DeptName, d.DeptNo.ToString()));
            }
            // ViewBag.DeptNo = new SelectList(depts, "DeptNo", "DeptName");
            ViewBag.DeptNo = depts;
            //return a view the record to be edited
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = employeeService.UpdateAsync(id, employee).Result;
                return RedirectToAction("Index"); 
            }
            else
            {
                List<SelectListItem> depts = new List<SelectListItem>();
                foreach (var d in deptService.GetAsync().Result.ToList())
                {
                    depts.Add(new SelectListItem(d.DeptName, d.DeptNo.ToString()));
                }
                // ViewBag.DeptNo = new SelectList(depts, "DeptNo", "DeptName");
                ViewBag.DeptNo = depts;
                return View(employee);
            }
        }

        public IActionResult Delete(int id)
        {
            var result = employeeService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
            //var result = employeeService.GetAsync(id).Result;
            //return View(result);
        }

        //[HttpPost]
        //public IActionResult Delete(int id, Employee employee)  
        //{
        //    var result = employeeService.DeleteAsync(id).Result;
        //    return RedirectToAction("Index");
        //}

        public IActionResult Details(int id)
        {
            var result = employeeService.GetAsync(id).Result;
            return View(result);
        }

        public IActionResult ValidateEmpName(string EmpName)
        {
            
            Regex re = new Regex("^([a-zA-Z]+( [a-zA-Z]+)+)$");
            if (re.IsMatch(EmpName))
            {
               return Json(true); // valid
            }
            return Json(false); // invalid 
        }

        
    }
}

