namespace CodeFirst.Model
{
    public enum Importance
    {
        MILD,
        SEVERE
    }

    // POI: Rule is added as DbSet<Rule> in Context class so it must contain an ID property
    public abstract class Rule
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

    public class SchedulingRule : Rule
    {
        public string ApplicableToTeacher { get; set; }
    }
}
