namespace CommonLib.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        public string Location { get; set; }

        // POI: Enables ConcurrencyCheck
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        // POI: Navigation properties should be virtual to get lazy loading facility
        // POI: To support egar loading discard 'virtual' & use Include to get the related entities
        public virtual Instructor Instructor { get; set; }
    }
}
