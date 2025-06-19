using Newtonsoft.Json;

namespace SherDash.Services;

public class JsonDataService<T>
{
    private readonly string _filePath;

    public JsonDataService(string fileName)
    {
        _filePath = Path.Combine(AppContext.BaseDirectory, "Data", fileName);
        if (!File.Exists(_filePath))
            File.WriteAllText(_filePath, "[]");
    }

    public List<T> LoadData()
    {
        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<T>>(json);
    }

    public int GetNextId(List<T> data)
    {
        var prop = typeof(T).GetProperty("Id");
        if (prop == null) {}

        var ids = data.Select(d => (int)prop.GetValue(d)).ToList();
        return ids.Count == 0 ? 1 : ids.Max() + 1;
    }

    public void SaveData(List<T> data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}