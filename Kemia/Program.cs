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
   
    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();
      Negyedik();

      Console.ReadLine();
    }
  }
}
