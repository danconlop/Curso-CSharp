using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {


            // Documentación:
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference


            passwordValidator();
        }

        static void DomainValidation()
        {
            var domain = "https://www.something.com";
            Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
            Console.WriteLine(regex.IsMatch(domain));
        }

        static void phoneNumber()
        {
            var phoneNumber = "+52 (686) 405 4720";
            Regex regex = new Regex(@"[\+]([\d]{2})([ ])([\(])([\d]{3})([\)])([ ])([\d]{3})([ ])([\d]{4})$");
            Console.WriteLine(regex.IsMatch(phoneNumber));
        }

        static void passwordValidator()
        {
            /* Debe contener:
             * minimo 8 caracteres
             * al menos una mayuscula
             * al menos una minuscula
             * al menos un caracter especial */
              
            var password = "sm1S1(1a";
            //Regex regex = new Regex(@"^.*(?=.{8,})(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\@\*\?\!]).*$");
            Regex regex = new Regex(@"^\S*(?=.{8,})(?=\S*[0-9])(?=\S*[a-z])(?=\S*[A-Z])(?=\S*[\@\*\?\!])\S*$");
            Console.WriteLine(regex.IsMatch(password));
        }
    }
}
