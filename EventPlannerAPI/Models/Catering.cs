using System;

namespace EventPlannerAPI.Models;

public class Catering
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Location { get; set; }
    public required string About { get; set; }
    public decimal Rating { get; set; }
    public required string Tier { get; set; }
    public required string Contact { get; set; }
    public required string MenuDetails { get; set; }
}
