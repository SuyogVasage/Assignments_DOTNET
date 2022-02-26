using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //7) Can we have same property in base and derived class?
   //>> Yes,but gives warning derived class property hide base class property.Instead use 'new' to avoid warning.

    public class Q_11
    {
        public string name { get; set; }
    }
    public class Q_ : Q_11
    {
        public new string name { get; set; }
    }
}
