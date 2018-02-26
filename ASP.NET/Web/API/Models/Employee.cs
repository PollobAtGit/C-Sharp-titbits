namespace API.Controllers.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int OrgId { get; set; }

        public int DepartmentId { get; set; }
    }
}