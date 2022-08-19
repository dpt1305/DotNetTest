using System;
using Dapper;
using HumanResources2.Context;
using HumanResources2.Contracts;
using HumanResources2.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HumanResources2.Repository;

public class DepartureRepository: IDepartureRepository
{
    private readonly DapperContext _context;
    public DepartureRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Departure>> CreateNewDeparture(Departure departure)
    {
        string query = $"INSERT INTO Departures(DepartureId, Name) VALUES (\'{departure.DepartureID}\', \'{departure.Name}\');";

        using (var connection = _context.CreateConnection())
        {
            var dapartures = await connection.QueryAsync<Departure>(query);
            return dapartures;
        }
        //throw new NotImplementedException();
    }

    public async Task<IEnumerable<Departure>> GetAllDepartures()
    {
        var query = "SELECT * FROM Departures";
        using (var connection = _context.CreateConnection())
        {
            var dapartures = await connection.QueryAsync<Departure>(query);
            return dapartures.ToList();
        }
           //throw new NotImplementedException();
    }
}

