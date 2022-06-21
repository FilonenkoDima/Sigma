using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    public  class Matrix : IEnumerator
    {

        public static void VerticalSnake()
        {
            int n = 3, m = 4;
            var arr = new int[n, m];
            int temp = 1;
            //arr[0,0] = 1;

            for (int i = 0; i < m; i++)
            {
                if (i % 2 == 0)
                    for (int j = 0; j < n; j++)
                    {
                        arr[j, i] = temp;
                        temp++;
                    }
                else
                    for (int j = n - 1; j >= 0; --j)
                    {
                        arr[j, i] = temp;
                        temp++;
                    }

            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }


        public static void DiagonalSnake()
        {
            int n = 4, m = 4;
            var arr = new int[n, m];
            int temp = 1;

            for (int diag = 0; diag < m * 2; diag++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        if (i + j == diag)
                        {
                            if (diag % 2 == 0)
                                arr[j, i] = temp;
                            else
                                arr[i, j] = temp;
                            temp++;
                        }



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }

        public static void SpiralSnake()
        {
            const int n = 3;
            const int m = 4;
            int[,] matrix = new int[n, m];

            int row = 0;
            int col = 0;
            int dx = 1;
            int dy = 0;
            int dirChanges = 0;
            int visits = m;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[row, col] = i + 1;
                if (--visits == 0)
                {
                    visits = m * (dirChanges % 2) + n * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }

                col += dx;
                row += dy;
            }




            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < m; b++)
                    Console.Write(matrix[a, b] + " ");
                Console.WriteLine();
            }
        }


    }

    public IEnumerator GetEnumerator()
    {
        return matrix.GetEnumerator();
    }
}
