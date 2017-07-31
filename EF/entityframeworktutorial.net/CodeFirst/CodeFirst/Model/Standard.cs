using System.Collections.Generic;

namespace CodeFirst.Model
{
    public class Standard
    {
        public Standard()
        {

        }

        public int StandardID { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}