using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicViewer.Models;

namespace GraphicViewer.ViewModels
{
    public class LineViewModel : ShapeViewModel
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        // create the shape of "Line"
        public LineViewModel(string a, string b, Color color)
        {
            var pointA = ParseCoordinates(a);
            var pointB = ParseCoordinates(b);

            X1 = pointA.X;
            Y1 = pointA.Y;
            X2 = pointB.X;
            Y2 = pointB.Y;

            Stroke = new SolidColorBrush(color);
        }

        private Point ParseCoordinates(string coordinates)
        {
            var parts = coordinates.Split(';');
            double x = double.Parse(parts[0].Trim());
            double y = double.Parse(parts[1].Trim());
            return new Point(x, y);
        }
    }
}
