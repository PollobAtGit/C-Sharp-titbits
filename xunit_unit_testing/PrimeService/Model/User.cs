namespace PrimeService.Model
{
    public class User
    {
        public string Name { get; }

        public double CurrentBalance { get; private set; }

        public User(string name)
        {
            CurrentBalance = 0.0;
            Name = name;
        }

        public double Accumulate(double money)
        {
            var cb = CurrentBalance;
            CurrentBalance = cb + money;
            return cb / money;
        }
    }
}


