using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBoxLibrary;
using System;

namespace UnitTestForLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CircleArea_IsCorrect()
        {
            double radius = 5;
            Circle circle = new Circle(radius);

            double expectedArea = Math.PI * radius * radius;
            double actualArea = circle.GetArea();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CircleArea_NegativeRadius_ThrowsException()
        {
            double radius = -10;
            Circle circle = new Circle(radius);

            circle.GetArea();
        }

        [TestMethod]
        public void TriangleArea_ValidSides_ReturnsCorrectAre()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
            double expectedArea = 6;

            Triangle triangle = new Triangle(side1, side2, side3);
            double actualArea = triangle.GetArea();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TriangleArea_NegativeSides_ThrowsException() 
        {
            double side1 = 3;
            double side2 = -4;
            double side3 = 5;

            Triangle triangle = new Triangle(side1, side2, side3);
            triangle.GetArea();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TriangleArea_InvalidSides_ThrowsException()
        {
            double side1 = 1;
            double side2 = 1;
            double side3 = 5;

            Triangle triangle = new Triangle(side1, side2, side3);
            triangle.GetArea();
        }

        [TestMethod]
        public void Triangle_IsNotRightAngled_ReturnFalse()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 6;

            Triangle triangle = new Triangle(side1, side2, side3);
            bool isRightAngled = triangle.IsRightAngled();

            Assert.IsFalse(isRightAngled);
        }

        [TestMethod]
        public void Triangle_IsRightAngled_ReturnTrue()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;

            Triangle triangle = new Triangle(side1, side2, side3);
            bool isRightAngled = triangle.IsRightAngled();

            Assert.IsTrue(isRightAngled);
        }

        [TestMethod]
        public void ShapeExtension_Circle_ReturnsCorrectArea()
        {
            double radius = 5;
            double expectedArea = Math.PI * radius * radius;

            Circle circle = new Circle(radius);
            double actualArea = ShapeExtensios.GetArea(circle);

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void ShapeExtension_Triangle_ReturnsCorrectArea()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
            double expectedArea = 6;

            Triangle triangle = new Triangle(side1, side2, side3);
            double actualArea = ShapeExtensios.GetArea(triangle);

            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShapeExtension_UnknownShape_ThrowsException() 
        {
            IShape unknownShape = null;
            ShapeExtensios.GetArea(unknownShape);
        }
    }
}
