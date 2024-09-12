namespace EventPlannerAPI.Models;

public class Expense
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal Cost { get; set; }
    public string? Notes { get; set; }
}
