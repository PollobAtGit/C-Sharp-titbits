using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace XmlSerialization
{
    class Program
    {
        private const string XmlFileName = "./university.xml";

        static void Main()
        {
            //Serialize();
            Deserialize();
        }

        private static void Deserialize()
        {
            var serializer = new XmlSerializer(typeof(List<University>));

            Console.WriteLine("De-serialization - [STARTING]" + Environment.NewLine);

            var fileStream = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read);

            var deserializedUniversity = serializer
                .Deserialize(fileStream) as List<University>;

            var multipleNewLine = string
                .Join(string.Empty, Enumerable.Range(1, 3)
                    .Select(x => Environment.NewLine));

            Console.WriteLine(string.Join(multipleNewLine, deserializedUniversity));
        }

        private static void Serialize()
        {
            var university = GetSampleUniversity();

            var serializer = new XmlSerializer(typeof(List<University>));

            var writer = new StreamWriter(XmlFileName);

            serializer.Serialize(writer, new University[] { university, university }.ToList());

            writer.Close();

            Console.WriteLine("Serialization - [DONE]" + Environment.NewLine);
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
                Name = new UniversityName { Name = "AIUB", Culture = "eng" },
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
