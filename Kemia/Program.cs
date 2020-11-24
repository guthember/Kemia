using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
  class Program
  {
    static List<Elem> elemek = new List<Elem>();
    static string vegyjel;

    static void Beolvasas()
    {
      StreamReader be = new StreamReader("felfedezesek.csv");

      be.ReadLine();

      while (!be.EndOfStream)
      {
        string[] a = be.ReadLine().Split(';');
        elemek.Add(new Elem(a[0], a[1], a[2], a[3], a[4]));

      }

      be.Close();
    }

    static void Harmadik()
    {
      Console.WriteLine($"3. feladat: Elemek száma: {Elem.db}");
    }

    static void Negyedik()
    {
      #region linq-val
      //int darab = (from e in elemek
      //             where e.Ev == 0
      //             select e).ToList().Count; 
      #endregion
      
      //int darab = 0;
      //foreach (var elem in elemek)
      //{
      //  if (elem.Ev == 0)
      //  {
      //    darab++;
      //  }
      //}

      Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {Elem.okorDb}");
    }

    static bool Validal(string mit)
    {
      bool vissza = false;
      mit = mit.ToUpper();

      if (mit.Length == 0 || mit.Length > 2)
      {
        vissza = true;
      }
      else
      {
        foreach (char betu in mit)
        {
          int kod = (int)betu;
          if (!(kod >= 65 && kod <= 90))
          {
            vissza = true;
          }
        }
      }
      return vissza;
    }

    static void Otodik()
    {
      bool nemjo = true;

      while (nemjo)
      {
        Console.Write("5. feladat: Kérek egy vegyjelet: ");
        vegyjel = Console.ReadLine();

        nemjo = Validal(vegyjel);
      }
    }

    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();
      Negyedik();
      Otodik();

      Console.ReadLine();
    }
  }
}
