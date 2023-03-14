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

    // public static Vector3 RotationDeviation(Quaternion grabbableRotation, Quaternion destinationRotation)
    // {
    //     Vector3 ret;
        
    //     // Quaternion q = Quaternion.FromToRotation(grabbableRotation.eulerAngles, destinationRotation.eulerAngles);

    //     // //isolating the rotation values
    //     Quaternion isolatedX = Quaternion.Euler(grabbableRotation.eulerAngles.x, 0, 0);
    //     Quaternion isolatedY = Quaternion.Euler(0, grabbableRotation.eulerAngles.y, 0);
    //     Quaternion isolatedZ = Quaternion.Euler(0, 0, grabbableRotation.eulerAngles.z);


    //     float x = Quaternion.Angle(isolatedX, destinationRotation);
    //     float y = Quaternion.Angle(isolatedY, destinationRotation);
    //     float z = Quaternion.Angle(isolatedZ, destinationRotation);
        
    //     // float x = q.eulerAngles.x;
    //     // float y = q.eulerAngles.y;
    //     // float z = q.eulerAngles.z;
        
    //     x = AdjustedRotationValue(x);
    //     y = AdjustedRotationValue(y);
    //     z = AdjustedRotationValue(z);
        
    //     ret = new Vector3(x, y, z);

    //     return ret;
    // }

    // private static float AdjustedRotationValue(float rotation)
    // {
    //     float ret = rotation;
        
    //     if(ret > 180.0f)
    //     {
    //         ret -= 180.0f;
    //     }

    //     // ret %= 90;
    //     // if(ret >= 45.0f)
    //     // {
    //     //     ret = 90.0f - ret;
    //     // }

    //     return ret;
    // }
}
