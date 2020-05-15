namespace PrimeService.Exception
{
    public class GameException : System.Exception
    {
        public GameException(System.Exception innerException) : base("Angry bird exception", innerException)
        {

        }
    }
}
