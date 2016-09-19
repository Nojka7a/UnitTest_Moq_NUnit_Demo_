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
            this.ID = id;
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }
            }
        }

        public int ID
        {
            get { return this.id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be less than or equal to 0!");
                }
            }
        }
    }
}
