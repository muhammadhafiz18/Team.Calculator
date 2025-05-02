using Team.Calculator.Models;

namespace Team.Calculator.Interfaces;
public interface ICalculateService
{
    void Calculate(List<HistoryItem> history);
}