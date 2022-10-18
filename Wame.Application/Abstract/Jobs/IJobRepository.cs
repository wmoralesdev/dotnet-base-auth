using Wame.Domain.Entities.Jobs;

namespace Wame.Application.Abstract.Jobs;

public interface IJobRepository
{
    Task<Job?> GetJobById(int jobId);
}