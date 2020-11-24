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

    static void Hatodik()
    {
      var talalat = (from e in elemek
                     where e.Vegyjel.ToUpper() == vegyjel.ToUpper()
                     select e).ToList();

      Console.WriteLine("6. feladat: Keresés");
      if (talalat.Count != 0)
      {
        Console.WriteLine($"\tAz elem vegyjele: {talalat[0].Vegyjel}");
        Console.WriteLine($"\tAz elem neve: {talalat[0].Nev}");
        Console.WriteLine($"\tRendszáma: {talalat[0].Rsz}");
        Console.WriteLine($"\tFelfedezés éve: {talalat[0].SEV}");
        Console.WriteLine($"\tFelfedező: {talalat[0].Felfedezo}");
      }
      else
      {
        Console.WriteLine("Nincs ilyen elem az adatforrásban!");
      }
    }

    static void Hetedik()
    {
      int max = 0;
      for (int i = Elem.okorDb; i < Elem.db - 1; i++)
      {
        if (elemek[i+1].Ev - elemek[i].Ev > max)
        {
          max = elemek[i + 1].Ev - elemek[i].Ev;
        }
      }
      Console.WriteLine($"7. feladat: {max} év volt a leghosszabb időszak két elem felfedezése között.");
    }

    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();
      Negyedik();
      Otodik();
      Hatodik();
      Hetedik();

      Console.ReadLine();
    }
  }
}
