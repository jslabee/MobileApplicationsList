using MobileApplicationsList.repository;
using System.Linq.Expressions;
using MobileApplicationsList.repository.DbModel;
using MobileApplicationsList.Services.ApiModel;

namespace MobileApplicationsList.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly IApplicationbaseRepository _applicationDetailsRepository;

        private readonly IApplicationServiceMapper _applicationServiceMapper;

        public ApplicationService(IApplicationbaseRepository applicationRepository, IApplicationServiceMapper applicationServiceMapper)
        {
            _applicationDetailsRepository = applicationRepository;
            _applicationServiceMapper = applicationServiceMapper;
        }

        public async Task<PageParameters<IApplicationDetailsResponse>> GetAllApplications(int pageNumber, int pageSize)
        {
            var totalCount = await _applicationDetailsRepository.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var applications = await _applicationDetailsRepository.ListAllPaginatedAsync(pageNumber, pageSize);

            List<IApplicationDetailsResponse> applicationDetailsList = await _applicationServiceMapper.MapApplicationDetails(applications);

            var pageResult = new PageParameters<IApplicationDetailsResponse>();

            pageResult.maxpages = totalPages;
            pageResult.PageNumber = pageNumber;
            pageResult.PageSize = pageSize;
            pageResult.Items = applicationDetailsList;

            return pageResult;

        }

        public async Task<string> AddApplicationAsync(CreateApplicationRequest application)
        {
            ApplicationBase aplicationBase = await _applicationServiceMapper.MapCreateAppRequest(application);


            await _applicationDetailsRepository.AddAsync(aplicationBase);

            if (aplicationBase.Id != 0)

            {
                return $"Application created Id: {aplicationBase.Id}";
            }
            else
            {
                return "Error saving application";
            }
        }

    }
}
