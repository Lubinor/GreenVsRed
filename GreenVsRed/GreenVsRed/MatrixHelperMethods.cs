using System;

namespace MMTask
{
    public static class MatrixHelperMethods             // Static helper methods that execute the logic of the game rules
    {
        public static int[,] CreateMatrix(int x, int y) // Creates and returns a matrix with given input (size) parameters
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

        public static int RedRule(int[,] matrix, int x, int y) // Checks whether the first or the second red rule should be applied
        {
            var greens = GeneralRule(matrix, x, y);

            if (greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        public static int GreenRule(int[,] matrix, int x, int y) // Checks whether the first or second green rule should be applied
        {
            var greens = GeneralRule(matrix, x, y);

            if (greens == 2 || greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        private static int GeneralRule(int[,] matrix, int x, int y) // Private method that holds the rule logic which is applicable to both red and green
        {
            int greens = 0;

            for (int i = y - 1; i <= y + 1; i++)                    // Checks all 8 neighboring cells of a target cell and counts the № of greens
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

        private static bool CheckForGreen(int[,] matrix, int x, int y) // Checks whether a single cell is green or if it's red/out of the array
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
