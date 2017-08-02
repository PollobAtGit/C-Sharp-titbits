namespace CodeFirst.Model
{
    // POI: Aliasing a generic Type
    using IC = System.Collections.Generic.ICollection<Student>;

    public class Standard
    {
        public Standard()
        {

        }

        public string StandardName { get; set; }

        // POI: This property represents the primary column & in this case also Identity column 
        // (as data type is integer. By default if an ID column's data type is numeric or Guid then it is
        // configured by EF as Identity column)

        // POI: EF by default, creates column order in the same order of the entity properties
        // POI: But because it's the primary column it will be MOVED to the beginning of the column order
        public int StandardID { get; set; }

        public IC Students { get; set; }

        // POI: Navigation property
        // POI: This entity/model is not added as DbSet<Teacher> in Context class
        // POI: But table will be created in DB for this entity because EF will DISCOVER this entity & will
        // rightly asssume we will need this entity to work with Standard entity
        // POI: Also necessary primary key & foreign key relationship will also be maintained

        public Teacher Teacher { get; set; }
    }
}