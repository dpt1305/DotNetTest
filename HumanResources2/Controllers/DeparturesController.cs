using System;
using HumanResources2.Interfaces;
using HumanResources2.DTO;
using HumanResources2.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources2.Controllers;

[ApiController]
[Route("/api/departures")]
public class DeparturesController: ControllerBase
{
    private readonly IDepartureRepository _departureRepo;
    public DeparturesController(IDepartureRepository departureRepo) 
    {
        _departureRepo = departureRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDepartures()
    {
        try
        {
            var departures = await _departureRepo.FindAll();
            return Ok(departures);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewDeparture(DepartureDto departureDto)
    {
        try
        {
            var name = departureDto.Name;
            var departure = new Departure(name);

            var query = await _departureRepo.Create(departure);

            return Ok($"Success.{query}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

