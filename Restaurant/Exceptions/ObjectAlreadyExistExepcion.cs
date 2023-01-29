using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ObjectAlreadyExistExepcion : Exception
    {
        public ObjectAlreadyExistExepcion(string objName) : base(objName) { }
    }
}
