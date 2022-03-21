using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using CS_WebApp.Services;
using CS_WebApp;
using CS_WebApp.Controllers;
namespace CS_WebApp.Models
{
    public class DeptNoCapacityAttribute : ValidationAttribute
    {
        DeptCapacity deptCapacity = new DeptCapacity();
        public override bool IsValid(object value)
        {
            int result = deptCapacity.DeptNoCount(value);
            int capacity = deptCapacity.Capacity(value);

            if (result < capacity)
            {
                return false;
            }
            return true;
        }
    }
}
