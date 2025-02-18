using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicViewer.Models
{
    public class Triangle : Shape
    {
        public string A { get; set; }
        public string B { get; set; } 
        public string C { get; set; } 
        public bool Filled { get; set; }
    }
}
