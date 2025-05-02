using Team.Calculator.Models;

namespace Team.Calculator.Interfaces;

public interface IHistoryService
{
    void SaveHistory(string path, List<HistoryItem> history);
}
