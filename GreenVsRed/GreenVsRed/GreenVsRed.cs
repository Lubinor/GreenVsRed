using System;

namespace MMTask
{

    public class GreenVsRed : IGame          // The implementaion of a specific game, in our case Green vs. Red
    {
        private static int greenCounter;    // Counter for the № times the target cell has been green across all generations

        static GreenVsRed()
        {
            NewSession = new GreenVsRed();   // Singleton, to ensure there is only one instance of the game to play
        }

        private GreenVsRed()
        {
            GreenCounter = greenCounter = 0;  // Setting up the initial state of the green counter
        }

        public static GreenVsRed NewSession;
        public static int GreenCounter { get; set; }

        public void Start()
        {
            var matrixSize = Console.ReadLine().Split(", ");    // Setting up the size of the matrix
            var width = int.Parse(matrixSize[0]);
            var height = int.Parse(matrixSize[1]);

            var matrix = MatrixHelperMethods.CreateMatrix(width, height); // Creating the matrix with the size input parameters

            var startParams = Console.ReadLine().Split(", "); // Setting up the target cell and number of generations to count

            var x1 = int.Parse(startParams[0]);
            var y1 = int.Parse(startParams[1]);
            var N = int.Parse(startParams[2]);

            if (matrix[y1, x1] == 1)                          // Generation zero-only green check
            {
                greenCounter++;
            }

            int[,] nextGenMatrix = matrix.Clone() as int[,];  // Another matrix to store the values for the next generation. 
                                                              // Cloned, so that only values are copied, not the reference.

            int generationCounter = 0;

            while (generationCounter <= N)                    // Main flow of the game - iterating through each generation, 
                                                              // applying the specified rules and forming the next-gen matrix
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            nextGenMatrix[i, j] = MatrixHelperMethods.RedRule(matrix, j, i); // If the cell is red, applies red rules
                        }
                        else
                        {
                            nextGenMatrix[i, j] = MatrixHelperMethods.GreenRule(matrix, j, i); // Else, it is green, so the green rules are applied
                        }
                    }
                }

                if (matrix[y1, x1] == 1)                        // Counting each occurrence of a target cell being green
                {
                    greenCounter++;
                }

                matrix = nextGenMatrix.Clone() as int[,];       // The next-gen matrix becomes the current gen matrix to iterate through
                generationCounter++;
            }

            Console.WriteLine(greenCounter);                    // Priting the final result
        }
    }
}
