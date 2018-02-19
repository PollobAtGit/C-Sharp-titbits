namespace CommonLib.Model
{
    using System;
    using System.Collections.Generic;

    public class Department
    {
        public Department()
        {
            // POI: This is a better approach to initialize an collection. Remove all the possibility to have a NullReferenceException
            // POI: On the other hand, it's not that much safe becaue the collection property is virtual
            Courses = new HashSet<Course>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        // POI: virtual navigation property supports lazy loading
        public virtual ICollection<Course> Courses { get; set; }
    }
}
