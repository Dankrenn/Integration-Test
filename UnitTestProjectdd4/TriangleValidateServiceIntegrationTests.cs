using Microsoft.VisualStudio.TestTools.UnitTesting;
using integtest;
using Moq;
using System;
using System.Collections.Generic;
using Npgsql;
using integtest.Interfaces;
using integtest.Classes;
using Microsoft.EntityFrameworkCore;
using static Triangle;

namespace Laba4Tests
{
    [TestClass]
    public class TriangleValidateServiceIntegrationTests
    {
        private ITriangleProvider triangleProvider;
        private ITriangleService triangleService;
        private ApplicationContext applicationContext;
        private ITriangleValidateService triangleValidateService;


        [TestInitialize]
        public void TestInitialize()
        {
            triangleProvider = new TriangleProvider();
            triangleService = new TriangleService();
            applicationContext = new ApplicationContext();
            triangleValidateService = new TriangleValidateService(triangleProvider, triangleService, applicationContext);
        }
        [TestMethod]
        public void IsValidTrue()
        {
            triangleProvider.Save(new Triangle(1, 9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon,false));
            bool actual = triangleValidateService.IsValid(1);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestSave12Triangles()
        {
            triangleProvider.Save( new Triangle(12, 55, 55, 55, 1309.863, TriangleType.Scalene | TriangleType.Obtuse,  true));
            bool actual = triangleValidateService.IsValid(12);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestAllValideTrianglesIsTrue()
        {
            bool actual;
            triangleProvider.Save(new Triangle(1, 3, 4, 5, 8,TriangleType.Scalene | TriangleType.Obtuse, true));
            triangleProvider.Save(new Triangle(2, 2, 2, 2, 1.732, TriangleType.Equilateral | TriangleType.Oxygon,  true));
            triangleProvider.Save(new Triangle(3, 4, 6, 9, 11,TriangleType.Scalene | TriangleType.Obtuse,  true));
            if (triangleValidateService.IsValid(1) == true|| triangleValidateService.IsValid(2)|| triangleValidateService.IsValid(3))
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.IsTrue(actual);
        }




        [TestMethod]
        public void IsAllValid_false()
        {
            triangleProvider.Save(new Triangle(8, -9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, false));
            bool actual = triangleValidateService.IsAllValid();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetTypeTriangle()
        {
            Triangle triangle;
            triangleProvider.Save(triangle = new Triangle(9, 9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon,false));
            Triangle.TriangleType expected = triangle.type;
            Triangle.TriangleType actual = triangleService.GetType(triangle.a, triangle.b, triangle.c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetAreaTriangle()
        {
            Triangle triangle;
            triangleProvider.Save(triangle = new Triangle(10, 9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, false));
            double expected = triangle.area;
            double actual = triangleService.GetArea(triangle.a, triangle.b, triangle.c);
            Assert.IsTrue(Math.Abs(expected - actual) < 1e-9);
        }
        [TestMethod]
        public void IsValidTriangle()
        {
            triangleProvider.Save(new Triangle(11, 10, 10, 1, 4.993746088859544, Triangle.TriangleType.Isosceles | Triangle.TriangleType.Oxygon,false));
            Assert.IsTrue(triangleValidateService.IsValid(11));
        }

       
        [TestMethod]
        public void IsValid_TriangleTrueFalseTue()
        {
            Triangle triangle = new Triangle(96, 9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, true);
            triangleProvider.Save(triangle);
            triangleValidateService.IsValid(triangle.id);
            triangle = triangleProvider.GetById(96);
            bool actual = triangle.isvalid;
            Assert.AreEqual(false, actual);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(triangle.id);
            triangle = triangleProvider.GetById(96);
            actual = triangle.isvalid;
            Assert.AreEqual(true, actual);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(triangle.id);
            triangle = triangleProvider.GetById(96);
            actual = triangle.isvalid;
            Assert.AreEqual(false, actual);

        }

        [TestMethod]
        public void IsValid_TriangleFalseTrueFalse()
        {
            Triangle triangle = new Triangle(1, -9, 9, 9, 35.074028853269764, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, false);
            triangleProvider.Save(triangle);
            triangleValidateService.IsValid(1);
            triangle = triangleProvider.GetById(1);
            bool actual = triangle.isvalid;
            Assert.AreEqual(true, actual);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(1);
            triangle = triangleProvider.GetById(1);
            actual = triangle.isvalid;
            Assert.AreEqual(true, actual);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(1);
            triangle = triangleProvider.GetById(1);
            actual = triangle.isvalid;
            Assert.AreEqual(true, actual);

        }

        [TestMethod]
        public void IsValidTriangle_False()
        {
            Triangle triangle = new Triangle(11, 5, -9, 7, 0.1741228, Triangle.TriangleType.Isosceles |
Triangle.TriangleType.Oxygon,false);
            triangleProvider.Save(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            bool valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void IsValidTriangle_True()
        {
            Triangle triangle = new Triangle(11, 5, 9, 7, 17.41228, Triangle.TriangleType.Isosceles |
Triangle.TriangleType.Oxygon,false);
            triangleProvider.Save(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            bool valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsValid(11);
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
        }
        [TestMethod]
        public void IsAllValidTriangle_False()
        {
            Triangle triangle = new Triangle(11, 5, -9, 7, 0.1741228, Triangle.TriangleType.Isosceles |
Triangle.TriangleType.Oxygon,false);
            triangleProvider.Save(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            bool valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void IsAllValidTriangle_True()
        {
            Triangle triangle = new Triangle(11, 5, 9, 7, 17.41228, Triangle.TriangleType.Isosceles |
Triangle.TriangleType.Oxygon,false);
            triangleProvider.Save(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            bool valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
            triangle.a = -9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(false, valid);
            triangle.a = 9;
            triangleProvider.Update(triangle);
            triangleValidateService.IsAllValid();
            triangle = triangleProvider.GetById(11);
            valid = triangle.isvalid;
            Assert.AreEqual(true, valid);
        }
    }
}

