namespace Wame.Application.ViewModels;

public class FilledInviteVm
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public int Age { get; set; }
    
    public string? Phone { get; set; }
    
    public IList<string>? Experience { get; set; }
    
    public IList<string>? Formation { get; set; }
    
    public IList<string>? Aptitudes { get; set; }
}