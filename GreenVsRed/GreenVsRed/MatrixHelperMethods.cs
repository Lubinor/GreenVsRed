using System;

namespace GreenVsRed
{
    public static class MatrixHelperMethods                           // Static helper methods that execute the logic of the game rules
    {
        public static int[,] CreateMatrix(int maxColumns, int maxRows) // Creates and returns a matrix with given input (size) parameters
        {
            var matrix = new int[maxRows, maxColumns];

            for (int row = 0; row < maxRows; row++)
            {
                string rowContent = Console.ReadLine();

                for (int column = 0; column < maxColumns; column++)
                {
                    matrix[row, column] = int.Parse(rowContent[column].ToString());
                }
            }

            return matrix;
        }

        public static int RedRule(int[,] matrix, int column, int row) // Checks whether the first or the second red rule should be applied
        {
            var greens = GeneralRule(matrix, column, row);

            if (greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        public static int GreenRule(int[,] matrix, int column, int row) // Checks whether the first or second green rule should be applied
        {
            var greens = GeneralRule(matrix, column, row);

            if (greens == 2 || greens == 3 || greens == 6)
            {
                return 1;
            }
            return 0;
        }

        private static int GeneralRule(int[,] matrix, int column, int row) // Private method that holds the rule logic which is applicable to both red and green
        {
            int greens = 0;

            for (int i = row - 1; i <= row + 1; i++)                 // Checks all 8 neighboring cells of a target cell and counts the № of greens
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i == row && j == column)
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

        private static bool CheckForGreen(int[,] matrix, int row, int column) // Checks whether a single cell is green or if it's red/out of the array
        {
            try
            {
                if (matrix[row, column] == 1)
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
