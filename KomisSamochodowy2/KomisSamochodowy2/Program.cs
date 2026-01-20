using KomisSamochodowy2.Models; 
using System.Text.Json;

var carsPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
var bikesPath = Path.Combine(Directory.GetCurrentDirectory(), "bikes.json");

List<Car> cars;

if (File.Exists(carsPath))
{
    var json = File.ReadAllText(carsPath);
    cars = JsonSerializer.Deserialize<List<Car>>(json);
}
else
{
    cars = new List<Car>();
}

List<Bike> bikes;

if (File.Exists(bikesPath))
{
    var json = File.ReadAllText(bikesPath);
    bikes  = JsonSerializer.Deserialize<List<Bike>>(json);
}
else
{
    bikes = new List<Bike>();
}

bool running = true;

while (running)
{
    Console.WriteLine("\n=== KOMIS ===");
    Console.WriteLine("1. Lista pojazdów");
    Console.WriteLine("2. Dodaj pojazd");
    Console.WriteLine("3. Usuń pojazd");
    Console.WriteLine("4. Modyfikuj pojazd");
    Console.WriteLine("0. Wyjście");

    var key = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (key)
    {
        case '1':
            ShowVehicles();
            break;
        case '2':
            AddVehicle();
            Save();
            break;
        case '3':
            ShowVehicles();
            RemoveVehicle();
            Save();
            break;
        case '4':
            ShowVehicles();
            UpdateVehicle();
            Save();
            break;
        case '0':
            running = false;
            break;
        default:
            Console.WriteLine("Nieznana opcja");
            break;
    }
}

void ShowVehicles()
{
    Console.WriteLine("\n--- CARS ---");
    foreach (var c in cars)
        Console.WriteLine($"ID:{c.Id} | {c.Model} | {c.Engine} | {c.Year}");

    Console.WriteLine("\n--- BIKES ---");
    foreach (var b in bikes)
        Console.WriteLine($"ID:{b.Id} | {b.BikeType} | {b.Engine}");
}

void AddVehicle()
{
    Console.WriteLine("1 – Car, 2 – Bike");
    var type = Console.ReadKey().KeyChar;
    Console.WriteLine();
    
    int maxCarId;
    int maxBikeId;
    
    if (cars.Any())
    {
        maxCarId = cars.Max(c => c.Id);
    }
    else
    {
        maxCarId = 0;
    }
    
    if (bikes.Any())
    {
        maxBikeId = bikes.Max(b => b.Id);
    }
    else
    {
        maxBikeId = 0;
    }
    
    int nextId;

    if (maxCarId > maxBikeId)
    {
        nextId = maxCarId + 1;
    }
    else
    {
        nextId = maxBikeId + 1;
    }

    if (type == '1')
    {
        Console.Write("Model: ");
        var model = Console.ReadLine();

        Console.Write("Engine: ");
        var engine = Console.ReadLine();

        Console.Write("Year: ");
        int.TryParse(Console.ReadLine(), out int year);

        cars.Add(new Car(engine, model, year) { Id = nextId });
    }
    else if (type == '2')
    {
        Console.Write("Bike type: ");
        var typeName = Console.ReadLine();

        Console.Write("Engine: ");
        var engine = Console.ReadLine();

        bikes.Add(new Bike(engine, typeName) { Id = nextId });
    }
}

void RemoveVehicle()
{
    Console.Write("Podaj ID do usunięcia: ");
    int.TryParse(Console.ReadLine(), out int id);

    if (cars.RemoveAll(c => c.Id == id) > 0 ||
        bikes.RemoveAll(b => b.Id == id) > 0)
    {
        Console.WriteLine("Usunięto.");
    }
    else
    {
        Console.WriteLine("Nie znaleziono pojazdu.");
    }
}

void UpdateVehicle()
{
    Console.Write("Podaj ID do modyfikacji: ");
    int.TryParse(Console.ReadLine(), out int id);

    Car car = null;

    foreach (var c in cars)
    {
        if (c.Id == id)
        {
            car = c;
            break;
        }
    }

    Bike bike = null;

    foreach (var b in bikes)
    {
        if (b.Id == id)
        {
            bike = b;
            break;
        }
    }

    if (car != null)
    {
        Console.Write("Nowy model: ");
        car.Model = Console.ReadLine();

        Console.Write("Nowy engine: ");
        car.Engine = Console.ReadLine();

        Console.Write("Nowy year: ");
        int.TryParse(Console.ReadLine(), out int year);
        car.Year = year;

        Console.WriteLine("Zaktualizowano.");
    }
    else if (bike != null)
    {
        Console.Write("Nowy bike type: ");
        bike.BikeType = Console.ReadLine();

        Console.Write("Nowy engine: ");
        bike.Engine = Console.ReadLine();

        Console.WriteLine("Zaktualizowano.");
    }
    else
    {
        Console.WriteLine("Nie znaleziono pojazdu.");
    }
}

void Save()
{
    File.WriteAllText(carsPath, JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true }));
    File.WriteAllText(bikesPath, JsonSerializer.Serialize(bikes, new JsonSerializerOptions { WriteIndented = true }));
}
