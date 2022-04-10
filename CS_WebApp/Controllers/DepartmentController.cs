using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System;
using CS_WebApp.CustomSession;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CS_WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Department, int> departmentService;
        /// <summary>
        /// Inject The IService<Department, int> aka DeptService in it
        /// </summary>
        public DepartmentController(IService<Department, int> service)
        {
            departmentService = service;
        }
        public IActionResult Index()
        {
            var result = departmentService.GetAsync().Result;
            return View(result);
        }
        //Securing actions
        [Authorize]
        public IActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            //try
            //{
              
                    if (ModelState.IsValid)
                    {
                        var dept = departmentService.GetAsync(department.DeptNo);
                        if (dept.Result != null)
                        {
                            throw new Exception($"Department No {department.DeptNo} is already present");
                        }
                        var result = departmentService.CreateAsync(department).Result;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.NewMessage = "Please Enter Correct Data";
                        //Stay on same page
                        return View(department);
                    }
                
                //If no error then process values
                
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
        [Authorize]
        public IActionResult Edit(int id)
        {
                var result = departmentService.GetAsync(id).Result;

                //return a view the record to be edited
                return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if(ModelState.IsValid)
            {
                var result = departmentService.UpdateAsync(id, department).Result;
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
            
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var result = departmentService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
            //var result = departmentService.GetAsync(id).Result;
            //return View(result);
        }
        public IActionResult ShowEmployees(int id)
        {
            // Save DeptNo in session
            //HttpContext.Session.SetInt32("DeptNo", id);
            ////Get the department objet based on id
            //var dept = departmentService.GetAsync(id).Result;
            ////Save the object in session

            //HttpContext.Session.SetObject<Department>("Dept", dept);

            return RedirectToAction("Index", "Employee");
        }


        //Directly Delete and will not go for another view
        //[HttpPost]
        //public IActionResult Delete(int id, Department department)
        //{
        //    var result = departmentService.DeleteAsync(id).Result;
        //    return RedirectToAction("Index");
        //}
    }
}

////The HTML Helper Method
////parametr 1 The Link Name
////parametr 2 The action method tha will be invokdes with HttpGet Request
////parametr 3 The anonymous Type that represnt route values aka parametr to be passed to action methods
