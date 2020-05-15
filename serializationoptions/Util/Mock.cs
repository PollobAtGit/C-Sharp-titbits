using System.Collections.Generic;
using System.Linq;
using serializationoptions.Model;

namespace serializationoptions.Util
{
    public static class Mock
    {
        public static List<Person> Persons()
        {
            var persons = new List<Person>();

            foreach (var i in Enumerable.Range(0, 1000))
            {
                persons.Add(new Person
                {
                    Id = 1,
                    Name = "some",
                    Address = new Address
                    {
                        Line = "asd",
                        ZipCode = "new"
                    }
                });
            }

            return persons;
        }

        public static List<Employee> Employees()
        {
            var employees = new List<Employee>();

            foreach (var i in Enumerable.Range(0, 100))
            {
                employees.Add(new Employee
                {
                    Id = 1,
                    Name = "some",
                    Address = new Address
                    {
                        Line = "asd",
                        ZipCode = "new"
                    },
                    Nid = "56"
                });
            }

            return employees;
        }
    }
}