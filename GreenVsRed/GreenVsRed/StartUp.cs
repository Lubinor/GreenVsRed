namespace GreenVsRed
{
    public static class StartUp
    {
        public static void Main()
        {
            GreenVsRedGame.NewSession.Start();      // The starting point of the application. Initiates the only
                                                    // instance (singleton) of the chosen game and the starting setup.

            GreenVsRedGame.NewSession.Play();       // Executes the game logic and flow

            GreenVsRedGame.NewSession.Score();      // Shows the final score/result of the game
        }
    }
}
