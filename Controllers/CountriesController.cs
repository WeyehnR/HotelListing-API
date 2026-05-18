using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing_API.Models;
using HotelListing_API.Data;

[Route("api/[controller]")]
[ApiController]
public class CountriesController(HotelListingDbContext context) : ControllerBase
{
    private readonly HotelListingDbContext _context = context;

    // GET: api/Country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
    {
        return await _context.Countries.ToListAsync();
    }

    // GET: api/Country/5
    [HttpGet("{countryid}")]
    public async Task<ActionResult<Country>> GetCountry(int countryid)
    {
        var country = await _context.Countries.FindAsync(countryid);

        if (country == null)
        {
            return NotFound();
        }

        return country;
    }

    // PUT: api/Country/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{countryid}")]
    public async Task<IActionResult> PutCountry(int? countryid, Country country)
    {
        if (countryid != country.CountryId)
        {
            return BadRequest();
        }

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(countryid))
            {
                return NotFound("Country cannot be updated because it was not found.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Country
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { countryid = country.CountryId }, country);
    }

    // DELETE: api/Country/5
    [HttpDelete("{countryid}")]
    public async Task<IActionResult> DeleteCountry(int? countryid)
    {
        var country = await _context.Countries.FindAsync(countryid);
        if (country == null)
        {
            return NotFound("Country cannot be deleted because it was not found.");
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //Make this CountryExist async to avoid blocking the thread while waiting for the database operation to complete. This is especially important in a web application where you want to keep the server responsive and able to handle multiple requests concurrently.
    private async Task<bool> CountryExists(int? countryid)
    {
        return await _context.Countries.AnyAsync(e => e.CountryId == countryid);
    }
}
