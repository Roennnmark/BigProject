namespace Infrastructure.Dtos;

public class FootballPlayerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CurrentClub { get; set; } = null!;
    public string FirstClub { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public string City { get; set; } = null!;
    public string BirthYear { get; set; } = null!;
    public string BirthMonth { get; set; } = null!;
    public string BirthDay { get; set; } = null!;
}
