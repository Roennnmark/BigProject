using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class BirthDatesEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string BirthYear { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string BirthMonth { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(5)")]
    public string BirthDay { get; set;} = null!;
    public virtual ICollection<FootballPlayersEntity> FootballPlayers { get; set; } = new HashSet<FootballPlayersEntity>();
}
