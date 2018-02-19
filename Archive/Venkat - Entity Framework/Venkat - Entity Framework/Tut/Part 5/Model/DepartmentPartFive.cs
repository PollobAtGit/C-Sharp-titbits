using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_5.Model
{
    [Table("Department")]
    public class DepartmentPartFive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<EmployeePartFive> Employees { get; set; }
    }
}