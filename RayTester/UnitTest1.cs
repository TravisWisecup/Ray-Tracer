using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayTester
{
    [TestClass]
    public class RayTest
    {
        [TestMethod]
        public void Constructor_Test()
        {
            var ray = new Ray(Vector3.Zero, Vector3.One);
            Assert.AreEqual(Vector3.Zero, ray.start);
            Assert.AreEqual(Vector3.One, ray.end);
        }

    }
    [TestClass]
    public class Vector3Test
    {
        [TestMethod]
        public void Storing_Function()
        {
            var vector3 = new Vector3(3, 4, 5);
            Assert.AreEqual(3, vector3.x);
            Assert.AreEqual(4, vector3.y);
            Assert.AreEqual(5, vector3.z);
        }
        [TestMethod]
        public void Getting_Length()
        {
            var vector3 = new Vector3(3, 4, 0);
            Assert.AreEqual(5, vector3.length());
        }
        [TestMethod]
        public void Normalize_Function()
        {
            var vector3 = new Vector3(0, 0, 1);
            vector3.normalize();
            Assert.AreEqual(0, vector3.x);
            Assert.AreEqual(0, vector3.y);
            Assert.AreEqual(1, vector3.z);

            vector3 = new Vector3(1, 1, 0);
            vector3.normalize();
            Assert.AreEqual((1 / Math.Sqrt(2)), vector3.x);
            Assert.AreEqual((1 / Math.Sqrt(2)), vector3.y);
            Assert.AreEqual(0, vector3.z);
            Assert.IsTrue(Math.Abs(vector3.length() - 1) < .001);

            vector3 = new Vector3(1, 1, 0);
            vector3.normalize(vector3);
            Assert.AreEqual((1 / Math.Sqrt(2)), vector3.x);
            Assert.AreEqual((1 / Math.Sqrt(2)), vector3.y);
            Assert.AreEqual(0, vector3.z);
            Assert.IsTrue(Math.Abs(vector3.length() - 1) < .001);
        }
        [TestMethod]
        public void Scaling_Function()
        {
            Vector3 v3 = new Vector3(3, 4, 5);
            v3.scale(.5);
            Assert.AreEqual(1.5, v3.x);
            Assert.AreEqual(2, v3.y);
            Assert.AreEqual(2.5, v3.z);

            v3 = new Vector3(3, 4, 5);
            v3.scale(.5).scale(2);
            Assert.AreEqual(3, v3.x);
            Assert.AreEqual(4, v3.y);
            Assert.AreEqual(5, v3.z);
        }
    }
}

