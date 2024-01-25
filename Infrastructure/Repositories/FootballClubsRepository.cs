using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class FootballClubsRepository(DataContext context) : BaseRepository<FootballClubsEntity>(context)
{
    private readonly DataContext _dataContext = context;


}
