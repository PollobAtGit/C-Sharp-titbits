using GOFBuilderPattern.VehicleParts;

namespace GOFBuilderPattern.Vehicle
{
    //POI: Because of the introduction of Builder no creation logic of car parts are in this Type
    //POI: This Type can also contain an instance to Builder (if required)
    public abstract class Car
    {
        public string Color { get; internal set; }
        internal Frame Frame { get; set; }
        internal Tire Tire { get; set; }
        internal Engine Engine { get; set; }
        internal CarStatus Status { get; set; }
    }
}