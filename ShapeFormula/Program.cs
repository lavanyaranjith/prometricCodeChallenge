using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFormula
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape[] shapes = {

                //2.Define a Circle
                new Circle(3),

                //3.Define a Triangle object
                new Triangle(10,22,10,9),

                 //4.Define 2 different quadrilaterals, a Square and Rectangle
                 new Rectangle(10, 12),
                 new Square(5)

            };
         
           Console.WriteLine($"********** Print the unsorted shape list ***************");
          //  Console.WriteLine(Environment.NewLine);
          Shape.PrintShapes(shapes.ToList());

            //5. Sort a collection of Shapes by Area
            var orderShapes = shapes.OrderBy(o => o.Area).ToList();
            Console.WriteLine($"********** Print the sorted shape list by Area ***********");
           // Console.WriteLine(Environment.NewLine);
            Shape.PrintShapes(orderShapes);
     
            //6.Serialize/store shapes in various formats on disk
            var jsonConvert = JsonConvert(orderShapes);
            Console.WriteLine($"********** Convert Shape object to JSON ***********");
            Console.WriteLine($" {jsonConvert}");
            Console.WriteLine(Environment.NewLine);

            //7.number of Shape objects created
            Console.WriteLine($"Instance Count {Shape.InstanceCount}");
            Console.WriteLine(Environment.NewLine);
            Console.ReadLine();
        }

        

        private static string JsonConvert(List<Shape> shapes)
        {
            string retVal = String.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                foreach (var shape in shapes)
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(shape.GetType());
                    serializer.WriteObject(ms, shape.GetType().Name);
                    serializer.WriteObject(ms, shape);
                }
                var byteArray = ms.ToArray();
                retVal = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }
            return retVal;

        }
    }
}
