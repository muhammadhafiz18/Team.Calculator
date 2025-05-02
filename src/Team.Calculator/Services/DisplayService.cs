public class DisplayService : IDisplayService
{
    public void PrintHistory(List<HistoryItem> historyItems)
    {
        for (int i = 0; i < historyItems.Count; i++)
            Console.WriteLine($"({historyItems[i].Id}). {historyItems[i]} | {historyItems[i].CreatedAt:HH:mm:ss}");
    }

    public string ReadInput(string message)
    {
        Console.WriteLine($"{message}");
        return Console.ReadLine()!.Trim().ToLower();
    }
}