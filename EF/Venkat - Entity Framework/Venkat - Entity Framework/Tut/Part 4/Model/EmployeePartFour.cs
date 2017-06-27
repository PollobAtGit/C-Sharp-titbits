using System.ComponentModel.DataAnnotations.Schema;

namespace Venkat___Entity_Framework.Tut.Part_4.Model
{
    //POI: When resolving Type names EF searches the whole assembly considering only Type name ignoring namespace.
    //Which causes problems in resolving Type name if there exists two Models in the assembly with the same name
    //Even though in this case both of them will be different namespace, from EF's standpoint they are same
    //because EF ignores namespace. if this scenario occurs the error 
    //'The mapping of CLR type to EDM type is ambiguous because multiple CLR types match the EDM type .....'
    //will be thrown

    //BP: Any assembly should not include Types with the same name

    public class EmployeePartFour
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }

        //POI: This addition makes the Department a navigation property & right fully EF recognizes that
        //& makes a foreign key relation between the associated DB tables & adds a new column in the DB table
        //even though that column is not mentioned in this Model class

        //[ForeignKey("FkDepartmentId")]
        public DepartmentPartFour Department { get; set; }
    }
}