using System;

namespace CodeFirst.Model
{
    public class Student
    {
        public Student()
        {

        }

        // POI: Primary Key
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        // POI: Nullable Date field in DB
        public DateTime? DateOfBirth { get; set; }

        // POI: BLOB data in DB
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        // POI: Navigation property
        public Standard Standard { get; set; }

        public override string ToString() => $"{StudentID} {StudentName}";
    }
}
