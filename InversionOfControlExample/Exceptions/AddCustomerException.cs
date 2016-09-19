using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InversionOfControlExample.Exceptions
{
    public class AddCustomerException : Exception
    {

        public AddCustomerException()
            :base()
        { }
        public AddCustomerException(string message, Exception innerException) 
            : base(message, innerException)
        { }
    }
}
