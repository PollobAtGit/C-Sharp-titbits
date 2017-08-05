namespace CodeFirst.Model
{
    using System.Collections.Generic;

    public enum Importance
    {
        MILD,
        SEVERE
    }

    // POI: Rule is added as DbSet<Rule> in Context class so it must contain an ID property
    public abstract class Rule : Entity
    {
        public int ID { get; set; }
        public Importance Importance { get; set; }
    }

    // POI: This Type will be DISCOVERED by EF as the base abstract class is mentioned as DbSet<Rule> in the
    // Context class but this class will not have a table with this same name rather the base class named
    // table will contain the columns from this Type & other derived Types (if any)

    public class AssemblyRule : Rule
    {
        public string ApplicableToClass { get; set; }
    }

    // POI: *-* relationship between this Type & Employee Type is not indicated here
    public class SchedulingRule : Rule
    {
        // POI: Using ICollection<TModel> is the proper approach to define a navigation
        // porperty
        public ICollection<Employee> Employees { get; set; }
        public string ApplicableToTeacher { get; set; }
    }
}
