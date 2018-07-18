using System;
using System.Collections.Generic;

namespace XmlSerialization
{
    [Serializable]
    public class Department
    {
        public string Name { get; set; }

        public long TotalStudentCount { get; set; }

        public List<Course> Courses { get; set; }

        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{Environment.NewLine}Department name => {Name}, Student count => {TotalStudentCount}, Courses => {string.Join(", ", Courses)}, Students => {string.Join(", ", Students)}";
        }
    }
}