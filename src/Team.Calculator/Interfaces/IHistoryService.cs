using Team.Calculator.Models;

namespace Team.Calculator.Interfaces;
public interface IHistoryService
{
    void ShowHistory(List<HistoryItem> history);
    void ClearHistory(List<HistoryItem> history);
    void SaveHistory(string path, List<HistoryItem> history);
    void LoadHistory(string path, List<HistoryItem> history);
}
