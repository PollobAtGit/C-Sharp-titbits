namespace CodeFirst.Model
{
    // POI: EF will create a table against this table as it's included as DbSet<Cook> in Context class
    // POI: All the DISCOVERED columns from the derived class (Type) of this class (Type) will be included
    // as columns of the Base class

    public class Cook
    {
        public int ID { get; set; }
        public string Responsibility { get; set; }
    }

    // POI: This derived class (Type) will be discovered but only the columns from this table will be added
    // into the original table
    public class CookForTeacher : Cook
    {
        public string Experience { get; set; }
    }

    public class PersonalCook : Cook
    {
        public string PhoneNumber { get; set; }
    }
}
