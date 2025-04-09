using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<(string LastName, string FirstName, string MiddleName, string Address, string Phone, int Age)> people =
            new List<(string, string, string, string, string, int)>
        {
            ("Іванов", "Петро", "Іванович", "вул. Центральна, 1", "111-11-11", 25),
            ("Сидоренко", "Олена", "Вікторівна", "вул. Лісова, 5", "222-22-22", 30),
            ("Коваль", "Олег", "Миколайович", "вул. Шевченка, 10", "333-33-33", 25)
        };

        int ageToRemove = 25;
        string phoneToFind = "222-22-22";

        people.RemoveAll(p => p.Age == ageToRemove);

        var newPerson = ("Новак", "Анна", "Ігорівна", "вул. Нова, 7", "444-44-44", 28);

        int index = people.FindIndex(p => p.Phone == phoneToFind);
        if (index != -1)
            people.Insert(index + 1, newPerson);

        Console.WriteLine("Список людей після змін:");
        foreach (var p in people)
            Console.WriteLine($"{p.LastName} {p.FirstName} {p.MiddleName}, {p.Address}, {p.Phone}, {p.Age} років");
    }
}
