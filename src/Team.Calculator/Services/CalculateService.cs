using System.Data;
using Team.Calculator.Interfaces;
using Team.Calculator.Models;
using Team.Calculator.Services;


namespace Team.Calculator.Services;

public class CalculateService : ICalculateService
{
    public void Calculate(List<HistoryItem> history)
    {
        var historyService = new HistoryService();

        string expression = "";
        
        while (true)
        {
            try
            {
                Console.Write("Enter expression or cancel: ");
    
                expression = Console.ReadLine()!.Trim().ToLower();
    
                if (string.IsNullOrEmpty(expression))
                {
                    Console.WriteLine("Expression cannot be");
                    continue;
                }
                else if (expression == "cancel")
                {
                    return;
                } 
                // faoilsdjkalsdkjf
                // 9 + 3
                var dataTable = new DataTable();

                double result = Convert.ToDouble(dataTable.Compute(expression, null));

                int id = 1;

                if(history.Count != 0)
                {
                    id = history.Last().Id + 1;
                }

                var historyItem = new HistoryItem
                {
                    Id = id,
                    Expression = expression,
                    Result = result,
                    CreatedAt = DateTime.Now
                };

                history.Add(historyItem);
                historyService.SaveHistory("history.json", history);
                Console.WriteLine($"{expression} = {result}");
                break;
            }
            catch(Exception ex)  
            { 
                Console.WriteLine($"Error: couldn't compute this expression, error: {ex.Message}"); 
            }
        }
    }
}