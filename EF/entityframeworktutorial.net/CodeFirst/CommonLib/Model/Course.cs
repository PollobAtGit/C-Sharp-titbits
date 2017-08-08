namespace CommonLib.Model
{
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            // POI: It's a better approach to instantiate collections in the constructor
            // POI: On the other hand this approach is not safe in general because the invoked property is
            // virtual

            // POI: Don't initialize the other Entity
            Instructors = new HashSet<Instructor>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        // POI: virtual keyword facilities lazy loading
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }

    public class OnlineCourse : Course
    {
        public string URL { get; set; }
    }

    public class OnsiteCourse : Course
    {
        public OnsiteCourse()
        {
            Details = new Details();
        }

        // POI: Not levaraging lazy loading because the navigation property is not virtual
        public Details Details { get; set; }
    }
}