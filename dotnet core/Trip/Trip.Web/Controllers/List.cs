using System.ComponentModel.DataAnnotations;

namespace Trip.Web.Controllers
{
    public class Trip
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        [Required]
        public string PickupPoint { get; set; }

        public void Copy(Trip copyInstance)
        {
            Destination = copyInstance.Destination;
            PickupPoint = copyInstance.PickupPoint;
        }
    }
}