namespace MMTask
{

    public abstract class Game        // Abstract class, in case we want to extend the application to include more games
    {
        public Game()
        {

        }
        public abstract void Start(); // Each game should have it's own start method that initiates startup and then runs the game flow
    }
}
