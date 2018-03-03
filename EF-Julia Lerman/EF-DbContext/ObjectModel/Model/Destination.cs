using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectModel.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required, Column("LocationName")]
        public string Name { get; set; }

        public string Country { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public string TravelWarnings { get; set; }

        public string ClimateInfo { get; set; }

        // POI: For convenience we can keep some navigation property virtual or some non-virtual
        // POI: In other words we can selectively enable lazy loading for some navigation property
        public List<Lodging> Lodgings { get; set; }

        public override string ToString() => DestinationId + " => " + Name;
    }
}