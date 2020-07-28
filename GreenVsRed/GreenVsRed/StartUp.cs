namespace MMTask
{
    public static class StartUp
    {
        public static void Main()
        {
            GreenVsRed.NewSession.Start();      // The starting point of the application. 
                                                // Initiates the only instance (singleton) of the chosen game
        }
    }
}
