using CircleMvp.Models;
using CircleMvp.View;

namespace CircleMvp.Presenter
{
    class Presenter
    {
        private IView View { get; }

        public Presenter(IView view)
        {
            View = view;
        }

        public double CalculateCircleArea()
        {
            var circle = new Circle();
            var radiusText = string.IsNullOrWhiteSpace(View.RadiusText) ? "0" : View.RadiusText;

            var circleArea = circle.GetArea(double.Parse(radiusText ?? "0"));

            View.ResultText = circleArea.ToString();

            return circleArea;
        }
    }
}