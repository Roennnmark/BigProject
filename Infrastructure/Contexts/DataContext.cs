using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<FootballPlayersEntity> FootballPlayers { get; set; }
    public virtual DbSet<FootballClubsEntity> FootballClubs { get; set; }
    public virtual DbSet<NationalitiesEntity> Nationalities { get; set; }
    public virtual DbSet<BirthDatesEntity> BirthDates { get; set; }
    public virtual DbSet<PositionsEntity> Positions { get; set; }

}
