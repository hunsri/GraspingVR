using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AnalysationTests
    {
        private static string _resolution = "f3";

        [Test]
        public void DistanceUp()
        {
            Vector3 zero = Vector3.zero;
            Vector3 up = Vector3.up;

            float val = TransformationAnalyser.PositionDeviation(zero, up);

            Assert.AreEqual(1.0f, val);
        }

        [Test]
        public void DistanceOne()
        {
            Vector3 zero = Vector3.zero;
            Vector3 one = Vector3.one;

            float val = TransformationAnalyser.PositionDeviation(zero, one);

            Assert.AreEqual(Mathf.Sqrt(3), val);
        }

        // [Test]
        // public void RotationX()
        // {
        //     float rotX = 9.123412f;

        //     Quaternion zero = Quaternion.Euler(0f, 0f, 0f);;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(rotX, 0, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationBorderX()
        // {
        //     float rotX = 45.00f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(rotX, 0, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationNegX()
        // {
        //     float rotX = -9.123412f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(-rotX, 0, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationHighX()
        // {
        //     float rotX = 271.02f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(1.02f, 0, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationLowY()
        // {
        //     float rotX = -309.12f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, 0f, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(39.12f, 0, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationXY()
        // {
        //     float rotX = 22.245f;
        //     float rotY = 2.123412f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, rotY, 0f);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(rotX, rotY, 0).ToString(_resolution), val.ToString(_resolution));
        // }

        // [Test]
        // public void RotationXYZ()
        // {
        //     float rotX = 124.4212f;
        //     float rotY = -251.2134f;
        //     float rotZ = -48.1112f;

        //     Quaternion zero = Quaternion.identity;
            
        //     Quaternion rotated = Quaternion.Euler(rotX, rotY, rotZ);

        //     Vector3 val = TransformationAnalyser.RotationDeviation(rotated, zero);

        //     Assert.AreEqual(new Vector3(34.4212f, 18.7866f, 41.889f).ToString(_resolution), val.ToString(_resolution));
        // }
    }
}
