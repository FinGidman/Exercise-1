using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoYourTriangleExists.Tests
{
    [TestClass]
    public class DoYourTriangleExistsTests
    {
        DoYourTriangleExists TestMethod = new DoYourTriangleExists();

        [TestMethod]
        public void RightTriangle()
        {
            Assert.IsTrue(TestMethod.IsTriangleExist(3, 4, 5), "Ошибка при проверке прямоугольного треугольника");
        }

        [TestMethod]
        public void EquilateralTriangle()
        {
            Assert.IsTrue(TestMethod.IsTriangleExist(3, 3, 3), "Ошибка при проверке равностроннего треугольника");
        }

        [TestMethod]
        public void UnrightTriangle()
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(3, 4, 20), "Ошибка при проверке несуществующего треугольника");
        }

        [TestMethod]
        public void DegenerateTriangle() 
        {
            Assert.IsTrue(TestMethod.IsTriangleExist(1, 1, 2), "Ошибка при проверке вырожденного треугольника");
        }

        [TestMethod]
        public void TriangleWith1Negative() 
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(-3, 4, 5), "Ошибка при проверке треугольника с отрицательной стороной");
        }

        [TestMethod]
        public void TriangleWith2Negative()
        {       
            Assert.IsFalse(TestMethod.IsTriangleExist(-3, -4, 5), "Ошибка при проверке треугольника с двумя отрицательными сторонами");
        }

        [TestMethod]
        public void TriangleWith3Negative()
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(-3, -4, -5), "Ошибка при проверке треугольника с тремя отрицательными сторонами");
        }

        [TestMethod]
        public void TriangleWith1null() 
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(0, 4, 5), "Ошибка при проверке треугольника с нулевой стороной");
        }

        [TestMethod]
        public void TriangleWith2null()
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(0, 0, 5), "Ошибка при проверке треугольника с двумя сторонами");
        }

        [TestMethod]
        public void TriangleWith3null()
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(0, 0, 0), "Ошибка при проверке треугольника с тремя сторонами");
        }

        [TestMethod]
        public void TriangleWithNegativeAndNull()
        {
            Assert.IsFalse(TestMethod.IsTriangleExist(0, -4, 5), "Ошибка при проверке треугольника с нулевой и отрицательной стороной");
        }
    }
}
