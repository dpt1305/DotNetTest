using System;
using HumanResources2.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HumanResources2.Contracts
{
    public interface IDepartureRepository
    {
        public Task<IEnumerable<Departure>> GetAllDepartures();
        public Task<IEnumerable<Departure>> CreateNewDeparture(Departure de
            );
    }
    //public interface 
}

