using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using CS_WebApp.Services;
using CS_WebApp;
using CS_WebApp.Controllers;
using System.Text.RegularExpressions;

namespace CS_WebApp.Models
{
    public class IsEmpNameAttribute : ValidationAttribute  
    {
        public override bool IsValid(object value)
        {
            Regex re = new Regex("[A-Z][A-Za-z ]+[A-Za-z]$");
            if (re.IsMatch(Convert.ToString(value)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

