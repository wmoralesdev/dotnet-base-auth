using AutoMapper;
using Wame.Application.Exceptions;
using Wame.Application.Implementation.Campaigns;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Candidates;

public class CandidateService
{
    private readonly CandidateRepository _candidateRepo;
    private readonly CampaignRepository _campaignRepo;
    private readonly IMapper _mapper;

    public CandidateService(CandidateRepository candidateRepo, IMapper mapper, CampaignRepository campaignRepo)
    {
        _candidateRepo = candidateRepo;
        _mapper = mapper;
        _campaignRepo = campaignRepo;
    }

    public async Task<CandidateVm> CreateCandidate(Guid invitationId, CandidateVm vm)
    {
        var campaign = await _campaignRepo.FindByInvitationId(invitationId);

        if (campaign is null) throw new NotFoundException("Campaign not found");
        
        var candidate = await _candidateRepo.Create(_mapper.Map<Candidate>(vm));
        
        return _mapper.Map<CandidateVm>(candidate);
    }
}