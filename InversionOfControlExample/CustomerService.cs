using InversionOfControlExample.Exceptions;
using InversionOfControlExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InversionOfControlExample
{
    public class CustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService (ICustomerRepository repository)
	    {
            this.repository = repository;
	    }

        public void CreateCustomer(string name, int id)
        {
            var customer = new Customer(name, id);

            if (this.repository == null)
            {
                throw new ArgumentNullException("repository cannot be null");
            }

            try
            {
                this.repository.Add(customer);
            }
            catch (AddCustomerException inner)
            {
                //AddCustomerException -> inner for CreateCustomerException
                //outer exception -  CreateCustomerException because of the method CreateCustomer
                //трябва да знаем при хвърляне и хващане на грешката CreateCustomerException, коя грешка го е причинила (inner = AddCustomerException)
                throw new CreateCustomerException("Cannot create customer", inner);
            }
           
        }

        public IEnumerable<ICustomer> GetAllCustomersWhere(Func<ICustomer, bool> predicate)
        {
            return this.repository.GetAll().Where(predicate);
        }
    }
}
