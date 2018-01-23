using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.ClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Genereator g = new Genereator();
            g.Run();


            Console.WriteLine("Done!");
            Console.ReadKey();

        }
    }
}
