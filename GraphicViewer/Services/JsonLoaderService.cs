using GraphicViewer.Converters;
using GraphicViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicViewer.Services
{
    public class JsonLoaderService
    {
        public List<Shape> LoadShapes(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            string json = File.ReadAllText(filePath);

            // Configure JSON deserialization with the custom converter
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ShapeConverter() }
            };

            var shapes = JsonConvert.DeserializeObject<List<Shape>>(json, settings);
            return shapes;
        }
    
}
}
