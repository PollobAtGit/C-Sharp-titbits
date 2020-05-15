namespace Moqs
{
    public interface IEmail
    {
        string Address { get; }
    }

    public class Email : IEmail
    {
        public string Address { get; set; }
    }
}