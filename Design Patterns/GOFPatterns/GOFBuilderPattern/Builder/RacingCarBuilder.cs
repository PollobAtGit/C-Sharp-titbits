using GOFBuilderPattern.Vehicle;

namespace GOFBuilderPattern.Builder
{
    public class RacingCarBuilder : CarBuilder
    {
        //POI: If the abstract base class requires a constructor than the derived class must provide that
        public RacingCarBuilder(Car car) : base(car) { }
    }
}
