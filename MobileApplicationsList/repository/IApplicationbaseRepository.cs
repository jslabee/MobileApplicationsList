using MobileApplicationsList.repository.DbModel;

namespace MobileApplicationsList.repository
{
    public interface IApplicationbaseRepository : IAsyncRepository<ApplicationBase>
    {
        Task<List<AplicationDetails>> ListAllPaginatedAsync(int pageNumber, int pageSize);
    }

    }

