using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tu.shapes.ClassLibraryShapes
{
    public class InvalidValueExeption: Exception
    {
        public InvalidValueExeption(string message)
            :base(message)
        { }
    }
}
