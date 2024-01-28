using System;
using System.Text.Json;
using System.IO;

public class JsonSerialisationUtils
{
    public static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static void ToFile(string filePath, string jsonString)
    {
        File.WriteAllText(filePath, jsonString);
    }
}