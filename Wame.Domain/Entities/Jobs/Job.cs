namespace Wame.Domain.Entities.Jobs;

public class Job
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Responsibilities { get; set; }
}