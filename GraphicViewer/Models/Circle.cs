using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicViewer.Models
{
    public class Circle : Shape
    {
        public string Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
    }
}
