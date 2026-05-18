using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing_API.Models;
using HotelListing_API.Data;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelListingDbContext context) : ControllerBase
{

    // GET: api/Hotel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
    {
        return await context.Hotels.ToListAsync();
    }

    // GET: api/Hotel/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetHotel(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }

        return hotel;
    }

    // PUT: api/Hotel/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int? id, Hotel hotel)
    {
        if (id != hotel.Id)
        {
            return BadRequest();
        }

        context.Entry(hotel).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Hotel
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
    {
        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotel/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int? id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        context.Hotels.Remove(hotel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> HotelExists(int? id)
    {
        return await context.Hotels.AnyAsync(e => e.Id == id);
    }
}
