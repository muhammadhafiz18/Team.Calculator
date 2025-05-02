namespace Team.Calculator.Models;
public class HistoryItem
{
    public int Id { get; set; }
    public string? Expression { get; set; } // "9 + 3 * (6 + 3)";
    public double Result { get; set; } 
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"{Expression} = {Result}";
    }
}