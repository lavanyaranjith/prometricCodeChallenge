using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFormula
{
    [DataContract]
    public abstract class Shape
    {
        public static int InstanceCount;

        [DataMember]
        public abstract double Area { get; internal set; }

        [DataMember]
        public abstract double Perimeter { get; internal set; }

        public override string ToString() => GetType().Name;

        public static double GetArea(Shape shape) => shape.Area;

        public static double GetPerimeter(Shape shape) => shape.Perimeter;

        public static void PrintShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape}: Area - {Shape.GetArea(shape)}; " +
                                  $"Perimeter - {Shape.GetPerimeter(shape)};");
                var rect = shape as Rectangle;
                if (shape is Rectangle)
                {
                    Console.WriteLine($"Is Square: {rect.IsSquare()}" + Environment.NewLine);
                    continue;
                }
                var tri = shape as Triangle;
                if (tri != null)
                {
                    Console.WriteLine($"Triangle Type: {tri.TriangleCheck()}" + Environment.NewLine);
                    continue;
                }
            }

        }

    }
}
