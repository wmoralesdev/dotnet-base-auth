using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Interviews;

namespace Wame.Application.Implementation.Interviews;

public class InterviewService
{
    private readonly InterviewRepository _repository;
    private readonly IMapper _mapper;

    public InterviewService(InterviewRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InterviewVm> CreateInterview(string recruiterEmail, CreateInterviewVm vm)
    {
        return _mapper.Map<InterviewVm>(
            await _repository.Create(vm.CandidateEmail!, recruiterEmail, vm.CampaignId!.Value)
        );
    }

    public async Task<InterviewVm> CompleteInterview(InterviewVm vm)
    {
        var interview = _mapper.Map<Interview>(vm);

        return _mapper.Map<InterviewVm>(
            await _repository.CompleteInterview(interview)
        );
    }

    public async Task<InterviewVm> GetInterview(int id)
    {
        return _mapper.Map<InterviewVm>(
            await _repository.GetInterview(id)
        );
    }

    public async Task<IList<InterviewVm>> GetCandidateInterviews(string email)
    {
        return _mapper.Map<IList<InterviewVm>>(await _repository.GetCandidateInterviews(email));
    }
}