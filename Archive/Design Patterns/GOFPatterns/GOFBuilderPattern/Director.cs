using GOFBuilderPattern.Builder;

namespace GOFBuilderPattern
{
    public class Director
    {
        private readonly CarBuilder _builder;

        //POI: Properties can not be readonly. But keeping the underlying member variable
        //readonly helps to mitigate the problem because that variable can not be initialized from
        //anywhere else but constructor
        public CarBuilder Builder { get => _builder; }

        //POI: Properties can not be generic
        //TODO: Fix return type
        public object ConstructedCar { get => _builder.Vehicle; }

        public Director(CarBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            //POI: We can maintain any particular order here (if required). Client doesn't have to care about it
            Builder.AddEngine();
            Builder.AddTire();
            Builder.AddFrame();
            Builder.DoColor();
            Builder.DoTestDrive();
        }
    }
}
