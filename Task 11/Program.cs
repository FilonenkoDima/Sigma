namespace task112
{

    
    class TestGenericList
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}