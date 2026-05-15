namespace HotelListing_API.Data;

public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public IList<Hotel> Hotels { get; set; } = new List<Hotel>();
}

// a navigation property is a property defined in an entity class
// that represents a relationship between two entities. It allows you
// to navigate from one entity to another related entity or collection of entities.
// In the context of the Country class, the Hotels property is a navigation property that
// represents the relationship between a country and its associated hotels. It allows you
// to access the hotels that are located in a specific country.

//in a database relationship , a country can have multiple hotels, but each hotel is associated
//with only one country. This is a one-to-many relationship, where the Country entity is the "one"
//side and the Hotel entity is the "many" side. The Hotels navigation property in the Country class
//allows you to access all the hotels that belong to a specific country, while the CountryId property
//in the Hotel class serves as a foreign key to establish the relationship between the two entities.