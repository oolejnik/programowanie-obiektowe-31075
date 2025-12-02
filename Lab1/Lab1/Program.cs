using System.Globalization;

//example 1

const int requiredAge = 18;
const string accessDeniedMessage = "Musisz mieć 18 lat";
const string accessAllowedMessage = "Witaj w sklepie";

int age = 16;

do
{
    Console.WriteLine("Podaj swój wiek");
    string input = Console.ReadLine();

    bool success = int.TryParse(input, out age);

    if (!success)
    {
        Console.WriteLine("Wprowadź poprawne dane!");
    }
    else
    {

        if (age >= requiredAge)
        {
            Console.WriteLine(accessAllowedMessage);
        }
        else
        {
            Console.WriteLine(accessDeniedMessage);
        }
    }
} while (age < requiredAge);

//example 2

/*var names =new string[] { "Artur", "Ania", "Karol", "Michał" };

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}

foreach (var name in names)
{
    Console.WriteLine(name);
}*/

// zadanie 1
/*
string password;
do
{
    Console.Write("Podaj hasło: ");
    password = Console.ReadLine();
}
while (password != "admin123");
Console.WriteLine("Zalogowano pomyślnie!"); */


//zadanie 2
/*
string number;
int number1;
do
{
    Console.Write("Podaj liczbę większą od zera: ");
    number = Console.ReadLine();
    number1 = int.Parse(number);
}
while (number1 <= 0);
Console.WriteLine("Dobrze"); */

//zadanie 3
/*
string[] towns = { "Wolsztyn", "Poznań", "Wrocław", "Leszno", "Zielona Góra" };

foreach (string town in towns)
{
    Console.WriteLine(town);
} */

