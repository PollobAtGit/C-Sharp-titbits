namespace CodeFirst.Model
{
    public abstract class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Trainer { get; set; }
    }

    public class OnlineCourse : Course
    {
        public string URL { get; set; }
    }

    public class OfflineCourse : Course
    {
        public string Address { get; set; }
    }
}
