using System.IO;
using UnityEngine;

public static class ResultExporter
{
    private static string _resolution = "f3";

    private static string _filePath = Application.persistentDataPath + "/test.csv";

    public static void Export(Vector3 position, Vector3 rotation, float positionDelta, float rotationDelta)
    {
        Debug.Log("attempt to write to:" + _filePath);
        string csv = "";
        
        csv += VectorToCSVLine(position);
        csv += VectorToCSVLine(rotation);
        csv += "; ";
        csv += positionDelta.ToString(_resolution) + "; ";
        csv += rotationDelta.ToString(_resolution);

        WriteToFile(csv);
    }

    private static string VectorToCSVLine(Vector3 vec3)
    {
        string ret = "";

        ret += vec3.x.ToString(_resolution) + "; ";
        ret += vec3.y.ToString(_resolution) + "; ";
        ret += vec3.z.ToString(_resolution) + "; ";

        return ret;
    }

    private static void WriteToFile(string csvLine)
    {
        using(StreamWriter sw = File.AppendText(_filePath))
        {
            sw.WriteLine(csvLine);
        }
    }
}