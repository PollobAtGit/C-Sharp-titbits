// MF: If a model property can be represented with null & if that property is not ID then that column
// will be nullable in SQL Server table column

namespace CodeFirst.Model
{
    // POI: Aliasing a class using using directive
    using DT = System.DateTime;

    public class Student
    {
        public Student()
        {

        }

        // POI: Primary Key
        public int StudentID { get; set; }

        // POI: Nullable StudentName column in table because string is nullable by definition
        public string StudentName { get; set; }

        // POI: Nullable Date field in DB
        public DT? DateOfBirth { get; set; }

        // POI: BLOB data in DB
        // POI: Nullable in table because Array is a reference type so it can be null
        public byte[] Photo { get; set; }

        // POI: Not-Null column in table because decimal is value type
        public decimal Height { get; set; }

        // POI: Not-Null column in table because float is not nullable
        // POI: SQL Server has a data type 'real'
        public float Weight { get; set; }

        // POI: Navigation property
        public Standard Standard { get; set; }

        // POI: Foreign key constraint. It's recommended to include foreign key as part of the model 
        // even though if not done EF will do it automatically
        //public int StandardID { get; set; }

        public override string ToString() => $"{StudentID} {StudentName}";
    }
}
