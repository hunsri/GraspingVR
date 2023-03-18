using UnityEngine;

public static class TransformationAnalyser
{
    public static void Analyse(Transform grabbable, Transform destination)
    {
        Debug.Log(grabbable.position.ToString("f3") + " | " + destination.position.ToString("f3"));
        Debug.Log(grabbable.rotation.ToString("f3") + " | " + destination.rotation.ToString("f3"));

        float posD = PositionDeviation(grabbable.transform.position, destination.transform.position);
        //Vector3 rotD = RotationDeviation(grabbable.transform.rotation, destination.transform.rotation);
        float rotD = RotationDeviation(grabbable.transform.rotation, destination.transform.rotation);

        ResultExporter.Export(grabbable.transform.position, grabbable.transform.rotation.eulerAngles, posD, rotD);
    }

    public static Vector3 PositionValues(Vector3 grabbablePosition)
    {
        return grabbablePosition;
    }

    public static float PositionDeviation(Vector3 grabbablePosition, Vector3 destinationPosition)
    {
        float ret = Vector3.Distance(grabbablePosition, destinationPosition);

        return ret;
    }


    public static Vector3 RotationValues(Quaternion grabbableRotation)
    {
        return grabbableRotation.eulerAngles;
    }
    
    public static float RotationDeviation(Quaternion grabbableRotation, Quaternion destinationRotation)
    {
        return Quaternion.Angle(grabbableRotation, destinationRotation);
    }

}
