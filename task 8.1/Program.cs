using System;
using System.IO;

namespace task8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppartmensService appartmensService1 = new AppartmensService(@"..\..\..\Data.txt");
            AppartmensService appartmensService2 = new AppartmensService(@"..\..\..\Data1.txt");

            AppartmensService resultAppartments = appartmensService1 + appartmensService2;
            Console.WriteLine(resultAppartments);
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            resultAppartments = appartmensService1 - appartmensService2;
            Console.WriteLine(resultAppartments);
        }
    }
}