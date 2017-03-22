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
            _Connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=SSPI");
            _Command = new SqlCommand
            {
                Connection = _Connection
            };
        }

        internal static void Main()
        {
            foreach(Student student in GetAllStudents())
            {
                Console.Write(student.StudentId + "\t" + student.StudentName + "\t" + student.StandardId);
                Console.WriteLine();
            }
        }

        private static IList<Student> GetAllStudents()
        {
            try
            {
                _Command.CommandText = @"SELECT * FROM [dbo].[Student]";
                _Connection.Open();
                return _Command.ExecuteReader().ToStudents();
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
        }

        //Poi: Extension method can be private. This is useful to make code readable
        private static IList<Student> ToStudents(this SqlDataReader source)
        {
            IList<Student> students = new List<Student>();

            while(source.Read())
            {
                Student student = new Student
                {
                    //Poi: Using Convert.ToInt32 because conversion from object to string & then using
                    //int.TryParse() on that string is not properly working
                    StudentId = Convert.ToInt32(source["StudentID"]),
                    StudentName = source["StudentName"] as string,
                    StandardId = source["StandardId"] as string
                };

                students.Add(student);
            }

            return students;
        }
    }
}
