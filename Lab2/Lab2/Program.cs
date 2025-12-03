//zadanie 4

/*class KontoBankowe
{
    private double saldo;
    public void Wplata(double kwota) { saldo += kwota; }

    public bool Wyplata(double kwota)
    {
        if (saldo >= kwota)
        {
            saldo -= kwota;
            return true;
        }

        if (kwota <= 0)
        {
            return false;
        }
    }
    public double PobierzSaldo() { return saldo; }
}*/

//zadanie 5
/*class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je");
}
class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("Hau hau!");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau!");
}*/

//zadanie 6

using System;

class Zwierze
{
    public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}
class Pies : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Hau hau!");
}
class Kot : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Miau!");
}

class Program
{

    static void Main()
    {
        Zwierze[] zwierzeta = new Zwierze[]
        {
            new Pies(),
            new Kot(),
            new Zwierze()
        };

        foreach (var zwierze in zwierzeta)
        {
            zwierze.DajGlos();
        }
    }
}