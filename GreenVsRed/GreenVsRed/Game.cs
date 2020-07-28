namespace MMTask
{

    public interface IGame            // Abstraction, in case we want to extend the application to include more games
    {
        public void Start(); // Each game should have it's own start method that initiates startup and then runs the game flow
    }
}
