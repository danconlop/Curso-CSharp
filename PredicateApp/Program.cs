using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1;
            string input2;

            Console.WriteLine("Select your filter option:");
            Console.WriteLine("1) by Age\n2) by Name\n3) by Color\n4) by Birthday\n5) Is it sterlized?\nEnter your option:");
            var option = Console.ReadLine();

            if (Int32.TryParse(option, out int filter))
                switch (filter)
                {
                    case 1:
                        Console.WriteLine("Enter age:");
                        input1 = Console.ReadLine();
                        Searcher(filter, input1, null);
                        break;
                    case 2:
                        Console.WriteLine("Enter name:");
                        input1 = Console.ReadLine();
                        Searcher(filter, input1, null);
                        break;
                    case 3:
                        Console.WriteLine("Enter color:");
                        input1 = Console.ReadLine();
                        Searcher(filter, input1, null);
                        break;
                    case 4:
                        Console.WriteLine("Enter start date:");
                        input1 = Console.ReadLine();
                        Console.WriteLine("Enter end date:");
                        input2 = Console.ReadLine();
                        Searcher(filter, input1, input2);
                        break;
                    case 5:
                        Console.WriteLine("Enter sterilized status (y/n):");
                        input1 = Console.ReadLine();
                        Searcher(filter, input1, null);
                        break;
                    default:
                        break;
                }


            static void Searcher(int option, string input, string input2)
            {
                User.Option = option;
                User.Input = input;
                User.Input2 = input2;

                // Predicates
                Predicate<Pet> predicateByAge = new Predicate<Pet>(Pet.GetByAge);
                Predicate<Pet> predicateByName = new Predicate<Pet>(Pet.GetByName);
                Predicate<Pet> predicateByColor = new Predicate<Pet>(Pet.GetByColor);
                Predicate<Pet> predicateBySterilized = new Predicate<Pet>(Pet.GetBySterilized);
                Predicate<Pet> predicateByBirthday = new Predicate<Pet>(Pet.GetByDate);
                // List
                List<Pet> pet = new List<Pet>()
                {
                    new Pet(){Age = 3, Name = "Benny", Color = "Gris", Birthday = new DateTime(2019, 6, 1), Sterilized = false},
                    new Pet(){Age = 2, Name = "Aghata", Color = "Negro", Birthday = new DateTime(2020, 1, 10), Sterilized = true},
                    new Pet(){Age = 4, Name = "Lucha", Color = "Beige", Birthday = new DateTime(2018, 2, 8), Sterilized = true},
                    new Pet(){Age = 5, Name = "Buffy", Color = "Naranja", Birthday = new DateTime(2017, 1, 6), Sterilized = false},
                    new Pet(){Age = 5, Name = "Coco", Color = "Blanco", Birthday = new DateTime(2017, 2, 25), Sterilized = true},
                    new Pet(){Age = 5, Name = "Thor", Color = "Blanco", Birthday = new DateTime(2017, 1, 4), Sterilized = false},
                    new Pet(){Age = 3, Name = "Simba", Color = "Gris", Birthday = new DateTime(2019, 3, 3), Sterilized = false},
                    new Pet(){Age = 4, Name = "Toby", Color = "Negro", Birthday = new DateTime(2018, 5, 11), Sterilized = true},
                    new Pet(){Age = 4, Name = "Lucas", Color = "Atigrado", Birthday = new DateTime(2018, 12, 12), Sterilized = true},
                    new Pet(){Age = 1, Name = "Leo", Color = "Atrigrado", Birthday = new DateTime(2021, 11, 5), Sterilized = false},
                    new Pet(){Age = 1, Name = "Manchas", Color = "Naranja", Birthday = new DateTime(2021, 10, 18), Sterilized = true},
                    new Pet(){Age = 1, Name = "Max", Color = "Calico", Birthday = new DateTime(2021, 9, 20), Sterilized = false},
                    new Pet(){Age = 2, Name = "Rocky", Color = "Calico", Birthday = new DateTime(2020, 9, 21), Sterilized = true},
                    new Pet(){Age = 2, Name = "Bruno", Color = "Blanco", Birthday = new DateTime(2020, 7, 12), Sterilized = true},
                    new Pet(){Age = 3, Name = "Remi", Color = "Beige", Birthday = new DateTime(2019, 3, 2), Sterilized = false},
                    new Pet(){Age = 5, Name = "Apolo", Color = "Blanco", Birthday = new DateTime(2017, 1, 3), Sterilized = true},
                    new Pet(){Age = 5, Name = "Garfield", Color = "Negro", Birthday = new DateTime(2017, 2, 4), Sterilized = false},
                    new Pet(){Age = 6, Name = "Lucky", Color = "Negro", Birthday = new DateTime(2016, 4, 4), Sterilized = true},
                    new Pet(){Age = 7, Name = "Lola", Color = "Gris", Birthday = new DateTime(2015, 4, 3), Sterilized = true},
                    new Pet(){Age = 7, Name = "Taco", Color = "Naranja", Birthday = new DateTime(2015, 3, 25), Sterilized = false}
                };

                switch (User.Option)
                {
                    case 1:
                        // by Age (Int)
                        var resultByAge = pet.FindAll(predicateByAge);

                        if (resultByAge.Any())
                        {
                            Console.WriteLine("We found these pets:");
                            foreach (var item in resultByAge)
                            {
                                Console.WriteLine($"Name: {item.Name} Age: {item.Age} Color: {item.Color} Birthday: {item.Birthday.ToShortDateString()} Sterilized status: {item.Sterilized}");
                            }
                        }
                        break;
                    case 2:
                        // byName (String)
                        if (pet.Exists(predicateByName))
                        {
                            Console.WriteLine("The pet exists");
                        }
                        break;
                    case 3:
                        // byColor (String)
                        var resultByColor = pet.FindAll(predicateByColor);

                        if (resultByColor.Any())
                        {
                            Console.WriteLine("We found these pets:");
                            foreach (var item in resultByColor)
                            {
                                Console.WriteLine($"Name: {item.Name} Age: {item.Age} Color: {item.Color} Birthday: {item.Birthday.ToShortDateString()} Sterilized status: {item.Sterilized}");
                            }
                        }
                        break;
                    case 4:
                        // byDate (DateTime)
                        var resultByBirthday = pet.FindAll(predicateByBirthday);

                        if (resultByBirthday.Any())
                        {
                            Console.WriteLine("We found these pets:");
                            foreach (var item in resultByBirthday)
                            {
                                Console.WriteLine($"Name: {item.Name} Age: {item.Age} Color: {item.Color} Birthday: {item.Birthday.ToShortDateString()} Sterilized status: {item.Sterilized}");
                            }
                        }
                        break;
                    case 5:
                        // bySterilized (Bool)
                        var resultBySterilized = pet.FindAll(predicateBySterilized);

                        if (resultBySterilized.Any())
                        {
                            Console.WriteLine("We found these pets:");
                            foreach (var item in resultBySterilized)
                            {
                                Console.WriteLine($"Name: {item.Name} Age: {item.Age} Color: {item.Color} Birthday: {item.Birthday.ToShortDateString()} Sterilized status: {item.Sterilized}");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        class Pet
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public DateTime Birthday { get; set; }
            public bool Sterilized { get; set; }

            // By Age
            public static bool GetByAge(Pet pet)
            {
                var isNumber = Int32.TryParse(User.Input, out int age);

                if (isNumber)
                    return pet.Age.Equals(age);
                else
                    return false;
            }

            public static bool GetByName(Pet pet)
            {
                return pet.Name.ToUpper().Equals(User.Input.ToUpper());
            }

            public static bool GetByColor(Pet pet)
            {
                return pet.Color.Equals(User.Input);
            }
            public static bool GetByDate(Pet pet)
            {
                var isDate1 = DateTime.TryParse(User.Input, out DateTime date1);
                var isDate2 = DateTime.TryParse(User.Input2, out DateTime date2);

                if (isDate1 && isDate2)
                    return (pet.Birthday >= date1 && pet.Birthday <= date2);
                else
                    return false;
            }
            public static bool GetBySterilized(Pet pet)
            {
                bool status = User.Input.ToUpper().Equals("Y") ? true : false;
                return pet.Sterilized.Equals(status);
            }
        }

        class User
        {
            public static int Option { get; set; }
            public static string Input { get; set; }
            public static string Input2 { get; set; }
        }
    }
}
