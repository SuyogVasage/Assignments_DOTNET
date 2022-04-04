using System.ComponentModel.DataAnnotations;
using System;

namespace WebAPI.Models
{
    public class NonNegativeAttribute : ValidationAttribute
    {
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool IsValid(object value)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
