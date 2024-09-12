namespace EventPlannerAPI.Models;

public class Expense
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public required string Name { get; set; }
    public decimal Cost { get; set; }
}
