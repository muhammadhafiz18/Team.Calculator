using System.Text.Json;
public class HistoryService
{
    public void SaveHistory(string path, List<HistoryItem> history)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(history, options);

        File.WriteAllText(path, json);
    }
}