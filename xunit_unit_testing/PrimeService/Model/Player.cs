using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrimeService.Model
{
    public class Player
    {
        private readonly Random _random = new Random();

        public int Health { get; private set; }

        public int OriginalHealth { get; }

        public Power PrimaryPower { get; protected set; }

        public Player(int health)
        {
            OriginalHealth = Health = health;

            if (health > -1 && health < 100)
                PrimaryPower = new Power(description: "Laser throw");
        }

        public void TakeBlow(int severity)
        {
            if (Health - severity >= 0)
                Health -= severity;
        }

        public async Task Sleep()
        {
            await Task.Delay(millisecondsDelay: 30);
            var healthToIncrease = _random.Next(minValue: 1, maxValue: 100);
            Health = (Health + healthToIncrease <= OriginalHealth) ? Health + healthToIncrease : OriginalHealth;
        }

        public Player CreateCopy() => JsonConvert.DeserializeObject<Player>(JsonConvert.SerializeObject(this));
    }
}
