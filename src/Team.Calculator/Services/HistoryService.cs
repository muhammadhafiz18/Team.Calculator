using System.Text.Json;
using Team.Calculator.Interfaces;
using Team.Calculator.Models;
using Team.Calculator.Services;

namespace Team.Calculator.Services;
public class HistoryService : IHistoryService
{
    public void ClearHistory(List<HistoryItem> history)
    {

        var displayService = new DisplayService();

        if (history.Count == 0)
            Console.WriteLine("nothing to clear");

        else
        {
            while (true)
            {
                displayService.PrintHistory(history);

                string input = displayService.ReadInput("'all' for full clearing / cancel / id for deleting single element");

                if (input == "all")
                {
                    history.Clear();
                    SaveHistory("history.json", history);

                    Console.WriteLine("History has cleared");
                    break;
                }

                else if (input == "cancel")
                {
                    Console.Clear();
                    return;
                }

                else if(int.TryParse(input, out int id))
                {
                    for(int i = 0; i < history.Count; i++)
                    {
                        if(history[i].Id == id)
                        {
                            Console.WriteLine($"{history[i]} has removed");
                            history.RemoveAt(i);
                            SaveHistory("history.json", history);
                        }
                    }
                }
            

            }
        }
    }

    public void LoadHistory(string path, List<HistoryItem> history)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("not found: " + path);
        }
        else
        {
            var json = File.ReadAllText(path);
            var loadedHistory = JsonSerializer.Deserialize<List<HistoryItem>>(json);

            if (loadedHistory != null)
            {
                history.AddRange(loadedHistory);
                Console.WriteLine("load history: " + history.Count);
            }

            else
                Console.WriteLine($"History {history.Count} is empty");
        }
    }

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

    public void ShowHistory(List<HistoryItem> history)
    {
        var displayService = new DisplayService();

        if (history.Count == 0)
            Console.WriteLine("HIstory is empty");

        else
            displayService.PrintHistory(history);
    }
}