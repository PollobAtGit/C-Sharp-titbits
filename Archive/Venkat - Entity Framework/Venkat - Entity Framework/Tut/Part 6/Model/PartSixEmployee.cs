using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_6.Model
{
    [Table("Employee")]
    public class PartSixEmployee
    {
        public int Id { get; set; }

        [Column("First Name")]
        public string FirstName { get; set; }

        [Column("Last Name")]
        public string LastName { get; set; }

        [Column("Employee Gender")]
        public string Gender { get; set; }

        public decimal Salary { get; set; }

        [Column("Designation")]
        public string JobPosition { get; set; }

        [Column("FkDepartmentId")]
        public int DepartmentId { get; set; }

        //TODO: Is it a navigation property?

        [ForeignKey("DepartmentId")]
        public PartSixDepartment Department { get; set; }
    }
}