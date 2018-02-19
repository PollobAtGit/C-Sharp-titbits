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

    //POI: Table data annotations renamed the DB table with the specified name
    //POI: Because we are naming the table with DataAnnotations the default behavior of pluralizing the
    //table name will not hold

    [Table("Employee")]
    public class EmployeePartFour
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        [Column("Employee Salary")]
        public int Salary { get; set; }

        //POI: This addition makes the Department a navigation property & right fully EF recognizes that
        //& makes a foreign key relation between the associated DB tables & adds a new column in the DB table
        //naming '[Department_Id]' even though that column is not mentioned in this Model class

        //POI: Creation of the foreign key is automatic but in that case the default rules apply for foreign key
        //POI: To configure foreign key the key must be present in the model class (otherwise, how to configure?)

        //POI: This model property is used in the Foreign Key data annotation for 'Department' property
        public int DepartmentId { get; set; }

        //POI: The mentioned foreign key (in the string of ForeignKey annotation) must be present as a Model
        //property

        //POI: If no foreign key data annotation is not used then by default a new column will be added in 
        //the entity table with the default customization setting but most importantly that column need not
        //to be existed in the orginal Model entity where as if developer of the Model class want's to customize
        //the foreign key properties than a property must be present in the Model that will represent the
        //foreign key in DB table

        //BP: Always keep the foreign keys as part of the Model class

        [ForeignKey("DepartmentId")]

        //POI: Specifying the Typed class name & the original type is renamed in DB using 'Table' 
        //Data Annotations

        public DepartmentPartFour Department { get; set; }
    }
}