﻿using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;

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

        public IActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            //If no error then process values
            if (ModelState.IsValid)
            {
                var result = departmentService.CreateAsync(department).Result;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.NewMessage = "Please Enter Correct Data";
                //Stay on same page
                return View(department);
            }
            
        }

        /// <summary>
        /// The http get request must pass the 
        /// Route parameter as 'id' (
        /// </summary>
        /// <returns></returns>
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

        public IActionResult Delete(int id)
        {
            var result = departmentService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
            //var result = departmentService.GetAsync(id).Result;
            //return View(result);
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

////// /* The HTML Helper Method
////parametr 1 The Link Name
////                 parametr 2 The action method tha will be invokdes with HttpGet Request
////                 parametr 3 The anonymous Type that represnt route values aka parametr to be passed to action methods*/
