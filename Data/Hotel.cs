namespace HotelListing_API.Data;

public class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; } = string.Empty;

    public double Rating { get; set; }

}

//An auto-implemented property is a shorthand syntax for defining a property in C#.
//It allows you to quickly create a property without having to explicitly define a backing field.
//The compiler automatically generates a private, anonymous backing field for the property, which is used
//to store the value of the property.

//the syntax for an auto-implemented property is as follows:
//<access_modifier> <data_type> <property_name> { get; set; }

//now within that syntax, you can also include an initializer to set a default value for the property. For example:
//public string Name { get; set; } = "Default Name";

//Now, when you create an instance of the class that contains this property, the Name property will be initialized with
//the value "Default Name" unless you explicitly set it to something else.

//the 'get' accessor is used to retrieve the value of the property, while the 'set' accessor is used to assign a value to the property.

//Here is how you can use this Hotel class:
//Hotel hotel = new Hotel();
//hotel.Id = 1;
//hotel.Name = "Grand Hotel";
//hotel.Address = "123 Main Street";
//hotel.Rating = 4.5;


//in the end, they are syntactic sugar that allows you to write cleaner and more concise code when defining properties in C#.
