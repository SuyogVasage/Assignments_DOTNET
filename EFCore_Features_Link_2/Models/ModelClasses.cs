using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Features_Link_2.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FisrtName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }   
        public string Email { get; set; }
    }
}
