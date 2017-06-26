using System.Collections.Generic;

namespace Venkat___Entity_Framework.Tut.Part_3.Model
{
    //TODO: Why internal class can have public instance member? Internals are not accessible outside
    //current project. But public members are accessible anywhere (publicly)

    //POI: Code First approach pluralized the entity names

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; }
    }
}