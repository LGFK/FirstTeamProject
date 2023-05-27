using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTry.Model
{
    internal class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        
        public Customer(int _age,String _id, String _name)
        {
            Age = _age;
            Name = _name;
            Id = _id;
        }
        

    }
}
