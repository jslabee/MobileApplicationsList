using System.Linq.Expressions;
using MobileApplicationsList.repository.DbModel;
using MobileApplicationsList.Services.ApiModel;

namespace MobileApplicationsList.Services
{
    public interface IApplicationService
    {
        Task<string> AddApplicationAsync(CreateApplicationRequest application);
        Task<PageParameters<IApplicationDetailsResponse>> GetAllApplications(int pageNumber, int pageSize);
 
    }
}


