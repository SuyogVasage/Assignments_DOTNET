﻿using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CS_WebApp.Controllers
{
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
            var result = employeeService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.Department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
            var emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                var result = employeeService.CreateAsync(employee).Result;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.NewMessage = "Please Enter Correct Data";
                return View(employee);
            }
            
        }
        
        /// <summary>
        /// The http get request must pass the 
        /// Route parameter as 'id' (
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var result = employeeService.GetAsync(id).Result;

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

      
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}

