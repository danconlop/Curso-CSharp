using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatesWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search: ");
            var input = Console.ReadLine();

            Searcher(input);

            // Métodos
            static void Searcher(string input)
            {
                User.Input = input;

                Predicate<Person> predicateByName = new Predicate<Person>(Person.Exists);
                Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);
                Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetByDate);

                List<Person> people = new List<Person>()
                {
                    new Person() {Name = "Gildardo", Age = 27, Birthday = new DateTime(1995, 6, 25)},
                    new Person() {Name = "Rene", Age = 31, Birthday = new DateTime(1991, 1, 25)},
                    new Person() {Name = "Alejandra", Age = 27, Birthday = new DateTime(1995, 2, 25)},
                    new Person() {Name = "Osvaldo", Age = 27, Birthday = new DateTime(1995, 6, 1)}
                };

                if (people.Exists(predicateByName))
                    Console.WriteLine("The user exists.");
                else
                {
                    var result = people.FindAll(predicateByAge);

                    if (result.Any())
                    {
                        Console.WriteLine("We found these names:");

                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                    else
                    {
                        var resultDate = people.FindAll(predicateByBirthday);

                        if (resultDate.Any())
                        {
                            Console.WriteLine("We found these persons:");

                            foreach(var item in resultDate)
                            {
                                Console.WriteLine("Name: " + item.Name + " Birthday: " + item.Birthday.ToLongDateString());
                            }
                        } else
                        {
                            Console.WriteLine("We did not find any names.");
                        }
                    }
                }
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
            public static bool Exists(Person person)
            {
                return (person.Name.Equals(User.Input));
            }

            public static bool GetByAge(Person person)
            {
                var isNumber = Int32.TryParse(User.Input, out int age);

                if (isNumber)
                    return person.Age.Equals(age);
                else
                    return false;
            }

            public static bool GetByDate(Person person)
            {
                var isDate = DateTime.TryParse(User.Input, out DateTime birthday);

                if (isDate)
                    return (person.Birthday.Year.Equals(birthday.Year) && person.Birthday.Month.Equals(birthday.Month));
                else
                    return false;
            }
        }

        class User
        {
            public static string Input { get; set; }
        }
    }
}
