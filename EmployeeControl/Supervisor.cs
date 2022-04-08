using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    class Supervisor : Employee
    {
        public Supervisor() : base() { }
        public Supervisor(string empName, string empUsername, string empPassword, string empUsertype, DateTime empAntiquity, int empHoursWorked) : base(empName, empUsername, empPassword, empUsertype, empAntiquity, empHoursWorked)
        {
        }

        public virtual void Operation(List<Employee> emp)
        {
            // TODO: mostrar menu de opciones
            
        }
    }
}
