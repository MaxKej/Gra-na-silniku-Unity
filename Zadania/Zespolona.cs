using System;
using System.Collections.Generic;

class Zespolona
{
    Zespolona(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public double Re { get; set; }
    public double Im { get; set; }

	// operatory tylko zwracają
	public static Zespolona operator +(Zespolona z1, Zespolona z2)
	{
		return new Zespolona(z1.Re + z2.Re, z1.Im + z2.Im);
	}
	public static Zespolona operator -(Zespolona z1, Zespolona z2)
	{
		return new Zespolona(z1.Re - z2.Re, z1.Im - z2.Im);
	}
    public static Zespolona operator *(Zespolona z1, Zespolona z2)
	{
		return new Zespolona(z1.Re * z2.Re - z1.Im * z2.Im, z1.Im * z2.Re + z2.Im * z1.Re);
	}

	//poprawić throwa i zaokrog
	public static Zespolona operator /(Zespolona z1, Zespolona z2)
	{
		if (z2.Re == 0 && z2.Im == 0)
		{
			throw new ArgumentException(String.Format("Dzielenie przez 0!"));
		}
		double re = (z1.Re * z2.Re + z1.Im * z2.Im) / (z2.Re * z2.Re + z2.Im * z2.Im);
		double im = (z1.Re * z2.Im - z1.Im * z2.Re) / (z2.Re * z2.Re + z2.Im * z2.Im);
		return new Zespolona(re, im);
	}

	public static Zespolona operator ++(Zespolona z)
	{
		z.Re += 1;
		return z;
	}

	public static Zespolona operator --(Zespolona z)
	{
		z.Re -= 1;
		return z;
	}

	public bool Equals(Zespolona z1, Zespolona z2)
    {
		//bool status = false;
		//if (z1.Re == z2.Re && z1.Im == z2.Im)
		//{
		//	status = true;
		//}
		//return status;
		return z1.Re == z2.Re && z1.Im == z2.Im;
	}

	public override int GetHashCode() => (Re, Im).GetHashCode();

	//public static bool operator ==(Zespolona z1, Zespolona z2)
	//{
	//    bool status = false;
	//	  if (z1.Re == z2.Re && z1.Im == z2.Im)
	//	  {
	//		status = true;
	//	  }
	//	  return status;
	//	  return z1.Equals(z2);
	//}

	//public static bool operator !=(Zespolona z1, Zespolona z2)
	//{
	//	bool status = false;
	//	if (z1.Re != z2.Re && z1.Im != z2.Im)
	//	{
	//		status = true;
	//	}
	//	return status;
	// return !z1.Equals(z2);
	//}

	public static bool operator >(Zespolona z1, Zespolona z2)
	{
		if (z1.Im != z2.Im)
		{
			throw new ArgumentException(String.Format("Nie mozna porownac!"));
		}
		return z1.Re > z2.Re;
	}
	public static bool operator <(Zespolona z1, Zespolona z2)
	{
		if (z1.Im != z2.Im)
		{
			throw new ArgumentException(String.Format("Nie mozna porownac!"));
		}
		return z1.Re < z2.Re;
	}

	public override string ToString()
	{
		if(Im >= 0)
        {
			return Math.Round(Re, 2).ToString() + " + " + Math.Round(Im, 2).ToString() + "i";
		}
		else
		{
			return Math.Round(Re, 2).ToString() + " - " + Math.Abs(Im).ToString() + "i";
		}
	}

	public static explicit operator int(Zespolona k) => (int)k.Re;
	public static explicit operator float(Zespolona k) => (float)k.Re;

	public double Modul => Math.Sqrt(Re * Re + Im * Im);

        static void Main(string[] args)
        {
            Zespolona z1 = new Zespolona(1.2, -2);
            Zespolona z2 = new Zespolona(3, -2);

			z1++;
			Console.WriteLine(z1);
			++z1;
			Console.WriteLine(z1);
			z1--;
			Console.WriteLine(z1);
			--z1;
			Console.WriteLine(z1);

			Zespolona z3 = z1 + z2;
			Console.WriteLine(z3);
			Zespolona z4 = z1 - z2;
			Console.WriteLine(z4);
			Zespolona z5 = z1 * z2;
			Console.WriteLine(z5);
			try
			{
				Zespolona z6 = z1 / z2;
				Console.WriteLine(z6);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine(z1.Equals(z2));
			Console.WriteLine(z1.Equals(z1));
			try
			{
				Console.WriteLine(z1 > z2);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}
			try
			{
				Console.WriteLine(z1 < z2);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
            }

			Console.WriteLine((int)z1);
			Console.WriteLine((float)z1);

			Console.WriteLine(Math.Round(z1.Modul, 2));
			Console.WriteLine("Hash code z1: " + z1.GetHashCode());
        }
}