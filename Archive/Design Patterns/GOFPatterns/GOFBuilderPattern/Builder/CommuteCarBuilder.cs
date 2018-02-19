using GOFBuilderPattern.Vehicle;

namespace GOFBuilderPattern.Builder
{
    public class CommuteCarBuilder : CarBuilder
    {
        public CommuteCarBuilder(Car car) : base(car) { }
    }
}
