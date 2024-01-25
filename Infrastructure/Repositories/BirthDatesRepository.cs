using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class BirthDatesRepository(DataContext context) : BaseRepository<BirthDatesEntity>(context)
{
    private readonly DataContext _context = context;
}
