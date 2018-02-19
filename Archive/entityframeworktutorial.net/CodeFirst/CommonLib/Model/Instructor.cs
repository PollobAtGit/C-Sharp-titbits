namespace CommonLib.Model
{
    using System;
    using System.Collections.Generic;

    public class Instructor
    {
        public Instructor()
        {
            // POI: It's a better approach to initialize collection entity
            Courses = new List<Course>();
        }

        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}