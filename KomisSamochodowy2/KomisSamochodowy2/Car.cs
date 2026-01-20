namespace KomisSamochodowy2.Models;

class Car : Vehicle
{
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string engine, string model, int year) : base(engine)
    {
        Model = model;
        Year = year;
    }
    
    public Car() : base("") { }
}