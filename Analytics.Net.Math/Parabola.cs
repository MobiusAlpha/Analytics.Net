using System;
using System.Drawing;

namespace Mathematics
{
    public class Parabola
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Parabola(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Parabola(Point point1, Point point2, Point point3)
        {
            A = ((point2.Y - point1.Y)*(point1.X - point3.X) + (point3.Y - point1.Y)*(point2.X - point1.X)) /
                ((point1.X - point3.X)*(Math.Pow(point2.X,2) - Math.Pow(point1.X, 2)) + (point2.X - point1.X)*(Math.Pow(point3.X, 2) - Math.Pow(point1.X,2)));
            B = ((point2.Y - point1.Y) - A*(Math.Pow(point2.X, 2) - Math.Pow(point1.X, 2))) / (point2.X - point1.X);
            C = point1.Y - A*Math.Pow(point1.X, 2) - B*point1.X;
        }

        public override string ToString()
        {
            return $"f(x) = {A}x^2+{B}x+{C}";
        }
    }
}