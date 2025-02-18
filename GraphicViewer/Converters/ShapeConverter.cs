using GraphicViewer.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using GraphicViewer.Constants;

namespace GraphicViewer.Converters
{
    public class ShapeConverter : JsonConverter<Shape>
    {
        public override Shape ReadJson(JsonReader reader, Type objectType, Shape existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
          
            JObject jsonObject = JObject.Load(reader);

            // Get the type of shape
            string type = jsonObject[ShapeName.Type].ToString();

            // Create the shape based on the type 
          
            Shape shape;
            switch (type)
            {
                case ShapeName.Line:
                    shape = new Line();
                    break;
                case ShapeName.Circle:
                    shape = new Circle();
                    break;
                case ShapeName.Triangle:
                    shape = new Triangle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Invalid shape type");
            }
            serializer.Populate(jsonObject.CreateReader(), shape);

            return shape;
        }

        public override void WriteJson(JsonWriter writer, Shape value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
