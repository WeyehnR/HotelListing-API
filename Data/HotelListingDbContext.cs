using HotelListing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing_API.Data;
public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
}

