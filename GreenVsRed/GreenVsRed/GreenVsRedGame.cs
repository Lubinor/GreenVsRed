using System;

namespace GreenVsRed
{

    public class GreenVsRedGame : IGame          // The implementaion of a specific game, in our case Green vs. Red
    {
        static GreenVsRedGame()
        {
            NewSession = new GreenVsRedGame();   // Singleton, to ensure there is only one instance of the game to play
        }

        private GreenVsRedGame()
        {
            GreenCounter = 0;  // Counter for the № times the target cell has been green across all generations
        }

        public static GreenVsRedGame NewSession;
        public static int GreenCounter { get; set; }  
        public int Width { get; set; }
        public int Height { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int MaxGenerations { get; set; }
        public static int[,] Matrix { get; set; }

        public void Start()                                     // Setting up the matrix and all initial parameters
        {
            var matrixSize = Console.ReadLine().Split(", ");
            Width = int.Parse(matrixSize[0]);
            Height = int.Parse(matrixSize[1]);

            Matrix = MatrixHelperMethods.CreateMatrix(Width, Height); // Creating the matrix with the size input parameters

            var startParams = Console.ReadLine().Split(", "); // Setting up the target cell and number of generations to count

            X1 = int.Parse(startParams[0]);
            Y1 = int.Parse(startParams[1]);
            MaxGenerations = int.Parse(startParams[2]);
        }

        public void Play()                                    // Executes the game logic
        {
            if (Matrix[Y1, X1] == 1)                          // Generation zero-only green check
            {
                GreenCounter++;
            }

            int[,] nextGenMatrix = Matrix.Clone() as int[,];  // Another matrix to store the values for the next generation. 
                                                              // Cloned, so that only values are copied, not the reference.

            int generationCounter = 0;

            while (generationCounter <= MaxGenerations)       // Main flow of the game - iterating through each generation, 
                                                              // applying the specified rules and forming the next-gen matrix
            {
                for (int row = 0; row < Height; row++)
                {
                    for (int column = 0; column < Width; column++)
                    {
                        if (Matrix[row, column] == 0)
                        {
                            nextGenMatrix[row, column] = MatrixHelperMethods.RedRule(Matrix, column, row); // If the cell is red, applies red rules
                        }
                        else
                        {
                            nextGenMatrix[row, column] = MatrixHelperMethods.GreenRule(Matrix, column, row); // Else, it is green, so the green rules are applied
                        }
                    }
                }

                if (Matrix[Y1, X1] == 1)                        // Counting each occurrence of a target cell being green
                {
                    GreenCounter++;
                }

                Matrix = nextGenMatrix.Clone() as int[,];       // The next-gen matrix becomes the current-gen matrix to iterate through
                generationCounter++;
            }

        }

        public void Score()                                     // Printing the final result
        {
            Console.WriteLine(GreenCounter);                    
        }
    }
}

