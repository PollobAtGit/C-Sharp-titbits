using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Ado_101
{
    internal static class Client
    {
        private static SqlConnection _Connection;
        private static SqlCommand _Command;

        static Client()
        {
            _Connection = new SqlConnection("Data Source=;Initial Catalog=;Integrated Security=SSPI");
            _Command = new SqlCommand
            {
                Connection = _Connection
            };
        }

        internal static void Main()
        {
            foreach(Student student in GetAllStudents())
            {
                // Console.Write(student.StudentId + "\t" + student.StudentName + "\t" + student.StandardId);
                Console.WriteLine();
            }
        }

        private static IList<Student> GetAllStudents()
        {
            try
            {
                _Command.CommandText = @"SELECT * FROM [dbo].[Student]";

                _Connection.Open();

                IList<Student> stnds = _Command.ExecuteReader().ToStudents();

                Console.WriteLine(stnds.Count);

                return stnds;
            }
            catch(Exception) { return null; }
            finally
            {
                _Connection.Close();
            }
        }

        private class Student
        {
            public int StudentId;
            public string StudentName;
            public string StandardId;

            // public IList<Student> ConvertReaderTo
        }

        //Poi: Extension method can be private. This is useful to make code readable
        private static IList<Student> ToStudents(this SqlDataReader source)
        {
            IList<Student> students = new List<Student>();

            while(source.Read())
            {
                int id;
                if(!int.TryParse(source["StudentID"] as string, out id)) continue;

                Student student = new Student
                {
                    StudentId = id,
                    StudentName = source["StudentName"] as string,
                    StandardId = source["StandardId"] as string
                };

                Console.Write(student.StudentId + "\t" + student.StudentName + "\t" + student.StandardId);
                Console.WriteLine();
                
                students.Add(student);
            }

            return students;
        }
    }
}
