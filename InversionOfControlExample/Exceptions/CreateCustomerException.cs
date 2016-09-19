using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InversionOfControlExample.Exceptions
{
    public class CreateCustomerException : Exception
    {
        public CreateCustomerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
