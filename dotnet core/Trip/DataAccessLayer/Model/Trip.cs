using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Trip
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        [Required]
        public string PickupPoint { get; set; }

        public override string ToString() => $"Id: {Id}; destination: {Destination}; Pickup point: {PickupPoint}";

        public void Copy(Trip copyInstance)
        {
            Destination = copyInstance.Destination;
            PickupPoint = copyInstance.PickupPoint;
        }
    }
}