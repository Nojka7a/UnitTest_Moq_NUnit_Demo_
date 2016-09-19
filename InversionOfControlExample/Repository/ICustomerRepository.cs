using System;
using System.Collections.Generic;
namespace InversionOfControlExample.Repository
{
    public interface ICustomerRepository
    {
        void Add(ICustomer customer);

        IEnumerable<ICustomer> GetAll();
    }
}
