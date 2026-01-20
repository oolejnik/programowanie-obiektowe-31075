namespace KomisSamochodowy2.Models;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string Engine { get; set; }

    public Vehicle(string engine)
    {
        Engine = engine;
    }
}