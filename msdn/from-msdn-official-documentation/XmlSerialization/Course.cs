using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    public class Course
    {
        public string Name { get; set; }

        public decimal TutionFeePerCredit { get; set; }

        [XmlIgnore]
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            var studentFormat = Students == null ? string.Empty : $", Students => {string.Join(", ", Students)}";

            return $"{Environment.NewLine}Name => {Name}, Tution fee => {TutionFeePerCredit}{studentFormat}";
        }
    }
}