namespace PrimeService.Model
{
    public class Weapon
    {
        public string Description { get; set; } = "default description";

        public double DamageCapacity { get; set; } = -100;

        public override string ToString() => Description;

        public override bool Equals(object obj) => obj is Weapon weapon && Description == weapon.Description;

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Description != null ? Description.GetHashCode() : 0) * 397) ^ DamageCapacity.GetHashCode();
            }
        }
    }
}
