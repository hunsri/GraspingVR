using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationAnalyser : MonoBehaviour
{
    public static void Analyse(Transform grabbable, Transform destination)
    {
        Debug.Log(grabbable.position.ToString("f3") + " | " + destination.position.ToString("f3"));
        Debug.Log(grabbable.rotation.ToString("f3") + " | " + destination.rotation.ToString("f3"));
    }
}
