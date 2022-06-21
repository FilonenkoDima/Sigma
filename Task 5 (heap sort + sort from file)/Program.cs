using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {



            //Vector vector = new Vector(100);
            //vector.RandomInitialization(1, 50);

            //try
            //{
            //    //Console.WriteLine(vector);
            //    //vector.HeapSort();
            //    //Console.WriteLine(vector);
            //    using (StreamReader reader = new StreamReader("matrix.txt"))
            //    {
            //        Matrix matrix = new Matrix();
            //        matrix.ReadMatrixFromFile(reader);
            //        matrix.Print();
            //    }

            //    string str1 = "Hello world. I am Dima";
            //    int index = str1.LastIndexOf(' ');

            //    Console.WriteLine(str1);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Vector a = new Vector(20);
            //a.RandomInitialization();
            //Vector b = new Vector(10);
            //b.RandomInitialization();
            //Console.WriteLine("a:\n" + a.ToString());
            //Console.WriteLine("b:\n" + b.ToString());
            //Console.WriteLine("a + b:\n" + (a + b).ToString());

            //a += 5;
            //Console.WriteLine("a += 5\n" + a.ToString());

            //int k = a;
            //Console.WriteLine("explicit\n" + (int)a);

            int[,] test = { { 1, 2, 3}, { 4, 5, 6 }, { 7, 8, 9} };
            Matrix example1 = new Matrix(test);
            //example1.SpiralSnake();
            foreach(var item in example1)
                Console.WriteLine(item);
                

        }
    }
}
