using System.IO;
using UnityEngine;
using System.Globalization;

public static class ResultExporter
{
    private static string _resolution = "f4";
    private static CultureInfo _numberFormat = new CultureInfo("en-US");

    private static string _filePath = Application.persistentDataPath + "/TestData.csv";

    public static void Export(Vector3 position, Vector3 rotation, float positionDelta, float rotationDelta)
    {
        Debug.Log("attempt to write to:" + _filePath);
        string csv = "";
        
        csv += VectorToCSVLine(position);
        csv += VectorToCSVLine(rotation);
        csv += "; ";
        csv += positionDelta.ToString(_resolution, _numberFormat) + "; ";
        csv += rotationDelta.ToString(_resolution, _numberFormat);

        WriteToFile(csv);
    }

    private static string VectorToCSVLine(Vector3 vec3)
    {
        string ret = "";

        ret += vec3.x.ToString(_resolution, _numberFormat) + "; ";
        ret += vec3.y.ToString(_resolution, _numberFormat) + "; ";
        ret += vec3.z.ToString(_resolution, _numberFormat) + "; ";

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