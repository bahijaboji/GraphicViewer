using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicViewer.Models;

namespace GraphicViewer.ViewModels
{
    public class TriangleViewModel : ShapeViewModel
    {
        public PointCollection Points { get; set; }
        // create the shape of "Triangle"
        public TriangleViewModel(string a, string b, string c, bool filled, Color color)
        {
            Points = new PointCollection
            {
                ParseCoordinates(a),
                ParseCoordinates(b),
                ParseCoordinates(c)
            };

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