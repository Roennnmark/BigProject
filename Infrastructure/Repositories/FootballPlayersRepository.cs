using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class FootballPlayersRepository(DataContext context) : BaseRepository<FootballPlayersEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<FootballPlayersEntity> GetAll()
    {
        try
        {
            return _context.FootballPlayers
                .Include(x => x.FootballClub)
                .Include(x => x.Nationalities)
                .Include(x => x.Positions)
                .Include(x => x.BirthDates)
                .ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public override FootballPlayersEntity GetOne(Expression<Func<FootballPlayersEntity, bool>> predicate)
    {
        try
        {
            return _context.FootballPlayers
                .Include(x => x.FootballClub)
                .Include(x => x.Nationalities)
                .Include(x => x.Positions)
                .Include(x => x.BirthDates)
                .FirstOrDefault(predicate, null!);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

}
