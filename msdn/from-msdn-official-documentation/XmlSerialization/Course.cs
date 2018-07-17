using System;
using System.Collections.Generic;

namespace XmlSerialization
{
    [Serializable]
    public class Course
    {
        public string Name { get; set; }

        public decimal TutionFeePerCredit { get; set; }

        public List<Student> Students { get; set; }
    }
}