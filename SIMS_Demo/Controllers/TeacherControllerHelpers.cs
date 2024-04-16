using SIMS_Demo.Models;
using System.Text.Json;

internal static class TeacherControllerHelpers
{
    private static string filePath = "data.json";

    public static List<Teacher>? ReadTeachersFromFile()
    {
        try
        {
            string readText = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Teacher>>(readText);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it according to your needs
            return new List<Teacher>();
        }
    }

    public static void WriteTeachersToFile(List<Teacher> teachers)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(teachers, options);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonString);
        }
    }
}
