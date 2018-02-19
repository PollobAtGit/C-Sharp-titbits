namespace CodeFirst.Model
{
    using System.Collections.Generic;

    public abstract class Course : Entity
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Trainer { get; set; }
    }

    public class OnlineCourse : Course
    {
        // POI: List is added in Online Course. It will not work if it's included in 
        // Course abstract Entity. May be because In DB there's no table for Course
        // Entity. So no itermediate table for a *-* relationship will be created

        public List<Student> Students { get; set; }
        public string URL { get; set; }
    }

    public class OfflineCourse : Course
    {
        public string Address { get; set; }
    }
}
