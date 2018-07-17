using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace XmlSerialization
{
    class Program
    {
        static void Main()
        {
            var university = GetSampleUniversity();

            var serializer = new XmlSerializer(typeof(List<University>));

            var writer = new StreamWriter("./university.xml");

            serializer.Serialize(writer, new[]
            {
                university,
                university
            }.ToList());

            writer.Close();
        }

        private static University GetSampleUniversity()
        {
            var dummyStudents = new List<Student>
            {
                new Student
                {
                    Name ="a",
                    ContactInfos = new List<string> { "123"},
                    NationalIdCardNumber = "xTy"
                }
            };

            return new University
            {
                Name = "AIUB",
                IsEngineeringUniversity = false,
                UniversityCode = "XRT",
                Location = new Address
                {
                    City = "Dhaka",
                    HouseNo = "64",
                    RoadNo = "05"
                },
                Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Computer Science And Engineering",
                        TotalStudentCount = 10,
                        Students = dummyStudents,
                        Courses = new List<Course>
                        {
                            new Course
                            {
                                Name = "tyu",
                                Students = dummyStudents
                            }
                        }
                    }
                }
            };
        }
    }
}
