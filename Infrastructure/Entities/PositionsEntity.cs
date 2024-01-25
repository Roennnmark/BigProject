using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class PositionsEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string Position { get; set; } = null!;
    public virtual ICollection<FootballPlayersEntity> FootballPlayers { get; set; } = new HashSet<FootballPlayersEntity>();
}
