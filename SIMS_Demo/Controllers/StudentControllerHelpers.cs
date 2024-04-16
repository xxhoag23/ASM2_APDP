using SIMS_Demo.Models;
using System.Text.Json;

internal static class StudentControllerHelpers
{
    private static string filePath = "students.json";

    public static List<Student>? ReadStudentsFromFile()
    {
        try
        {
            string readText = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(readText);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it according to your needs
            return new List<Student>();
        }
    }

    public static void WriteStudentsToFile(List<Student> students)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(students, options);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonString);
        }
    }
}
