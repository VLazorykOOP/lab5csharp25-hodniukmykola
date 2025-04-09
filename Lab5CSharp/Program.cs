using System;
using System.Collections.Generic;

// Базовий клас
class Detail
{
    public string Name { get; set; }
    public string Material { get; set; }
    public double Weight { get; set; }

    public Detail(string name, string material, double weight)
    {
        Name = name;
        Material = material;
        Weight = weight;
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

    public Mechanism(string type)
    {
        Type = type;
    }

    public void AddDetail(Detail detail)
    {
        Details.Add(detail);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Механізм: {Type}");
        foreach (var detail in Details)
        {
            detail.Show();
        }
    }
}

// Вузол
class Node
{
    public string Name { get; set; }
    public List<Mechanism> Mechanisms { get; set; } = new List<Mechanism>();

    public Node(string name)
    {
        Name = name;
    }

    public void AddMechanism(Mechanism mechanism)
    {
        Mechanisms.Add(mechanism);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Вузол: {Name}");
        foreach (var mech in Mechanisms)
        {
            mech.Show();
        }
    }
}

// Виріб
class Product
{
    public string Name { get; set; }
    public List<Node> Nodes { get; set; } = new List<Node>();

    public Product(string name)
    {
        Name = name;
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void Show()
    {
        Console.WriteLine($"Виріб: {Name}");
        foreach (var node in Nodes)
        {
            node.Show();
        }
    }
}

// Демонстрація
class Program
{
    static void Main()
    {
        Detail d1 = new Detail("Гвинт", "Сталь", 0.1);
        Detail d2 = new Detail("Кришка", "Пластик", 0.5);

        Mechanism mech = new Mechanism("Привід");
        mech.AddDetail(d1);
        mech.AddDetail(d2);

        Node node = new Node("Корпус");
        node.AddMechanism(mech);

        Product product = new Product("Свердло");
        product.AddNode(node);

        product.Show();
    }
}
