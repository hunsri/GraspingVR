using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class AnalysationTests
    {
        private static string _resolution = "f4";
        
        private static float _floatPrecision = 1e-2f;

        [Test]
        public void DistanceUp()
        {
            Vector3 zero = Vector3.zero;
            Vector3 up = Vector3.up;

            float observed = TransformationAnalyser.PositionDeviation(zero, up);

            Assert.AreEqual(1.0f, observed);
        }

        [Test]
        public void DistanceOne()
        {
            Vector3 zero = Vector3.zero;
            Vector3 one = Vector3.one;

            float observed = TransformationAnalyser.PositionDeviation(zero, one);

            Assert.AreEqual(Mathf.Sqrt(3), observed);
        }

        [Test]
        public void RotationX()
        {
            float rotX = 42.123f;

            float expected = rotX;

            Quaternion zero = Quaternion.Euler(0f, 0f, 0f);;
            
            Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.AreEqual(expected.ToString(_resolution), observed.ToString(_resolution));
        }

        [Test]
        public void RotationOverflowX()
        {
            float rotX = 180.0001f;
            
            //max expected value is 180, so value needs to be subtracted from full rotation 
            float expected = 360f - rotX;

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.AreEqual(expected.ToString(_resolution), observed.ToString(_resolution));
        }

        [Test]
        public void RotationNegX()
        {
            float rotX = -42.123f;

            float expected = System.Math.Abs(rotX);

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.AreEqual(expected.ToString(_resolution), observed.ToString(_resolution));
        }

        [Test]
        public void RotationOverflowNegX()
        {
            float rotX = -180.0001f;
            
            //max expected value is 180, so value needs to be subtracted from full rotation 
            float expected = 360f - System.Math.Abs(rotX);

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.AreEqual(expected.ToString(_resolution), observed.ToString(_resolution));
        }

        [Test]
        public void RotationLowY()
        {
            float rotX = -920.12f;

            //max expected value is 180, so value needs to be subtracted from full rotation
            float expected = System.Math.Abs(360f - System.Math.Abs(rotX%360));

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.AreEqual(expected.ToString(_resolution), observed.ToString(_resolution));
        }

        [Test]
        public void RotationXY()
        {
            float rotX = 4f;
            float rotY = 20f;

            float expected = (float) System.Math.Sqrt(System.Math.Pow(rotX,2) + System.Math.Pow(rotY,2));

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, rotY, 0f);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Assert.IsTrue(Mathf.Abs(expected - observed) < _floatPrecision);
        }

        [Test]
        public void RotationXYZ()
        {
            float rotX = 124.4212f;
            float rotY = -251.2134f;
            float rotZ = -48.1112f;

            Quaternion zero = Quaternion.identity;
            
            Quaternion rotated = Quaternion.Euler(rotX, rotY, rotZ);

            float expected = Quaternion.Angle((Quaternion.Inverse(zero) * rotated), Quaternion.identity);

            float observed = TransformationAnalyser.RotationDeviation(rotated, zero);

            Debug.Log(expected + "|" + observed);
            Assert.IsTrue(Mathf.Abs(expected - observed) < _floatPrecision);
        }
    }
}
