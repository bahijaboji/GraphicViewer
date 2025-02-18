using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicViewer.ViewModels
{
    public abstract class ShapeViewModel
    {
        public Brush Stroke { get; set; } //Color of the shape’s outline
        public Brush Fill { get; set; } //Color of the shape’s fill
    }
}
