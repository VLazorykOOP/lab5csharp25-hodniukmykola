using System;
using System.Collections.Generic;

// Абстрактний клас Trans
abstract class Trans
{
    public string Marka { get; set; }
    public string Number { get; set; }
    public int Speed { get; set; }

    public Trans(string marka, string number, int speed)
    {
        Marka = marka;
        Number = number;
        Speed = speed;
    }

    public abstract void ShowInfo();
    public abstract double GetCargoCapacity();
}

// Легкова машина
class Car : Trans
{
    public double CargoCapacity { get; set; }

    public Car(string marka, string number, int speed, double capacity)
        : base(marka, number, speed)
    {
        CargoCapacity = capacity;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Легкова машина: {Marka}, Номер: {Number}, Швидкість: {Speed} км/год, Вантажопідйомність: {CargoCapacity} кг");
    }

    public override double GetCargoCapacity()
    {
        return CargoCapacity;
    }
}

// Мотоцикл
class Motorcycle : Trans
{
    public double BaseCapacity { get; set; }
    public bool HasSidecar { get; set; }

    public Motorcycle(string marka, string number, int speed, double baseCapacity, bool hasSidecar)
        : base(marka, number, speed)
    {
        BaseCapacity = baseCapacity;
        HasSidecar = hasSidecar;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Мотоцикл: {Marka}, Номер: {Number}, Швидкість: {Speed} км/год, Коляска: {(HasSidecar ? "так" : "ні")}, Вантажопідйомність: {GetCargoCapacity()} кг");
    }

    public override double GetCargoCapacity()
    {
        return HasSidecar ? BaseCapacity : 0;
    }
}

// Вантажівка
class Truck : Trans
{
    public double BaseCapacity { get; set; }
    public bool HasTrailer { get; set; }

    public Truck(string marka, string number, int speed, double baseCapacity, bool hasTrailer)
        : base(marka, number, speed)
    {
        BaseCapacity = baseCapacity;
        HasTrailer = hasTrailer;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Вантажівка: {Marka}, Номер: {Number}, Швидкість: {Speed} км/год, Причіп: {(HasTrailer ? "так" : "ні")}, Вантажопідйомність: {GetCargoCapacity()} кг");
    }

    public override double GetCargoCapacity()
    {
        return HasTrailer ? BaseCapacity * 2 : BaseCapacity;
    }
}

// Демонстрація
class Program
{
    static void Main()
    {
        List<Trans> transportBase = new List<Trans>
        {
            new Car("Toyota", "AA1234", 180, 500),
            new Motorcycle("Honda", "BB5678", 160, 100, true),
            new Motorcycle("Suzuki", "CC9012", 170, 100, false),
            new Truck("Volvo", "DD3456", 120, 3000, true),
            new Truck("MAN", "EE7890", 110, 2500, false)
        };

        Console.WriteLine("Вся база транспортних засобів:\n");
        foreach (var t in transportBase)
        {
            t.ShowInfo();
        }

        Console.WriteLine("\nПошук машин з вантажопідйомністю >= 1000 кг:\n");
        foreach (var t in transportBase)
        {
            if (t.GetCargoCapacity() >= 1000)
                t.ShowInfo();
        }
    }
}
