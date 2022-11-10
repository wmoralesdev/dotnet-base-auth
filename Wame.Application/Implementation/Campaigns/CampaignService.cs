using AutoMapper;
using Wame.Application.Exceptions;
using Wame.Application.Implementation.Recruiters;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Application.Implementation.Campaigns;

public class CampaignService
{
    private readonly RecruiterRepository _recruiterRepo;
    private readonly CampaignRepository _campaignRepo;
    private readonly IMapper _mapper;

    public CampaignService(RecruiterRepository recruiterRepo, CampaignRepository campaignRepo, IMapper mapper)
    {
        _recruiterRepo = recruiterRepo;
        _campaignRepo = campaignRepo;
        _mapper = mapper;
    }

    public async Task<CampaignVm> CreateCampaign(string email, NewCampaignVm vm)
    {
        var recruiter = await _recruiterRepo.FindByEmail(email);

        if (recruiter is null) throw new NotFoundException("Recruiter not found");

        var campaign = await _campaignRepo.Create(_mapper.Map<Campaign>(vm), recruiter);

        return _mapper.Map<CampaignVm>(campaign);
    }

    public async Task<IList<CampaignVm>> GetCampaigns(string email)
    {
        return _mapper.Map<IList<CampaignVm>>(await _campaignRepo.GetCampaigns(email));
    }
}