using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Domain.Entities.Users;

public class Candidate : BaseIdentity
{
    public Campaign? Campaign { get; set; }
}