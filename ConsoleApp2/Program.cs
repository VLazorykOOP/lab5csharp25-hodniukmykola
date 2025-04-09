using System;
using System.Collections.Generic;

// Деталь
class Detail
{
    public string Name { get; set; }
    public string Material { get; set; }
    public double Weight { get; set; }

    public Detail()
    {
        Console.WriteLine("Конструктор без параметрів (Detail)");
    }

    public Detail(string name)
    {
        Name = name;
        Console.WriteLine("Конструктор з 1 параметром (Detail)");
    }

    public Detail(string name, string material, double weight)
    {
        Name = name;
        Material = material;
        Weight = weight;
        Console.WriteLine("Конструктор з 3 параметрами (Detail)");
    }

    ~Detail()
    {
        Console.WriteLine("Деструктор (Detail): " + Name);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Деталь: {Name}, Матеріал: {Material}, Вага: {Weight} кг");
    }
}

// Механізм
class Mechanism
{
    public string Type { get; set; }
    public List<Detail> Details { get; set; } = new List<Detail>();

    public Mechanism()
    {
        Console.WriteLine("Конструктор без параметрів (Mechanism)");
    }

    public Mechanism(string type)
    {
        Type = type;
        Console.WriteLine("Конструктор з 1 параметром (Mechanism)");
    }

    public Mechanism(string type, List<Detail> details)
    {
        Type = type;
        Details = details;
        Console.WriteLine("Конструктор з 2 параметрами (Mechanism)");
    }

    ~Mechanism()
    {
        Console.WriteLine("Деструктор (Mechanism): " + Type);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Механізм: {Type}");
        foreach (var d in Details)
            d.Show();
    }

    public void AddDetail(Detail detail)
    {
        Details.Add(detail);
    }
}

// Вузол
class Node
{
    public string Name { get; set; }
    public List<Mechanism> Mechanisms { get; set; } = new List<Mechanism>();

    public Node()
    {
        Console.WriteLine("Конструктор без параметрів (Node)");
    }

    public Node(string name)
    {
        Name = name;
        Console.WriteLine("Конструктор з 1 параметром (Node)");
    }

    public Node(string name, List<Mechanism> mechanisms)
    {
        Name = name;
        Mechanisms = mechanisms;
        Console.WriteLine("Конструктор з 2 параметрами (Node)");
    }

    ~Node()
    {
        Console.WriteLine("Деструктор (Node): " + Name);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Вузол: {Name}");
        foreach (var mech in Mechanisms)
            mech.Show();
    }

    public void AddMechanism(Mechanism mech)
    {
        Mechanisms.Add(mech);
    }
}

// Виріб
class Product
{
    public string Name { get; set; }
    public List<Node> Nodes { get; set; } = new List<Node>();

    public Product()
    {
        Console.WriteLine("Конструктор без параметрів (Product)");
    }

    public Product(string name)
    {
        Name = name;
        Console.WriteLine("Конструктор з 1 параметром (Product)");
    }

    public Product(string name, List<Node> nodes)
    {
        Name = name;
        Nodes = nodes;
        Console.WriteLine("Конструктор з 2 параметрами (Product)");
    }

    ~Product()
    {
        Console.WriteLine("Деструктор (Product): " + Name);
    }

    public void Show()
    {
        Console.WriteLine($"Виріб: {Name}");
        foreach (var node in Nodes)
            node.Show();
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }
}

// Демонстрація
class Program
{
    static void Main()
    {
        Detail d1 = new Detail("Шестерня", "Сталь", 1.2);
        Detail d2 = new Detail("Кришка", "Пластик", 0.5);

        Mechanism mech = new Mechanism("Передача");
        mech.AddDetail(d1);
        mech.AddDetail(d2);

        Node node = new Node("Редуктор");
        node.AddMechanism(mech);

        Product product = new Product("Електропривод");
        product.AddNode(node);

        product.Show();

        // Примусове виклик GC для демонстрації деструкторів (НЕ рекомендується для реального коду)
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
