using HumanResources2.Interfaces;
using HumanResources2.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources2.Controllers;

[ApiController]
[Route("/api/departures")]
public class DeparturesController : ControllerBase
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
            IEnumerable<Departure> departures = await _departureRepo.FindAll();
            return Ok(departures);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartureById(Guid id)
    {
        try
        {
            IEnumerable<Departure> departure = await _departureRepo.FindOneById(id);
            return Ok(departure);
        }
        catch (Exception ex)
        {
            return StatusCode(404, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewDeparture(Departure entity)
    {
        string name = entity.Name ?? "N/A";
        Departure departure = new Departure(name);
        try
        {
            var query = await _departureRepo.Create(departure);

            return Ok($"Success.{query}");
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDeparture(Departure departure)
    {
        try
        {
            var query = await _departureRepo.Update(departure);

            return Ok($"Success.{query}");
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);

        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDeDeparture(Guid id)
    {
        try
        {
            var query = await _departureRepo.Delete(id);

            return Ok($"Success.{query}");
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);

        }

    }
}


