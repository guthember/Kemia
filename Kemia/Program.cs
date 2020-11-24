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
      Console.WriteLine($"3. feladat: Elemek száma: {elemek.Count}");
    }

    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();

      Console.ReadLine();
    }
  }
}
