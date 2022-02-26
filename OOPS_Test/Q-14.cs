using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //14) What will happen if the derive class does not override all abstract methods of the abstract class?
    //  >> Gives error that derived class not implement abstarct method.
    public abstract class OOPTestBase
    {
        public abstract void Method11();
        public abstract void Method22();
    }

    public class OOPTest : OOPTestBase
    {
        public override void Method11()
        {
            
        }
        public override void Method22()
        {

        }
    }
}
