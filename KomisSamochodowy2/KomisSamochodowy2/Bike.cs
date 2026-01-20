namespace KomisSamochodowy2.Models;

class Bike : Vehicle
{
    public string BikeType { get; set; }

    public Bike(string engine, string bikeType) : base(engine)
    {
        BikeType = bikeType;
    }

    public Bike() : base("") { }
}
