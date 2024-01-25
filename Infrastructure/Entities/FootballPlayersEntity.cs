using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

[Index(nameof(Email), IsUnique = true)]
public class FootballPlayersEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string FirstName { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string LastName { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;
    [Required]
    [ForeignKey(nameof(FootballClubsEntity))]
    public int FootballClubId { get; set; }
    public virtual FootballClubsEntity FootballClub { get; set; } = null!;  
    [Required]
    [ForeignKey(nameof(NationalitiesEntity))]
    public int NationalitiesId { get; set; }
    public virtual NationalitiesEntity Nationalities { get; set; } = null!;
    [Required]
    [ForeignKey(nameof(BirthDatesEntity))]
    public int BirthDatesId { get; set; }
    public virtual BirthDatesEntity BirthDates { get; set; } = null!;
    [Required]
    [ForeignKey(nameof(PositionsEntity))]
    public int PositionsId { get; set;}
    public virtual PositionsEntity Positions { get; set; } = null!;

}
