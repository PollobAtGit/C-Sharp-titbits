using GOFBuilderPattern.Vehicle;
using GOFBuilderPattern.VehicleParts;

namespace GOFBuilderPattern.Builder
{
    public abstract class CarBuilder
    {
        private readonly Car _vechileToBuild;
        public Car Vehicle { get => _vechileToBuild; }

        public CarBuilder(Car vehicle)
        {
            _vechileToBuild = vehicle;
        }

        internal void AddEngine()
        {
            Vehicle.Engine = new Engine();
        }

        internal void AddTire()
        {
            Vehicle.Tire = new Tire();
        }

        internal void AddFrame()
        {
            Vehicle.Frame = new Frame();
        }

        internal void DoColor()
        {
            Vehicle.Color = "BLACK";
        }

        internal void DoTestDrive()
        {
            //TODO: Logic to test drive
            Vehicle.Status = CarStatus.READY_FOR_ROAD;
        }
    }
}