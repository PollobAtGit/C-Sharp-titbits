namespace CodeFirst.Model
{
    public class Employee : Entity
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // POI: Salary is not part of the configuration mentioned in OnModelCreating still Context class
        // includes this property with identity column in a seperate table
        public decimal Salary { get; set; }

        // POI: Not included when the Entity is splitting from OnModelCreating method
        // POI: Because of that it is added into a default table named by EF
        public bool IsSenior { get; set; }

        // POI: This property is Ignored using FluentAPI
        public string NickName { get; set; }
    }
}
