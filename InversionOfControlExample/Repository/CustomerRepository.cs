using System;
using System.Collections.Generic;
using System.Linq;
namespace InversionOfControlExample.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private ICollection<ICustomer> customers;

        public CustomerRepository()
        {
            this.customers = new List<ICustomer>();
        }

        public void Add(ICustomer customer)
        {
            this.customers.Add(customer);
        }


        public IEnumerable<ICustomer> GetAll()
        {
            return this.customers;
        }
    }
}
