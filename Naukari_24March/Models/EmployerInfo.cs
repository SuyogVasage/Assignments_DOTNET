using System;
using System.Collections.Generic;

namespace Naukari_24March.Models
{
    public partial class EmployerInfo
    {
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CompanyHeadquarters { get; set; }
        public int NumberOfBranches { get; set; }
        public string LogoPath { get; set; }
        public string UserId { get; set; }
    }
}
