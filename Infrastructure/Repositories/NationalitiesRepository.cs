using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class NationalitiesRepository(DataContext context) : BaseRepository<NationalitiesEntity>(context)
{
    private readonly DataContext _dataContext = context;
}
