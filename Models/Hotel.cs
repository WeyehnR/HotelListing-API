namespace HotelListing_API.Models;

public class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; } = string.Empty;

    public double Rating { get; set; }

    public int CountryId { get; set; }

    public Country? Country { get; set; } //this is a navigation property that allows you to access the associated Country entity for a specific hotel. It represents the relationship between the Hotel and Country entities, where each hotel is associated with one country. By including this navigation property
}
