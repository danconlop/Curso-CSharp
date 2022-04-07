using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Reminder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Regex regex = new Regex(@"(((0[1-9]|1[0-2])\/(0|1)[0-9]|2[0-9]|3[0-1])\/((19|20)\d\d))$");

            Console.WriteLine("What's your event name?");
            var eventName = Console.ReadLine();
            if (String.IsNullOrEmpty(eventName))
            {
                Console.WriteLine("You haven't specified your event name!");
                return;
            }

            Console.WriteLine("What is the date or your event? enter format date (mm/dd/yyyy)");
            var eventDate = Console.ReadLine();
            if (!DateTime.TryParse(eventDate, out DateTime parsedEventDate) || !regex.IsMatch(eventDate))
            {
                Console.WriteLine("your event date format is incorrect");
                return;
            }

            Console.WriteLine("How many days do you want me to remind you before your event?");
            var days = Console.ReadLine();
            if (!Int32.TryParse(days, out int remindDays))
            {
                Console.WriteLine("Invalid number of days entered");
                return;
            }

            Console.WriteLine("Enter current date:");
            var currentDate = Console.ReadLine();
            if (!DateTime.TryParse(currentDate, out DateTime parsedCurrentDate) || !regex.IsMatch(currentDate))
            {
                Console.WriteLine("your current date format is incorrect");
                return;
            }

            if (parsedCurrentDate.Date < parsedEventDate.Date)
            {
                // Ejecuta metodo
                await Reminder.Remind(parsedCurrentDate, parsedEventDate, remindDays);

                Console.WriteLine("\nYour event is today!");
            } else
            {
                Console.WriteLine("\nThe event date is older than the current date");
            }
        }

        public class Reminder
        {
            public static async Task Remind(DateTime currentDate, DateTime eventDate, int remindDays)
            {
                DateTime newDate = currentDate;
                long totalDays = (eventDate.Date - currentDate.Date).Days;

                for (int i = 1; i < totalDays; i++)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    newDate = newDate.AddDays(1);

                    if ((totalDays - i) <= remindDays)
                        Console.WriteLine((totalDays - i) + " remaining");
                    else
                        Console.WriteLine(newDate.ToShortDateString());
                }
            }
        }
    }
}
