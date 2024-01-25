using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class PositionsRepository(DataContext context) : BaseRepository<PositionsEntity>(context)
{
    private readonly DataContext _context = context;
}
