//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Generics2
//{
//    public static class Slownik
//    {
//        public static SortedDictionary<char, int> LiczbaLiter(string ciag)
//        {
//            SortedDictionary<char, int> myDr = new SortedDictionary<char, int>();
//            char[] chars = ciag.ToCharArray();
//            char[] Distinct = chars.Distinct().ToArray();
//            char litera;
//            for (int i = 0; i < Distinct.Length; i++)
//            {
//                int ilosc = 0;
//                litera = Distinct[i];
//                for (int j = 0; j < chars.Length; j++)
//                {
//                    if (chars[j] == litera) ilosc++;
//                }

//                myDr.Add(litera, ilosc);
//            }
//            return myDr;
//        }
//        public static void Main(string[] args)
//        {
//            string ciag = "abbca";
//            SortedDictionary<char, int> listaLiter = LiczbaLiter(ciag);
//            foreach (KeyValuePair<char, int> pair in listaLiter)
//            {
//                Console.Write("{0}: {1}" + " ", pair.Key, pair.Value);
//            }
//        }
//    }
//}
