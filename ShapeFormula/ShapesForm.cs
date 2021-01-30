using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFormula
{
    [DataContract]
    public class Square : Shape
    {
        public Square(double length)
        {
            Side = length;
            InstanceCount++;
        }      
        public double Side { get; }

        private double area;
        [DataMember]
        public override double Area {
           
            get { return Math.Pow(Side, 2); }
            internal set { area = value; }         }

        private double perimeter;
        [DataMember]
        public override double Perimeter {get { return Side * 4; } internal set { perimeter = value; }
        }

        //public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
    }
    
    [DataContract]
    public class Rectangle : Shape
    {
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
            InstanceCount++;
        }

        public double Length { get; }

        public double Width { get; }

        private double area;
        [DataMember]
        public override double Area { get { return Length * Width; } internal set { area = value; } }

        private double perimeter;
        [DataMember]
        public override double Perimeter { get { return 2 * Length + 2 * Width; } internal set { Perimeter = value; } }

        public bool IsSquare() => Length == Width;

        public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
    }

    [DataContract]
    public class Triangle : Shape
    {
        public Triangle(double baseWidth,double height, double side1, double side2)
        {
            BaseWidth = baseWidth;
            Side2 = side2;
            Side1 = side1;
            Height = height;
            InstanceCount++;
        }

        public double BaseWidth { get; }
        public double Height { get; }
        public double Side1 { get; }
        public double Side2 { get; }

        private double area;
        [DataMember]
        public override double Area
        {
            get {  return (BaseWidth * Height) / 2; }
            internal set { area = value; }
        }

        private double perimeter;
        [DataMember]
        public override double Perimeter { get { return BaseWidth + Side1 + Side2; } internal set { perimeter = value; } }

       // public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);

        public string TriangleCheck()
        {
            if (BaseWidth == Side1 && Side1 == Side2)
                return "Equilateral Triangle";
            else if (Side1 == Side2 || Side2 == BaseWidth || BaseWidth == Side1)
                return "Isosceles Triangle";
            else
                return "Scalene Triangle";
        }
    }

    [DataContract]
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
            InstanceCount++;
        }

        private double area;
        [DataMember]
        public override double Area {
            get { return Math.Round(Math.PI * Math.Pow(Radius, 2), 2); }
            internal set { area = value; }
        }

        private double perimeter;
        [DataMember]
        public override double Perimeter {
            get { return Math.Round(Math.PI * 2 * Radius, 2); }
            internal set { perimeter = value; }
        }

       public double Radius { get; }

    }
    
}
