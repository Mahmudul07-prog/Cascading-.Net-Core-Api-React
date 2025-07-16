using Cascading_React.Server.Data;
using Cascading_React.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Cascading_React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CascadingDbContext _context;
        public LocationsController(CascadingDbContext context)
        {
            _context = context;
        }

        // GET: api/CascadingDropdown/countries
        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/CascadingDropdown/divisions/{countryId}
        [HttpGet("divisions/{countryId}")]
        public async Task<ActionResult<IEnumerable<Division>>> GetDivisionsByCountry(int countryId)
        {
            return await _context.Divisions
                .Where(d => d.CountryId == countryId)
                .ToListAsync();
        }

        // GET: api/CascadingDropdown/cities/{divisionId}
        [HttpGet("cities/{divisionId}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesByDivision(int divisionId)
        {
            return await _context.Cities
                .Where(c => c.DivisionId == divisionId)
                .ToListAsync();
        }

        // GET: api/CascadingDropdown/all
        [HttpGet("all")]
        public async Task<ActionResult<object>> GetAllLocations()
        {
            var countries = await _context.Countries.ToListAsync();
            var divisions = await _context.Divisions.ToListAsync();
            var cities = await _context.Cities.ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return Ok(new { countries, divisions, cities });
        }
    }
}
