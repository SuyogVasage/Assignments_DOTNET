using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Naukari_24March.Models
{
    public class IsFullNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex re = new Regex("^([a-zA-Z]+( [a-zA-Z]+)+)$");
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

    public class IsMobileNoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex re = new Regex(@"^[0-9]{10}$");
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

    public class IsEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex re = new Regex("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9+.-]+$");
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

    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
        }
    }

    public class IsPercentageAttribute : ValidationAttribute  
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToDouble(value) >= 35 && Convert.ToDouble(value) <= 100)
            {
                return true;
            }
            return false;
        }
    }
}
