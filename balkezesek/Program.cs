using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<Jatekos> Lista = new List<Jatekos>();
        static void Beolvas()
        {
            StreamReader olvas = new StreamReader("balkezesek.csv");
            string[] jellemzok = olvas.ReadLine().Split(';');
            while (!olvas.EndOfStream)
            {
                string[] seged = olvas.ReadLine().Split(';');
                Lista.Add(new Jatekos(seged[0], seged[1], seged[2], int.Parse(seged[3]), int.Parse(seged[4])));
            }
            olvas.Close();
        }

        static void HarmadikFeladat()
        {
            Console.WriteLine($"3. feladat: {Lista.Count}");
        }

        static void NegyedikFeladat()
        {
            var oktoberi = from l in Lista
                           where l.utoljarapalyan.Contains("1999-10")
                           select new { magassag = l.magassag, nev = l.nev };
            Console.WriteLine("4. feladat:");
            foreach (var o in oktoberi)
            {
                Console.WriteLine($"\t {o.nev} {(o.magassag*2.54):N1} cm");
            }
        }

        static void OtHatFeladat()
        {
            bool nemjo = true;
            Console.WriteLine();
            Console.Write("5. feladat: kérek egy 1990 és 1999 közötti számot!:");
            int megadott5 = int.Parse(Console.ReadLine());
            while (nemjo)
            {
                if (megadott5 > 1990 || megadott5 < 1999)
                {
                    nemjo = false;
                }
                else
                {
                    Console.WriteLine($"Hibás adat, kérek egy 1990 és 1999 közötti számot!: ");
                }
            }

            double atlag = 0;
            int db = 0;
            foreach (var l in Lista)
            {
                string[] seged1 = l.elsorepalyan.Split('-');
                string[] seged2 = l.utoljarapalyan.Split('-');
                if (int.Parse(seged1[0]) <= megadott5 && megadott5 <= int.Parse(seged2[0]))
                {
                    atlag += l.suly;
                    db++;
                }
            }
            Console.WriteLine($"6. Feladat: {(atlag/db):N2} font");
        }

        
        static void Main(string[] args)
        {
            Beolvas();
            HarmadikFeladat();
            NegyedikFeladat();
            OtHatFeladat();
            Console.ReadLine();
        }
    }
}
