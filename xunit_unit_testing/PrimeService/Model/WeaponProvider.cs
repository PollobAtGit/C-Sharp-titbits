namespace PrimeService.Model
{
    public sealed class WeaponProvider
    {
        public static WeaponProvider Provider { get; } = new WeaponProvider();

        private WeaponProvider() { }
    }
}