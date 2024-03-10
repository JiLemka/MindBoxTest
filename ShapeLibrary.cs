using System;

namespace MindBoxLibrary
{
    public interface IShape
    {
        double GetArea();
    }
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Радиус не может быть отрицательным.");

            return Math.PI * radius * radius;
        }
    }

    public class Triangle : IShape
    {
        private double side1, side2, side3;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double GetArea()
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentOutOfRangeException("Стороны треугольника должны быть положительными.");

            if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side3)
                throw new ArithmeticException("Треугольник с такими сторонами не существует");

            double halfPerimeter = (side1 + side2 + side3) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - side1) * (halfPerimeter - side2) * (halfPerimeter - side3));
        }

        public bool IsRightAngled()
        {
            return (side1 * side1 + side2 * side2 == side3 * side3) ||
                   (side1 * side1 + side3 * side3 == side2 * side2) ||
                   (side2 * side2 + side3 * side3 == side1 * side1);
        }
    }

    public static class ShapeExtensios
    {
        public static double GetArea(this IShape shape)
        {
            if (shape is Circle circle)
                return circle.GetArea();
            else if (shape is Triangle triangle)
                return triangle.GetArea();
            else
                throw new InvalidOperationException("Неизвестная фигура");
        }
    }
}
