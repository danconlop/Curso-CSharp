using System;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

	class Polygon
	{
		public decimal Base { get; set; }
		public decimal Height { get; set; }

		public virtual decimal GetArea()
		{
			return Base * Height;
		}
	}

	class Square : Polygon
	{
		public Square(decimal baseDim)
		{
			Base = baseDim;
			Height = baseDim;
		}
	}

	class Rectangle : Polygon
	{
		public Rectangle(int baseDim, int heightDim)
		{
			Base = baseDim;
			Height = heightDim;
		}
	}

	class Triangle : Polygon
	{
		public Triangle(int baseDim, int heightDim)
		{
			Base = baseDim;
			Height = heightDim;
		}

		public override decimal GetArea()
		{
			return Base * Height / 2;
		}
	}
}
