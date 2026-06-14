using System.Text.Json;

namespace StudentPortal.Helpers
{
    public static class FileUtil
    {
        private static readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
        public static List<T> ReadFromFile<T>(string fileName)
        {
            var filePath = Path.Combine(_path, fileName);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<T>();
            }

            var content = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(content))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(content)
                ?? new List<T>();
        }

        public static void SaveToFile<T>(List<T> items, string fileName)
        {
            var filePath = Path.Combine(_path, fileName);

            var json = JsonSerializer.Serialize(items,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}