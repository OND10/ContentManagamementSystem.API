using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Common.Exceptions
{
    public class IdNullException : Exception
    {
        public IdNullException(string message):base(message) 
        {
        }
    }
}
