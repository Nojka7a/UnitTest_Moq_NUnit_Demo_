using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InversionOfControlExample
{
    public interface ICustomer
    {
        string Name { get; set; }
        int ID { get; set; }
    }
}
