using Microsoft.EntityFrameworkCore;
using MobileApplicationsList.repository.DbModel;

namespace MobileApplicationsList.repository
{

    public class ApplicationBaseRepository : BaseRepository<ApplicationBase>, IApplicationbaseRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public async Task<List<AplicationDetails>> ListAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _context.aplicationdetails
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }

    }

