using System;

namespace EventPlannerAPI.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
    public string About { get; set; }
    public decimal Rating { get; set; }
    public string Tier { get; set; }
    public string Contact { get; set; }
    public int Capacity { get; set; }
    public string Address { get; set; }
}
