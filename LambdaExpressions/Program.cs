using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a number:");
            var inputX = Console.ReadLine();
            Console.WriteLine("Please insert a second number:");
            var inputY = Console.ReadLine();

            if (Double.TryParse(inputX, out double x) && Double.TryParse(inputY, out double y))
            {
                Console.WriteLine("\nOperations using DELEGATES");
                DelegateCalculator.Operate(x, y);
                Console.WriteLine("\nOperations using FUNC");
                FunctionCalculator.Lambda(x, y);
            }
            else
                Console.WriteLine("Please insert a valid number.");
        }

        class DelegateCalculator
        {
            public delegate double SelfOperator(double x);
            public delegate double Operator(double x, double y);
            public static void Operate(double num, double num2)
            {
                SelfOperator square = new SelfOperator(x => x * x);
                Console.WriteLine($"The first square operation result is: {square(num)}\tThe second square operation result is: {square(num2)}");

                Operator addition = new Operator((x, y) => x + y);
                Console.WriteLine($"Adittion equals to: {addition(num, num2)}");

                Operator substraction = new Operator((x, y) => x - y);
                Console.WriteLine($"Substraction result is: {substraction(num, num2)}");

                Operator division = new Operator((x, y) => x / y);
                Console.WriteLine($"Division result is: {division(num, num2)}");

                Operator multiplication = new Operator((x, y) => x * y);
                Console.WriteLine($"Multiplication result is: {multiplication(num, num2)}");

                SelfOperator sin = new SelfOperator(x => Math.Sin(x));
                Console.WriteLine($"First sin is: {sin(num)}\tSecond sin is: {sin(num2)}");

                SelfOperator cos = new SelfOperator(x => Math.Cos(x));
                Console.WriteLine($"First cos is: {cos(num)}\tSecond cos is: {cos(num2)}");
                
            }
        }

        class FunctionCalculator
        {
            public static void Lambda(double x, double y)
            {

                Func<double, double> square = (x => x * x);
                Console.WriteLine($"The first square operation result is: {square(x)}\tThe second square operation result is: {square(y)}");

                Func<double, double, double> addition = (x, y) => x + y;
                Console.WriteLine($"Adittion equals to: {addition(x, y)}");

                Func<double, double, double> substraction = (x, y) => x - y;
                Console.WriteLine($"Substraction result is: {substraction(x, y)}");

                Func<double, double, double> division = (x, y) => x / y;
                Console.WriteLine($"Division result is: {division(x, y)}");

                Func<double, double, double> multiplication = (x, y) => x * y;
                Console.WriteLine($"Multiplication result is: {multiplication(x, y)}");

                Func<double, double> sin = (x => Math.Sin(x));
                Console.WriteLine($"First sin is: {sin(x)}\tSecond sin is: {sin(y)}");

                Func<double, double> cos = (x => Math.Cos(x));
                Console.WriteLine($"First cos is: {cos(x)}\tSecond cos is: {cos(y)}");
            }
            
        }
    }
}
