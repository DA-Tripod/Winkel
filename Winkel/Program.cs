using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winkel
{
    class Program
    {
        static void Main(string[] args)
        {
             Boolean exit = true;
            Berechnung br = new Berechnung();
            while (exit)
            {
                Console.WriteLine(" X-Koordinate: ");
                String X = Console.ReadLine();
                double x = Convert.ToDouble(X);
                Console.WriteLine(" Y-Koordinate: ");
                String Y = Console.ReadLine();
                double y = Convert.ToDouble(Y);
                Console.WriteLine(" Z-Koordinate: ");
                String Z = Console.ReadLine();
                double z = Convert.ToDouble(Z);

                Console.WriteLine("Schrittmotor 1 - alpha : ");
                Console.WriteLine(br.S1(x, y, z));
                Console.WriteLine("Schrittmotor 2 - alpha : ");
                Console.WriteLine(br.S2(x, y, z));
                Console.WriteLine("Schrittmotor 3 - alpha : ");
                Console.WriteLine(br.S3(x, y, z));
            }
        }
    }
}
