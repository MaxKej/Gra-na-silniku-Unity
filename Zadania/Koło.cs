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

		public float X { get; set; }

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
	}

	class Kolo : Punkt
	{
		public Kolo(float promien = 1, Punkt srodek = null)
		{
			Promien = promien;
			Srodek = srodek ?? new Punkt(0, 0);
		}
		public Punkt Srodek { get; set; }
        public float Promien { get; set; }

		public void PrzesunSrodek(float x, float y)
		{
			X = x;
			Y = y;
		}
		public void ZmienPromien(float nowyPromien)
		{
			if (nowyPromien < 0)
			{
				throw new ArgumentException(String.Format("Promien nie moze byc ujemny!", nowyPromien));
			}
			Promien = nowyPromien;
		}

		float Srednica => 2 * Promien;

		public float Obwod => 2 *(float)Math.PI * Promien;

		public float Pole => (float)(Math.PI * Math.Pow(Promien, 2));

		public override string ToString()
		{
			return "///////////////////////////////////////////////////////////////////////////////////" +
				   "\nSrodek kola: (" + X + " , " + Y + ")" +
				   "\nPromien kola: " + Promien +
				   "\nSrednica kola: " + Srednica +
				   "\nObwod kola: " + Obwod +
				   "\nPole kola: " + Pole +
				   "\n///////////////////////////////////////////////////////////////////////////////////";
		}
	}

	class Program
	{
		public static void Main(string[] args)
		{
			Kolo K = new Kolo();

			Console.WriteLine("Podaj x1:");
			float x = float.Parse(Console.ReadLine());
			Console.WriteLine("Podaj y1:");
			float y = float.Parse(Console.ReadLine());
			Console.WriteLine("Podaj promien kola:");
			float promien = float.Parse(Console.ReadLine());

			K.PrzesunSrodek(x, y);
			try
			{
				K.ZmienPromien(promien);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine(K.ToString());
		}
	}
}
