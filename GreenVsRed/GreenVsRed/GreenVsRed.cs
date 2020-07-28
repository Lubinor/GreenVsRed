using System;
using System.Collections.Generic;
using System.Text;

namespace MMTask
{
    public class GreenVsRed : Game
    {
        private static int greenCounter;

        static GreenVsRed()
        {
            NewSession = new GreenVsRed();
        }

        private GreenVsRed()
        {
            GreenCounter = greenCounter = 0;
        }

        public static GreenVsRed NewSession;
        public static int GreenCounter { get; set; }

        public override void Start()
        {
            var matrixSize = Console.ReadLine().Split(", ");
            var width = int.Parse(matrixSize[0]);
            var height = int.Parse(matrixSize[1]);

            var matrix = MatrixHelperMethods.CreateMatrix(width, height);

            var startParams = Console.ReadLine().Split(", ");

            var x1 = int.Parse(startParams[0]);
            var y1 = int.Parse(startParams[1]);
            var N = int.Parse(startParams[2]);

            if (matrix[y1, x1] == 1)
            {
                greenCounter++;
            }

            int[,] nextGenMatrix = matrix.Clone() as int[,];

            int generationCounter = 0;

            while (generationCounter <= N)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            nextGenMatrix[i, j] = MatrixHelperMethods.RedRule(matrix, j, i);
                        }
                        else
                        {
                            nextGenMatrix[i, j] = MatrixHelperMethods.GreenRule(matrix, j, i);
                        }
                    }
                }

                if (matrix[y1, x1] == 1)
                {
                    greenCounter++;
                }

                matrix = nextGenMatrix.Clone() as int[,];
                generationCounter++;
            }

            Console.WriteLine(greenCounter);
        }
    }
}
