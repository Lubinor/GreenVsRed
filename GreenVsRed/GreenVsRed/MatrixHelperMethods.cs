using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MMTask
{
    public static class MatrixHelperMethods
    {
        public static int[,] CreateMatrix(int x, int y)
        {
            var matrix = new int[y, x];

            for (int row = 0; row < y; row++)
            {
                string rowContent = Console.ReadLine();

                for (int column = 0; column < x; column++)
                {
                    matrix[row, column] = int.Parse(rowContent[column].ToString());
                }
            }

            return matrix;
        }

        public static int RedRule(int[,] matrix, int x, int y)
        {
            var greens = GeneralRule(matrix, x, y);

            if (greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        public static int GreenRule(int[,] matrix, int x, int y)
        {
            var greens = GeneralRule(matrix, x, y);

            if (greens == 2 || greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        private static int GeneralRule(int[,] matrix, int x, int y)
        {
            int greens = 0;

            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (i == y && j == x)
                    {
                        continue;
                    }

                    if (CheckForGreen(matrix, i, j))
                    {
                        greens++;
                    }
                }
            }
            return greens;
        }

        private static bool CheckForGreen(int[,] matrix, int x, int y)
        {
            try
            {
                if (matrix[x, y] == 1)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return false;
        }
    }
}
