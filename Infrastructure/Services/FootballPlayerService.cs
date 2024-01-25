using Azure.Core;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class FootballPlayerService(BirthDatesRepository birthDatesRepository, FootballClubsRepository footballClubsRepository, FootballPlayersRepository footballPlayersRepository, NationalitiesRepository nationalitiesRepository, PositionsRepository positionsRepository)
{
    public readonly BirthDatesRepository _birthDatesRepository = birthDatesRepository;
    public readonly FootballClubsRepository _footballClubsRepository = footballClubsRepository;
    public readonly FootballPlayersRepository _footballPlayersRepository = footballPlayersRepository;
    public readonly NationalitiesRepository _nationalitiesRepository = nationalitiesRepository;
    public readonly PositionsRepository _positionsRepository = positionsRepository;

    public bool CreateFootballPlayer(FootballPlayerDto player)
    {
        try
        {
            if (!_footballPlayersRepository.Exists(x => x.Email == player.Email))
            {
                var footballClubEntity = _footballClubsRepository.GetOne(x => x.CurrentClub == player.CurrentClub && x.FirstClub == player.FirstClub);
                footballClubEntity ??= _footballClubsRepository.Create(new FootballClubsEntity { CurrentClub = player.CurrentClub, FirstClub = player.FirstClub });

                var nationalityEntity = _nationalitiesRepository.GetOne(x => x.Nationality == player.Nationality);
                nationalityEntity ??= _nationalitiesRepository.Create(new NationalitiesEntity { Nationality = player.Nationality, City = player.City });

                var positionsEntity = _positionsRepository.GetOne(x => x.Position == player.Position);
                positionsEntity ??= _positionsRepository.Create(new PositionsEntity { Position = player.Position });

                var birthDateEntity = _birthDatesRepository.GetOne(x => x.BirthYear == player.BirthYear && x.BirthMonth == player.BirthMonth && x.BirthDay == player.BirthDay);
                birthDateEntity ??= _birthDatesRepository.Create(new BirthDatesEntity { BirthYear = player.BirthYear, BirthMonth = player.BirthMonth, BirthDay = player.BirthDay });

                var newPlayer = new FootballPlayersEntity
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Email = player.Email,
                    FootballClubId = footballClubEntity.Id,
                    NationalitiesId = nationalityEntity.Id,
                    PositionsId = positionsEntity.Id,
                    BirthDatesId = birthDateEntity.Id,
                };

                var result = _footballPlayersRepository.Create(newPlayer);
                if (result != null)
                    return true;
                    
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }

    public IEnumerable<FootballPlayerDto> GetAllPlayers()
    {
        var players = new List<FootballPlayerDto>();
        
        try
        {
            var result = _footballPlayersRepository.GetAll();

            foreach (var player in result)
                players.Add(new FootballPlayerDto
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Email = player.Email,
                    CurrentClub = player.FootballClub.CurrentClub,
                    FirstClub = player.FootballClub.FirstClub,
                    Position = player.Positions.Position,
                    BirthYear = player.BirthDates.BirthYear,
                    BirthMonth = player.BirthDates.BirthMonth,
                    BirthDay = player.BirthDates.BirthDay,
                    Nationality = player.Nationalities.Nationality,
                    City = player.Nationalities.City
                });
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return players;
    }


    public FootballPlayerDto GetOnePlayer(string email)
    {
        try
        {
            var player = _footballPlayersRepository.GetOne(x => x.Email == email);

            if (player != null)
            {
                var footballPlayer = new FootballPlayerDto
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Email = player.Email,
                    CurrentClub = player.FootballClub.CurrentClub,
                    FirstClub = player.FootballClub.FirstClub,
                    Position = player.Positions.Position,
                    BirthYear = player.BirthDates.BirthYear,
                    BirthMonth = player.BirthDates.BirthMonth,
                    BirthDay = player.BirthDates.BirthDay,
                    Nationality = player.Nationalities.Nationality,
                    City = player.Nationalities.City,
                };

                return footballPlayer;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool UpdatePlayer(string email, FootballPlayerDto updatePlayer)
    {
        try
        {
            return _footballPlayersRepository.Update(x => x.Email == email, entity =>
            {
                entity.FirstName = updatePlayer.FirstName;
                entity.LastName = updatePlayer.LastName;
                entity.Email = updatePlayer.Email;
                entity.FootballClub.CurrentClub = updatePlayer.CurrentClub;
                entity.FootballClub.FirstClub = updatePlayer.FirstClub;
                entity.Positions.Position = updatePlayer.Position;
                entity.Nationalities.Nationality = updatePlayer.Nationality;
                entity.Nationalities.City = updatePlayer.City;
                entity.BirthDates.BirthYear = updatePlayer.BirthYear;
                entity.BirthDates.BirthMonth = updatePlayer.BirthMonth;
                entity.BirthDates.BirthDay = updatePlayer.BirthDay;
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return false;
        }
    }

    public bool DeleteFootballPlayer(string email)
    {
        try
        {
            return _footballPlayersRepository.Delete(x => x.Email == email);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); 
            return false; }
    }
}
