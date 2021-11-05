using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Employee
    {
        public string name  { get; set; }
        public string surname { get; }
       
        
        public Employee(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        
    }
}
