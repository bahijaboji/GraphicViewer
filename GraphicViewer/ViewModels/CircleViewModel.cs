using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicViewer.Models;

namespace GraphicViewer.ViewModels
{
    public class CircleViewModel : ShapeViewModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        // create the shape of "Circle"
        public CircleViewModel(string center, double radius, bool filled, Color color)
        {
            var centerPoint = ParseCoordinates(center);

            X = centerPoint.X - radius;
            Y = centerPoint.Y - radius;
            Width = radius * 2;
            Height = radius * 2;

            Stroke = new SolidColorBrush(color);
            Fill = filled ? new SolidColorBrush(color) : Brushes.Transparent;
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