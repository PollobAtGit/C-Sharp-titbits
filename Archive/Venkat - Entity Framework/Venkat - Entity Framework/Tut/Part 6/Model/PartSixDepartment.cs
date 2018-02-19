using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_6.Model
{
    [Table("Department")]
    public class PartSixDepartment
    {
        public int Id { get; set; }

        [Column("Full Name")]
        public string Name { get; set; }

        public string Location { get; set; }

        //POI: Navigation property
        public List<PartSixEmployee> Employees { get; set; }
    }
}