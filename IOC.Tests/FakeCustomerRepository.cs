using InversionOfControlExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private int methodInvocationCounter;
        private bool isAddMethodCalled;

        public FakeCustomerRepository()
        {
            methodInvocationCounter = 0;
            isAddMethodCalled = false;  
        }

        public bool IsAddMethodCalled
        {
            get { return this.isAddMethodCalled; }
        }

        public int MethodInvocationCounter 
        {
            get { return this.methodInvocationCounter; }   
        }

        public void Add(InversionOfControlExample.ICustomer customer)
        {
            isAddMethodCalled = true;
            methodInvocationCounter++;
        }

        public IEnumerable<InversionOfControlExample.ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
