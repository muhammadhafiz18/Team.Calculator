using System.Text.Json;
using Team.Calculator.Interfaces;
using Team.Calculator.Models;
using Team.Calculator.Services;

namespace Team.Calculator.Services;

public class HistoryService : IHistoryService
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