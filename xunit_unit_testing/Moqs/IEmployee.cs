namespace Moqs
{
    public interface IEmployee
    {
        string NationalId { get; }

        decimal Salary { get; set; }

        IEmail Email { get; set; }
    }
}
