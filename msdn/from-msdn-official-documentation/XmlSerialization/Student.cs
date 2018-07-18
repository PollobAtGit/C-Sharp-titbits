using System;
using System.Collections.Generic;

namespace XmlSerialization
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }

        public string NationalIdCardNumber { get; set; }

        public List<string> ContactInfos { get; set; }

        public override string ToString()
        {
            return $"{Environment.NewLine}Student name => {Name}, NID => {NationalIdCardNumber}, Infos => {string.Join(", ", ContactInfos)}";
        }
    }
}