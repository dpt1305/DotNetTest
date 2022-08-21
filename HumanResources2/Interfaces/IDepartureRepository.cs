using System;
using HumanResources2.Interfaces;
using HumanResources2.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HumanResources2.Interfaces
{
    public interface IDepartureRepository: IBaseRepository<Departure>
    {
    }

   
}

