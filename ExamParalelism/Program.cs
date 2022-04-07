using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ExamParalelism
{
    class Program
    {
        static async Task Main(string[] args)
        {


            Console.WriteLine("You have 15 seconds to answer 3 questions. Ready to start? (y/n)");
            var inputStart = Console.ReadLine();
            if (string.IsNullOrEmpty(inputStart))
            {
                Console.WriteLine("Invalid answer");
                return;
            }

            if (inputStart.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Please indicate your answers as a, b or c. Let's begin!");
                // Start method
                var timeElapsed = await Parallelism.Main();

                if (timeElapsed / 1000 >= 15)
                    Console.WriteLine("\nYour time is up");
                else
                    Console.WriteLine($"\nCongratulations! you finished in {timeElapsed / 1000m} seconds");
            }

        }

        public class Parallelism
        {
            public static async Task<long> Main()
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var process1 = Process();
                var process2 = Preguntas();

                await Task.WhenAny(process1, process2);

                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }

            public static async Task Process()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(15000);
                });
            }

            public static async Task Preguntas()
            {
                long totalPuntos = 0;

                await Task.Run(() =>
                {
                    // Pregunta 1
                    Console.WriteLine("\n¿Cuántos metros son un kilómetro?");
                    Console.WriteLine("a) 100\nb) 80\nc) 50");
                    Console.Write("Your answer: ");
                    var inputA1 = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputA1.ToString()))
                    {
                        Console.WriteLine("Invalid answer");
                    }
                    else
                    {
                        if (inputA1.ToString().ToUpper().Equals("A"))
                        {
                            totalPuntos += 100;
                            Console.WriteLine(totalPuntos);
                        }
                    }

                    // Pregunta 2
                    Console.WriteLine("\n¿Cuál es el elemento 'Ag'?");
                    Console.WriteLine("a) Argón\nb) Aluminio\nc) Plata");
                    Console.Write("Your answer: ");
                    var inputA2 = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputA2.ToString()))
                    {
                        Console.WriteLine("Invalid answer");
                    }
                    else
                    {
                        if (inputA2.ToString().ToUpper().Equals("B"))
                        {
                            totalPuntos += 100;
                        }
                    }

                    // Pregunta 3
                    Console.WriteLine("\n¿Cuál es la capital de Uruguay?");
                    Console.WriteLine("a) Maldonado\nb) Artigas\nc) Montevideo");
                    Console.Write("Your answer: ");
                    var inputA3 = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputA3.ToString()))
                    {
                        Console.WriteLine("Invalid answer");
                    }
                    else
                    {
                        if (inputA3.ToString().ToUpper().Equals("C"))
                        {
                            totalPuntos += 100;
                        }
                    }
                });

                totalPuntos = totalPuntos / 3;

                Console.WriteLine($"\nYour grade is {totalPuntos}");
            }
        }
    }
}
