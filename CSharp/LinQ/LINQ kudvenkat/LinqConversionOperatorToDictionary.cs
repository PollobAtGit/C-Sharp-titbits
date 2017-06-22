using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqConversionOperatorToDictionary
{
    internal class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => Id + "\t" + Name;
    }

    internal class Client
    {
        private static readonly IList<Student> _students;

        static Client()
        {
            _students = new List<Student>
            {
                new Student { Id = "Ix", Name = "TAZUDDING" },
                new Student { Id = "Yx", Name = "KAMAL" },
                new Student { Id = "Fx", Name = "UDAY" }
            };
        }

        public static void Main()
        {
            IDictionary<string, Student> studentDic = _students.ToDictionary<Student, string>(student => student.Id);

            IterateOverDictionary<string, Student>(studentDic);

            //Poi: This operation will not have any impact on 'studentDic' because ToDictionary(...) is a conversion
            //operator so it follows greedy approach
            _students.Add(new Student { Id = "Tx", Name = "PORITOSH" });

            IterateOverDictionary<string, Student>(studentDic);
        }

        private static void IterateOverDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            Console.WriteLine();
            foreach(KeyValuePair<TKey, TValue> item in source)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
        }
    }
}