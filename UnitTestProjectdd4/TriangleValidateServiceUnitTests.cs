using Microsoft.VisualStudio.TestTools.UnitTesting;
using integtest;
using Moq;
using System;
using System.Collections.Generic;
using Npgsql;
using integtest.Interfaces;
using integtest.Classes;
using Microsoft.EntityFrameworkCore;

namespace Laba4Tests
{
    [TestClass]
    public class TriangleValidateServiceUnitTests
    {
        private Mock<ITriangleProvider> triangleProvider;
        private ITriangleService triangleService;
        private ITriangleValidateService triangleValidateService;
        [TestInitialize]
        public void TestInitialize()
        {
            triangleProvider = new Mock<ITriangleProvider>();
            triangleService = new TriangleService();
            triangleValidateService = new TriangleValidateService(triangleProvider.Object, triangleService);
        }
        [TestMethod]
        public void IsValid_True()
        {
            triangleProvider.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Triangle(1, 7, 7, 7, 21.21762239271875, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon,false));
            Assert.AreEqual(true, triangleValidateService.IsValid(1));
        }
        [TestMethod]
        public void IsValid_False()
        {
            triangleProvider.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Triangle(2, -7, 7, 7, 0.0027712812921102037, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon,false));
            Assert.AreEqual(false, triangleValidateService.IsValid(2));
        }

        [TestMethod]
        public void IsAllValid_True()
        {
            triangleProvider.Setup(m => m.GettAll()).Returns(new List<Triangle> { new Triangle(3, 7, 7, 7, 21.21762239271875, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, true), new Triangle(4, 7, 7, 7, 21.21762239271875, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, true) });
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsValid_EmptyTriangle()
        {
            triangleProvider.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Triangle());
            Assert.AreEqual(false, triangleValidateService.IsValid(4));

        }
        
        [TestMethod]
        public void IsAllValid_False()
        {
            triangleProvider.Setup(m => m.GettAll()).Returns(new List<Triangle> { new Triangle(5, -7, 7, 7, 0.0027712812921102037, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon,false), new Triangle(6, -7, 7, 7, 0.0027712812921102037, Triangle.TriangleType.Equilateral | Triangle.TriangleType.Oxygon, false) });
            Assert.AreEqual(false, triangleValidateService.IsAllValid());

        }
        [TestMethod]
        public void IsAllValid_EmptyTriangle()
        {
            triangleProvider.Setup(m => m.GettAll()).Returns(new List<Triangle> { new Triangle(), new Triangle() });
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }

      
    }
}