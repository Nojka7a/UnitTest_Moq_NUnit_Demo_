using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExample
{
    public class Customer : ICustomer
    {
        private int id;
        private string name;

        public Customer(string name, int id)
        {
            this.id = id;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Id
        {
            get { return this.id; }
        }
    }
}
