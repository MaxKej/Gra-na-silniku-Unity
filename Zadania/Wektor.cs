using System;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace punkt
{
    public class Punkt
    {
		public Punkt(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

		public float X { get; set;}

		public float Y { get; set; }

		public void PrzesunOWektor(float a, float b)
		{
			X += a;
			Y += b;
		}

		public void Przenies(Punkt P)
		{
			X = P.X;
			Y = P.Y;
		}

		public void Odbij()
		{
			X = -X;
			Y = -Y;
		}

		public override string ToString()
		{
			return "Wektor: (" + X.ToString() + " , " + Y.ToString() + ")";
		}
	}

	class Program
	{
		public static void Main(string[] args)
		{
			//System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			//customCulture.NumberFormat.NumberDecimalSeparator = ".";
			//System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

			Punkt wektor1 = new Punkt();

			Console.WriteLine("Podaj x1:");
			wektor1.X = float.Parse(Console.ReadLine());
			Console.WriteLine("Podaj y1:");
			wektor1.Y = float.Parse(Console.ReadLine());

			Console.WriteLine(wektor1.ToString());

            Console.WriteLine("Podaj a:");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Podaj b:");
            float b = float.Parse(Console.ReadLine());
            wektor1.PrzesunOWektor(a, b);
            Console.WriteLine(wektor1.ToString());

            Punkt wektor2 = new Punkt();
			Console.WriteLine("Podaj x2:");
			wektor2.X = float.Parse(Console.ReadLine());
			Console.WriteLine("Podaj y2:");
			wektor2.Y = float.Parse(Console.ReadLine());
			Console.WriteLine(wektor2.ToString());

			wektor1.Przenies(wektor2);
            Console.WriteLine(wektor1.ToString());

            wektor1.Odbij();
            Console.WriteLine(wektor1.ToString());

        }
	}
}