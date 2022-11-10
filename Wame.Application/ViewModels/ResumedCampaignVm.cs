namespace Wame.Application.ViewModels;

public class ResumedCampaignVm
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }

    public JobVm? Position { get; set; }
    
    public bool IsActive { get; set; }

    public Guid? InvitationId { get; set; }
}