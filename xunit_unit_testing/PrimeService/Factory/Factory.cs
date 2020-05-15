namespace PrimeService.Factory
{
    public abstract class Factory<TEnum, T>
    {
        public abstract T Create(TEnum enumValue);
    }
}