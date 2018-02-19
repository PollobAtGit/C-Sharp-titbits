using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_5.Model
{
    [Table("Employee")]
    public class EmployeePartFive
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }

        //POI: Foreign key can be named differently using Column Data annotation

        [Column("FkDepartmentId")]
        public int DepartmentId { get; set; }

        //POI: But the string in ForeignKey DataAnnotations is directly linked with the typed property name

        [ForeignKey("DepartmentId")]
        public DepartmentPartFive Department { get; set; }
    }
}