using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayTester
{
    [TestClass]
    public class PlaneTest
    {
        [TestMethod]
        public void Constructor_Test()
        {
            var plane = new Plane(1, 2, 3, 4);

            Assert.AreEqual(plane.A, 1);
            Assert.AreEqual(plane.B, 2);
            Assert.AreEqual(plane.C, 3);
            Assert.AreEqual(plane.D, 4);
        }

        [TestMethod]
        public void from_Storing_Test()
        {
            var plane = Plane.fromABCD(1, 2, 3, 4);

            Assert.AreEqual(plane.A, 1);
            Assert.AreEqual(plane.B, 2);
            Assert.AreEqual(plane.C, 3);
            Assert.AreEqual(plane.D, 4);
        }

        [TestMethod]
        public void from_ABC_Test()
        {
            var plane = Plane.fromABC(0,1,0, Vector3.Zero);

            Assert.AreEqual(plane.A, 0);
            Assert.AreEqual(plane.B, 1);
            Assert.AreEqual(plane.C, 0);
            Assert.AreEqual(plane.D, 0);
        }

        [TestMethod]
        public void from_ABC_Test2()
        {
            var plane = Plane.fromABC(0, 1, 0, Vector3.positiveY);

            Assert.AreEqual(plane.A, 0);
            Assert.AreEqual(plane.B, 1);
            Assert.AreEqual(plane.C, 0);
            Assert.AreEqual(plane.D, -1);
        }

        [TestMethod]
        public void from_Vectors_Test()
        {
            var plane = Plane.fromThreeVectors(Vector3.Zero, Vector3.positiveX, Vector3.positiveY);

            Assert.AreEqual(plane.A, 0);
            Assert.AreEqual(plane.B, 0);
            Assert.AreEqual(plane.C, 1);
            Assert.AreEqual(plane.D, 0);
        }
    }

    [TestClass]
    public class RayTest
    {
        [TestMethod]
        public void Constructor_Test()
        {
            var ray = new Ray(Vector3.Zero, Vector3.One);
            Assert.AreEqual(Vector3.Zero.x, ray.start.x);
            Assert.AreEqual(Vector3.Zero.y, ray.start.y);
            Assert.AreEqual(Vector3.Zero.z, ray.start.z);
            Assert.AreEqual(Vector3.One.x, ray.end.x);
            Assert.AreEqual(Vector3.One.y, ray.end.y);
            Assert.AreEqual(Vector3.One.z, ray.end.z);
        }

        [TestMethod]
        public void Normalize_Test()
        {
            var normalized = new Ray(Vector3.Zero, Vector3.One).normalize();
            Assert.AreEqual(normalized.end.x, (1 / (Math.Sqrt(3))));
            Assert.AreEqual(normalized.end.y, (1 / (Math.Sqrt(3))));
            Assert.AreEqual(normalized.end.z, (1 / (Math.Sqrt(3))));
        }

        [TestMethod]
        public void Direction_member_Test()
        {
            var direction = new Ray(Vector3.Zero, Vector3.One).direction;
            Assert.AreEqual(direction.x, 1);
            Assert.AreEqual(direction.y, 1);
            Assert.AreEqual(direction.z, 1);
        }

        [TestMethod]
        public void Direction_static_Test()
        {
            var direction = Ray.directionM(new Ray(Vector3.Zero, Vector3.One));
            Assert.AreEqual(direction.x, 1);
            Assert.AreEqual(direction.y, 1);
            Assert.AreEqual(direction.z, 1);
        }

        [TestMethod]
        public void Length_member_Test()
        {
            var ray = new Ray(Vector3.Zero, Vector3.positiveX);
            Assert.AreEqual(ray.length(), 1);
        }

        [TestMethod]
        public void Length_static_Test()
        {
            var len = Ray.length(new Ray(Vector3.Zero, Vector3.positiveX));
            Assert.AreEqual(len, 1);
        }

        [TestMethod]
        public void distanceToPlane_Test()
        {
            var ray = new Ray(Vector3.positiveY, Vector3.Zero);
            var distance = ray.distanceToPlane(Plane.fromABCD(0, 1, 0, 0));
            Assert.AreEqual(distance, 1);
        }
    }
    [TestClass]
    public class Vector3Test
    {
        [TestMethod]
        public void ConstructorXYZ_Function()
        {
            var vector3 = new Vector3(3, 4, 5);
            Assert.AreEqual(3, vector3.x);
            Assert.AreEqual(4, vector3.y);
            Assert.AreEqual(5, vector3.z);
        }

        [TestMethod]
        public void ConstructorRGB_Function()
        {
            var vector3 = new Vector3(3, 4, 5);
            Assert.AreEqual(3, vector3.r);
            Assert.AreEqual(4, vector3.g);
            Assert.AreEqual(5, vector3.b);
        }

        [TestMethod]
        public void Clone_Function()
        {
            var vector3 = new Vector3(3, 4, 5);
            var vector = vector3.clone();
            Assert.AreEqual(3, vector3.x);
            Assert.AreEqual(4, vector3.y);
            Assert.AreEqual(5, vector3.z);

            Assert.AreEqual(3, vector.x);
            Assert.AreEqual(4, vector.y);
            Assert.AreEqual(5, vector.z);

            vector.v[0] = 6; // x value
            vector.v[1] = 7; // y value
            vector.v[2] = 10; // z value

            Assert.AreEqual(3, vector3.x);
            Assert.AreEqual(4, vector3.y);
            Assert.AreEqual(5, vector3.z);

            Assert.AreEqual(6, vector.x);
            Assert.AreEqual(7, vector.y);
            Assert.AreEqual(10, vector.z);
        }

        [TestMethod]
        public void CloneRGB_Function()
        {
            var vector3 = new Vector3(3, 4, 5);
            Assert.AreEqual(3, vector3.r);
            Assert.AreEqual(4, vector3.g);
            Assert.AreEqual(5, vector3.b);
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
            Vector3.normalize(vector3);
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

        [TestMethod]
        public void Minus_mutator_Function()
        {
            var v3 = Vector3.One;
            v3.minus(new Vector3(.5, .4, .3));
            Assert.AreEqual(.5, v3.x);
            Assert.AreEqual(.6, v3.y);
            Assert.AreEqual(.7, v3.z);
        }

        [TestMethod]
        public void Minus_static_Function()
        {
            Vector3 v3 = Vector3.minus(Vector3.One, new Vector3(.5, .4, .3));
            Assert.AreEqual(.5, v3.x);
            Assert.AreEqual(.6, v3.y);
            Assert.AreEqual(.7, v3.z);
        }

        [TestMethod]
        public void Add_mutator_Test()
        {
            var v3 = Vector3.One;
            v3.add(new Vector3(.5, .4, .3));
            Assert.AreEqual(1.5, v3.x);
            Assert.AreEqual(1.4, v3.y);
            Assert.AreEqual(1.3, v3.z);
        }

        [TestMethod]
        public void Add_static_Test()
        {
            Vector3 v3 = Vector3.add(Vector3.One, new Vector3(.5, .4, .3));
            Assert.AreEqual(1.5, v3.x);
            Assert.AreEqual(1.4, v3.y);
            Assert.AreEqual(1.3, v3.z);
        }

        [TestMethod]
        public void Dot_method_Test()
        {
            var vectorOne = new Vector3(3, 4, 5);
            var vectorTwo = new Vector3(1, 2, -10);
            var dotOne = vectorOne.dot(vectorTwo);
            var dotTwo = vectorTwo.dot(vectorOne);
            Assert.AreEqual(-39, dotOne);
            Assert.AreEqual(-39, dotTwo);
        }

        [TestMethod]
        public void Dot_static_Test()
        {
            var vectorOne = new Vector3(3, 4, 5);
            var vectorTwo = new Vector3(1, 2, -10);
            var dotOne = Vector3.dot(vectorOne, vectorTwo);
            var dotTwo = Vector3.dot(vectorTwo, vectorOne);
            Assert.AreEqual(-39, dotOne);
            Assert.AreEqual(-39, dotTwo);
        }

        [TestMethod]
        public void CrossMutatorMethod_1_Test()
        {
            var vectorOne = Vector3.positiveX;
            var vectorTwo = Vector3.positiveY;
            var crossOne = vectorOne.cross(vectorTwo);
            Assert.AreEqual(Vector3.positiveZ.x, crossOne.x);
            Assert.AreEqual(Vector3.positiveZ.y, crossOne.y);
            Assert.AreEqual(Vector3.positiveZ.z, crossOne.z);

            vectorOne = Vector3.positiveX;
            var crossTwo = vectorTwo.cross(vectorOne);
            Assert.AreEqual(Vector3.negativeZ.x, crossTwo.x);
            Assert.AreEqual(Vector3.negativeZ.y, crossTwo.y);
            Assert.AreEqual(Vector3.negativeZ.z, crossTwo.z);
        }

        [TestMethod]
        public void CrossMutatorMethod_2_Test()
        {
            var vectorOne = new Vector3(3, 4, 5);
            var vectorTwo = new Vector3(6, 7, -10);
            var crossOne = vectorOne.cross(vectorTwo);
            Assert.AreEqual(new Vector3(-75, 60, -3).x, crossOne.x);
            Assert.AreEqual(new Vector3(-75, 60, -3).y, crossOne.y);
            Assert.AreEqual(new Vector3(-75, 60, -3).z, crossOne.z);
        }

        [TestMethod]
        public void CrossMethod_1_Test()
        {
            var vectorOne = Vector3.positiveX;
            var vectorTwo = Vector3.positiveY;
            var crossOne = vectorOne.cross(vectorTwo);
            Assert.AreEqual(Vector3.positiveZ.x, crossOne.x);
            Assert.AreEqual(Vector3.positiveZ.y, crossOne.y);
            Assert.AreEqual(Vector3.positiveZ.z, crossOne.z);
        }

        [TestMethod]
        public void CrossMethod_2_Test()
        {
            var vectorOne = Vector3.positiveX;
            var vectorTwo = Vector3.positiveY;
            var crossOne = vectorTwo.cross(vectorOne);
            Assert.AreEqual(Vector3.negativeZ.x, crossOne.x);
            Assert.AreEqual(Vector3.negativeZ.y, crossOne.y);
            Assert.AreEqual(Vector3.negativeZ.z, crossOne.z);
        }
    }
}

