using InversionOfControlExample.Exceptions;
using InversionOfControlExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IOC.Tests
{
    public class FakeCustomerRepository2 : ICustomerRepository
    {

        public void Add(InversionOfControlExample.ICustomer customer)
        {
            throw new AddCustomerException();
        }

        public IEnumerable<InversionOfControlExample.ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
   
}
