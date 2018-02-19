namespace CodeFirst.Model
{
    public class Teacher : Entity
    {
        public Teacher()
        {

        }

        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
    }

    public class SeniorTeacher : Teacher
    {
        public string Designation { get; set; }
    }

    public class HeadMaster : Teacher
    {
        public double Experience { get; set; }
    }
}