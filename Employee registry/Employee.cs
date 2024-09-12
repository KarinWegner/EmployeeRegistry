using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_registry
{
    using Employee_registry;
    internal class Employee
    {
        private string name;
        private int salary;

        public Employee(string n, int s)
        {
            name = n;
            salary = s;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string n)
        {
            name = n;
        }
        public int GetSalary()
        {
            return salary;
        }
        public void SetSalary(int s)
        {
            salary = s;
        }
    }
}
