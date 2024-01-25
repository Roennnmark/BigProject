using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using System.Diagnostics;

namespace Presentation.ConsoleApp.Services;

public class MenuService(FootballPlayerService playerService)
{
    private readonly FootballPlayerService _playerService = playerService;

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("#####  Football Players Menu  #####");
            Console.WriteLine("\n   1. Add Football Player.");
            Console.WriteLine("   2. View Player List.");
            Console.WriteLine("   3. View Specified Player Details.");
            Console.WriteLine("   4. Update a Player.");
            Console.WriteLine("   5. Delete a Player.");
            Console.WriteLine("   6. Exit Application.");
            Console.Write("\n   Enter A Menu Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddNewPlayer(this);
                    break;
                case "2":
                    ShowAllPlayers(this);
                    break;
                case "3":
                    ShowOnePlayer(this);
                    break;
                case "4":
                    UpdatePlayer(this);
                    break;
                case "5":
                    DeletePlayer(this);
                    break;
                case "6":
                    ShowExitAppOption();
                    break;
                default:
                    Console.WriteLine("\n    Choose a Menu option! ");
                    break;

            }

            Console.ReadKey();
        }
    }
    public static void AddNewPlayer(MenuService menuService)
    {
        Console.Clear();
        Console.WriteLine("\n    Add New Football Player here!");
        var form = new FootballPlayerDto();

        Console.Write("    First Name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("    Last Name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("    E-mail: ");
        form.Email = Console.ReadLine()!;
        Console.Write("    Current club: ");
        form.CurrentClub = Console.ReadLine()!;
        Console.Write("    First club: ");
        form.FirstClub = Console.ReadLine()!;
        Console.Write("    Position: ");
        form.Position = Console.ReadLine()!;
        Console.Write("    Nationality: ");
        form.Nationality = Console.ReadLine()!;
        Console.Write("    City: ");
        form.City = Console.ReadLine()!;
        Console.Write("    Birthyear: ");
        form.BirthYear = Console.ReadLine()!;
        Console.Write("    Birthmonth: ");
        form.BirthMonth = Console.ReadLine()!;
        Console.Write("    Birthday: ");
        form.BirthDay = Console.ReadLine()!;

        menuService._playerService.CreateFootballPlayer(form);
    }

    public static void ShowAllPlayers(MenuService menuService)
    {
        var playerList = menuService._playerService.GetAllPlayers();

        if (playerList != null)
        {
            Console.Clear();
            Console.WriteLine("\n    ---- Player List ----");
            foreach (var player in playerList)
            {
                Console.WriteLine($"    {player.FirstName} {player.LastName}");
                Console.WriteLine($"    {player.Email}");
                Console.WriteLine("    ---------------------");
            }
        }

    }

    public static void ShowOnePlayer(MenuService menuService)
    {
        var players = menuService._playerService.GetAllPlayers();
        Console.Clear();
        Console.Write("\n    Enter the Email of the player to view details: ");
        var email = Console.ReadLine()!;

        var player = players.FirstOrDefault(x => x.Email == email);

        if (player != null)
        {
            Console.Clear();
            Console.WriteLine("\n    ---- Player Details ----");
            Console.WriteLine($"    Name: {player.FirstName} {player.LastName}");
            Console.WriteLine($"    Email: {player.Email}");
            Console.WriteLine($"    Position: {player.Position}");
            Console.WriteLine($"    Nationality: {player.Nationality}");
            Console.WriteLine($"    City: {player.City}");
            Console.WriteLine($"    Birthdate: {player.BirthYear} {player.BirthMonth} {player.BirthDay}");
            Console.WriteLine($"    Current Club: {player.CurrentClub}");
            Console.WriteLine($"    First Club: {player.FirstClub}");
        }
        else
        {
            Console.WriteLine($"    Player not found with email: {email}");
        }
        Console.ReadKey();
    }

    public static void UpdatePlayer(MenuService menuService)
    {
        Console.Clear();
        Console.Write("\n    Enter E-mail of the player you want to update: ");
        var updateEmail = Console.ReadLine()!;

        var footballPlayers = menuService._playerService.GetAllPlayers();

        var playerUpdate = footballPlayers.FirstOrDefault(x => x.Email == updateEmail);
        if (playerUpdate != null)
        {
            Console.Clear();
            var updatedPlayer = new FootballPlayerDto();

            Console.Write("\n    Update First Name: ");
            updatedPlayer.FirstName = Console.ReadLine()!;

            Console.Write("    Update Last Name: ");
            updatedPlayer.LastName = Console.ReadLine()!;

            Console.Write("    Update E-mail: ");
            updatedPlayer.Email = Console.ReadLine()!;

            Console.Write("    Update Current Club: ");
            updatedPlayer.CurrentClub = Console.ReadLine()!;

            Console.Write("    Update First Club: ");
            updatedPlayer.FirstClub = Console.ReadLine()!;

            Console.Write("    Update Position: ");
            updatedPlayer.Position = Console.ReadLine()!;

            Console.Write("    Update Nationality: ");
            updatedPlayer.Nationality = Console.ReadLine()!;

            Console.Write("    Update City: ");
            updatedPlayer.City = Console.ReadLine()!;

            Console.Write("    Update Birth Year: ");
            updatedPlayer.BirthYear = Console.ReadLine()!;

            Console.Write("    Update Birth Month: ");
            updatedPlayer.BirthMonth = Console.ReadLine()!;

            Console.Write("    Update Birth Day: ");
            updatedPlayer.BirthDay = Console.ReadLine()!;

            if (menuService._playerService.UpdatePlayer(updateEmail, updatedPlayer))
            {
                Console.WriteLine($"\n    Player with email '{updateEmail}' has been updated.");
            }
            else
            {
                Console.WriteLine($"\n    Failed to update player with email: {updateEmail}");
            }
        }
        else
        {
            Console.WriteLine("\n    Email does not exist.");
        }
    }



    public static void DeletePlayer(MenuService menuService)
    {
        var players = menuService._playerService.GetAllPlayers();

        Console.Clear();
        Console.Write("\n    Enter the Email of the player you want to delete: ");
        var email = Console.ReadLine()!;
        var player = players.FirstOrDefault(x => x.Email == email);
        if (player != null)
        {
            menuService._playerService.DeleteFootballPlayer(email);
            Console.WriteLine($"\n    Player with email '{email}' has been deleted");
        }
        else
        {
            Console.WriteLine($"\n    Player not found with email: {email}");
        }
        Console.ReadKey();
    }
    public static void ShowExitAppOption()
    {
        Console.Clear();
        Console.Write("\n-   Are you sure? (y/n): ");
        var choice = Console.ReadLine() ?? "";

        if (choice.ToLower() == "y")
        {
            Environment.Exit(0);
        }

        Console.ReadKey();
    }

}
