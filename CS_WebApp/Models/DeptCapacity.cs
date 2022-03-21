using System.ComponentModel.DataAnnotations;
using System;
using CS_WebApp.Models;
using System.Linq;
using CS_WebApp.Services;
using CS_WebApp;
using Microsoft.AspNetCore.Mvc;

namespace CS_WebApp.Models
{
    public class DeptCapacity : Controller
    {
        private readonly IService<Employee, int> employeeService;
        private readonly IService<Department, int> deptService;

        public DeptCapacity(IService<Employee, int> employeeservice, IService<Department, int> deptService)
        {
            this.employeeService = employeeservice;
            this.deptService = deptService;
        }

        public DeptCapacity()
        {

        }


        public int DeptNoCount(object value)
        {
            var result = employeeService.GetAsync().Result.Where(x => x.DeptNo == Convert.ToInt32(value)).Select(y=> y.EmpNo).Count();
            return result;
        }

        public int Capacity(object value)  
        {
            var capacity = deptService.GetAsync().Result.Where(x => x.DeptNo == Convert.ToInt32(value)).Select(x => x.Capacity).FirstOrDefault();
            return capacity;
        }
    }
}
