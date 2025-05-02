using Team.Calculator.Models;

namespace Team.Calculator.Interfaces;
public interface IDisplayService
{
    void PrintHistory(List<HistoryItem> history);
}
