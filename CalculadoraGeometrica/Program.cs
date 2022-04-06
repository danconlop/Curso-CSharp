using System;

namespace CalculadoraGeometrica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the figure to calculate");
            Console.WriteLine("1) Cuadrado\n2) Rectángulo\n3) Triángulo\n4) Círculo");
            var opcionFigura = Console.ReadLine();

            if (Int32.TryParse(opcionFigura, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        // Cuadrado
                        Console.WriteLine("Ingrese la medida de un lado del cuadrado:");
                        var num = Console.ReadLine();
                        if (double.TryParse(num, out double x))
                            DelegateCalculator.Operate(opcion, x, 0);
                            FunctionCalculator.Operate(opcion, x, 0);
                        break;
                    case 2:
                        // Rectangulo
                        Console.WriteLine("Ingrese la medida de la base:");
                        var num1 = Console.ReadLine();
                        Console.WriteLine("Ingrese la medida de la altura:");
                        var num2 = Console.ReadLine();
                        if (double.TryParse(num1, out double recBase) && double.TryParse(num2, out double recAltura))
                        {
                            DelegateCalculator.Operate(opcion, recBase, recAltura);
                            FunctionCalculator.Operate(opcion, recBase, recAltura);
                        }
                        break;
                    case 3:
                        // Triangulo
                        Console.WriteLine("Ingrese la medida de un lado del triangulo:");
                        var num3 = Console.ReadLine();
                        if (double.TryParse(num3, out double ladoTriangulo))
                            DelegateCalculator.Operate(opcion, ladoTriangulo, 0);
                            FunctionCalculator.Operate(opcion, ladoTriangulo, 0);
                        break;
                    case 4:
                        // Circulo
                        Console.WriteLine("Ingrese el radio del círculo");
                        var num4 = Console.ReadLine();
                        if (double.TryParse(num4, out double radioCirculo))
                            DelegateCalculator.Operate(opcion, radioCirculo, 0);
                            FunctionCalculator.Operate(opcion, radioCirculo, 0);
                        break;
                }
            } else
            {
                Console.WriteLine("Ingresó una opción incorrecta");
            }
        }

        class DelegateCalculator
        {
            public delegate double SingleOperator(double x);
            public delegate double DoubleOperator(double x, double y);

            public static void Operate(int opcion, double num, double num2)
            {
                Console.WriteLine("Cálculo realizado con DELEGATES");
                switch (opcion)
                {
                    case 1: // CUADRADO
                        SingleOperator cuadradoArea = new SingleOperator(x => x * x);
                        SingleOperator cuadradoPerimetro = new SingleOperator(x => x * 4);
                        Console.WriteLine($"Datos calculados del cuadrado: Area ({cuadradoArea(num)}) Perímetro({cuadradoPerimetro(num)})");
                        break;
                    case 2: // RECTANGULO
                        DoubleOperator rectanguloArea = new DoubleOperator((x, y) => x * y);
                        DoubleOperator rectanguloPerimetro = new DoubleOperator((x, y) => (x * 2) + (y * 2));
                        Console.WriteLine($"Datos calculados del rectangulo: Area ({rectanguloArea(num, num2)}) Perímetro({rectanguloPerimetro(num, num2)})");
                        break;
                    case 3: // TRIANGULO
                        SingleOperator trianguloArea = new SingleOperator(x => (x * x) / 2);
                        SingleOperator trianguloPerimetro = new SingleOperator(x => x * 3);
                        Console.WriteLine($"Datos calculados del triangulo: Area ({trianguloArea(num)}) Perímetro ({trianguloPerimetro(num)})");
                        break;
                    case 4: // CIRCULO
                        SingleOperator circuloArea = new SingleOperator(x => 3.14 * (x * x));
                        SingleOperator circuloPerimetro = new SingleOperator(x => (2 * 3.14) * x);
                        Console.WriteLine($"Datos calculados del circulo: Area ({circuloArea(num)}) Perímetro ({circuloPerimetro(num)})");
                        break;
                    default:
                        break;
                }

            }
        }

        class FunctionCalculator
        {
            public static void Operate(int opcion, double num, double num2)
            {
                Console.WriteLine("Cálculo realizado con FUNC");
                switch (opcion)
                {
                    case 1: // CUADRADO
                        Func<double, double> cuadradoArea = (x => x * x);
                        Func<double, double> cuadradoPerimetro = (x => x * 4);
                        Console.WriteLine($"Datos calculados del cuadrado: Area ({cuadradoArea(num)}) Perímetro({cuadradoPerimetro(num)})");
                        break;
                    case 2: // RECTANGULO
                        Func<double, double, double> rectanguloArea = ((x, y) => x * y);
                        Func<double, double, double> rectanguloPerimetro = ((x, y) => (x * 2) + (y * 2));
                        Console.WriteLine($"Datos calculados del rectangulo: Area ({rectanguloArea(num, num2)}) Perímetro({rectanguloPerimetro(num, num2)})");
                        break;
                    case 3: // TRIANGULO
                        Func<double, double> trianguloArea = (x => (x * x) / 2);
                        Func<double, double> trianguloPerimetro = (x => x * 3);
                        Console.WriteLine($"Datos calculados del triangulo: Area ({trianguloArea(num)}) Perímetro ({trianguloPerimetro(num)})");
                        break;
                    case 4: // CIRCULO
                        Func<double, double> circuloArea = (x => 3.14 * (x * x));
                        Func<double, double> circuloPerimetro = (x => (2 * 3.14) * x);
                        Console.WriteLine($"Datos calculados del circulo: Area ({circuloArea(num)}) Perímetro ({circuloPerimetro(num)})");
                        break;
                    default:
                        break;
                }
                

            }

        }
    }
}
