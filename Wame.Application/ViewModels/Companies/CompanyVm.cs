using Wame.Application.ViewModels.Users;
using Wame.Domain.Entities.Companies;

namespace Wame.Application.ViewModels.Companies;

public class CompanyVm : Company
{
    public new IList<RecruiterVm>? Employees { get; set; }
}