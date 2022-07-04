namespace Task102
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix ints = new Matrix(5, 5, FillTypes.Diagonaly);
            //ints.FillMatrix();
            //ints.GetEnumerator();
            foreach (var i in ints)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}