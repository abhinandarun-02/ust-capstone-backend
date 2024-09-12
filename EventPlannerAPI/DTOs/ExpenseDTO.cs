using System;

namespace EventPlannerAPI.DTOs;

public class ExpenseDTO
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public required string Name { get; set; }
    public decimal Cost { get; set; }
}
