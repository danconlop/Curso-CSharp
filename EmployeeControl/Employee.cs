using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    class Employee
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime Antiquity { get; set; }
        public int HoursWorked { get; set; }

        Predicate<Employee> predicateByName = new Predicate<Employee>(Employee.Exists);
        private static List<Employee> dataSeed = new List<Employee>() {
                new Employee(){Name="Daniel Contreras", Username="dcontreras", Password="123", UserType="E", Antiquity = new DateTime(2019,12,30), HoursWorked = 0},
                new Employee(){Name="Ernesto Perez", Username="eperez", Password="123", UserType="E", Antiquity=new DateTime(2019, 6, 1), HoursWorked = 0},
                new Employee(){Name="Osvaldo Hernandez", Username="ohernandez", Password="123", UserType="E", Antiquity=new DateTime(2020, 6, 1), HoursWorked = 0},
                new Employee(){Name="Ricardo Juarez", Username="rjuarez", Password="123", UserType="E", Antiquity=new DateTime(2021, 6, 1), HoursWorked = 0},
                new Employee(){Name="Elena Garcia", Username="egarcia", Password="123", UserType="E", Antiquity=new DateTime(2016, 6, 1), HoursWorked = 0},
                new Employee(){Name="Daniel Hernandez", Username="dhernandez", Password="123", UserType="E", Antiquity=new DateTime(2022, 2, 1), HoursWorked = 0},
                new Employee(){Name="Silvia Gomez", Username="sgomez", Password="123", UserType="M", Antiquity=new DateTime(2015, 6, 1), HoursWorked = 0},
        };
        public List<Employee> employees = new List<Employee>();
        public Employee() : base() { employees = dataSeed; }
        public Employee(string empName, string empUsername, string empPassword, string empUsertype, DateTime empAntiquity, int hoursWorked)
        {
            Name = empName;
            Username = empUsername;
            Password = empPassword;
            UserType = empUsertype;
            Antiquity = empAntiquity;
            HoursWorked = hoursWorked;
        }

        public Employee Login()
        {
            Console.WriteLine("Welcome to the employee control system\nPlease enter your credentials\n\n");
            Console.Write("Username: ");
            var inputUsername = Console.ReadLine();
            if (string.IsNullOrEmpty(inputUsername))
            {
                Console.WriteLine("Wrong input, please enter your username");
                return default;
            }

            Console.Write("Password: ");
            var inputPassword = Console.ReadLine();
            if (string.IsNullOrEmpty(inputPassword))
            {
                Console.WriteLine("Wrong input, please enter your password");
                return default;
            }

            User.inputUsername = inputUsername.ToUpper();
            User.inputPassword = inputPassword.ToUpper();

            if (employees.Exists(predicateByName))
            {
                var user = employees.Find(predicateByName);

                if (user.Username.ToUpper().Equals(User.inputUsername) && user.Password.ToUpper().Equals(User.inputPassword))
                {
                    // TODO: Felicitar si ya cumplió un año
                    return user;
                }
                else
                {
                    Console.WriteLine("Wrong credentials");
                    return default;
                }
            }
            else
            {
                Console.WriteLine("Username entered does not exist");
                return default;
            }
        }

        public virtual void Operation(List<Employee> emp)
        {
            Console.WriteLine("Please register your hours worked: ");
            var inputHoursWorked = Console.ReadLine();
            if (Int32.TryParse(inputHoursWorked, out int parsedHoursWorked))
            {
                HoursWorked = parsedHoursWorked;
                var itemIndex = emp.FindIndex(predicateByName);

                emp[itemIndex].HoursWorked = HoursWorked;
            }
            else
            {
                Console.WriteLine("Wrong input, please enter a number");
            }
        }

        public string PersonList(List<Employee> emp)
        {
            var report = new StringBuilder();
            int i=0;
            report.AppendLine($"Number\t\tName\t\tHours registered");
            foreach(var item in emp)
            {
                i++;
                report.AppendLine($"{i}\t\t{item.Name}\t\t{item.HoursWorked}");
            }
            return report.ToString();
        }

        public static bool Exists(Employee emp)
        {
            return (emp.Username.ToUpper().Equals(User.inputUsername));
        }
    }
}
