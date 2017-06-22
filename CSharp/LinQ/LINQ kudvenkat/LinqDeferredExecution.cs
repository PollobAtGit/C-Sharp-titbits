using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqDeferredExecution
{

    internal class Student
    {
        public string Id { get; set; }

        public override string ToString() => Id;
    }

    internal class Client
    {

        private static readonly IList<Student> _students;

        static Client()
        {
            _students = new List<Student>
            {
                new Student { Id = "XXTY" },
                new Student { Id = "TYU" },
                new Student { Id = "BNG" }
            };
        }

        public Client() { }

        public static void Main()
        {
            int totalNumberOfStudents = _students.Count<Student>();

            IEnumerable<Student> filteredStudents = _students.Where<Student>(student => student.Id.Contains("TY"));
            IEnumerable<Student> filteredStudentsToList = _students.Where<Student>(student => student.Id.Contains("TY")).ToList<Student>();

            IterateOverSequence<Student>(filteredStudents);
            IterateOverSequence<Student>(filteredStudentsToList);

            _students.Add(new Student { Id = "TYT" });

            //Poi: 'filteredStudents' actually contains a QUERY not the result. So WITHOUT ANY MODIFICATION the SAME query produces a different
            //result set here
            IterateOverSequence<Student>(filteredStudents);

            //Poi: This result set is the SAME because 'filteredStudentsToList' was populated with GREEDY approach & used greedy operator here
            //is 'ToList<TSource>(...)'
            IterateOverSequence<Student>(filteredStudentsToList);
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            Console.WriteLine();
            foreach(T item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}
