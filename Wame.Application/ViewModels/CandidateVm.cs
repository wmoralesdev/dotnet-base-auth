namespace Wame.Application.ViewModels;

public class CandidateVm : BaseIdentityVm
{
    public int Age { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Experience { get; set; }
    
    public string? Formation { get; set; }
    
    public string? Aptitudes { get; set; }
}