using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //6) Can we have public property in abstract base class?
    //>> Yes
    public abstract class Q_6
    {
        public string Name { get; set; }
    }
    class Q_7 : Q_6
    {

    }
}
