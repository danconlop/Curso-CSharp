using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Employee employees = new Employee();
            Supervisor manager = new Supervisor();
            bool loggedIn=false;

            do
            {
                var empLoggedIn = employees.Login();
                do
                {
                    if (empLoggedIn is Employee)
                    {
                        loggedIn = true;
                        switch (empLoggedIn.UserType)
                        {
                            case "E":
                                //TODO: MOSTRAR MENU
                                empLoggedIn.Operation(employees.employees);
                                break;
                            case "M":
                                

                                // TODO: MOSTRAR MENU
                                Console.WriteLine(employees.PersonList(employees.employees));
                                break;
                        }
                    }
                } while (loggedIn);
            } while (!loggedIn);
        }
    }

    class User
    {
        public static string inputUsername { get; set; }
        public static string inputPassword { get; set; }
        public static string Input { get; set; }
    }
}
