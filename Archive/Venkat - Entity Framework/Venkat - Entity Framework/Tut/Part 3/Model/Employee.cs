using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_3.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }

        //POI: NotMapped DataAnnotations prevents EF from adding the new column to the Entity table
        [NotMapped]
        public int NotMapped { get; set; }

        public Department Department { get; set; }
    }
}