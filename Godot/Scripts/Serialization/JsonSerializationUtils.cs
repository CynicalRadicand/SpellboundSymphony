using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Godot;
using FileAccess = Godot.FileAccess; // To avoid confusion with System.IO.FileAccess

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

    public static bool IsValidatedJson(string jsonText, List<string> requiredFields)
    {
        // Deserialize JSON to a JsonDocument
        using JsonDocument doc = JsonDocument.Parse(jsonText);

        // Get the root element
        JsonElement root = doc.RootElement;

        // Check if the required fields are present
        foreach (string field in requiredFields)
        {
            if (!root.TryGetProperty(field, out _))
            {
                throw new Exception($"Field '{field}' is missing in the JSON file.");
            }
        }
        return true;
    }
    public static T Deserialize<T>(string filename, List<string> requiredFields)
    {
        GD.Print($"Deserializing from {filename}");

        // Read the JSON file into a string
        string jsonText = GetFileAsString(filename);

        GD.Print(jsonText);
        try
        {
            IsValidatedJson(jsonText, requiredFields);
            return JsonSerializer.Deserialize<T>(jsonText);
        }
        catch
        {
            GD.PrintErr($"Error in parsing JSON file: {filename}");
            throw;
        }
    }

    /// <summary>
    /// File path can use Godot special paths, such as "res" and "user"
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private static string GetFileAsString(string filePath)
    {
        // Note: must use Godot specific access (FileAccess) to utilise "res://" path
        FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);

        if (file == null)
        {
            GD.PrintErr("Cannot find info config file: " + filePath);
            return null;
        }

        string jsonString = file.GetAsText();
        file.Close();

        return jsonString;
    }
}