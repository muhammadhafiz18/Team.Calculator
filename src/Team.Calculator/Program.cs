using Team.Calculator.Services;
using Team.Calculator.Models;

var historyService = new HistoryService();
var calculateService = new CalculateService();

Console.WriteLine("Welcome to Calculator!");

List<HistoryItem> history = [];

string filePath = "history.json";

historyService.LoadHistory(filePath, history);

Console.WriteLine("program cs" + history.Count);

while (true)
{
    Console.WriteLine("availabe commands: calculate, history, clear, exit, cls");

    var input = Console.ReadLine()!.Trim().ToLower(); 

    if (input == "exit")
        break;

    else if (input == "cls")
        Console.Clear();

    else if (input == "history") 
        historyService.ShowHistory(history);

    else if (input == "clear")
        historyService.ClearHistory(history);
    
    else if (input == "calculate")
        calculateService.Calculate(history);

    else
        Console.WriteLine("This command is not available");
}
Console.WriteLine("Good bye");
