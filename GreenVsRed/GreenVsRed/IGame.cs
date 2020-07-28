namespace GreenVsRed
{

    public interface IGame          // Abstraction, in case we want to extend the application to include more games
    {
        public void Start();        // Each game should have it's own start method that initiates startup 
        public void Play();         // Executes the game flow and logic
        public void Score();        // Calculates/Displays the final score/result
    }
}
