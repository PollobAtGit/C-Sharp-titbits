namespace PrimeService.Model
{
    public class ShipDestroyer : Player
    {
        public ShipDestroyer() : base(health: 90)
        {
            PrimaryPower = new DestroyerPower();
        }
    }
}
