using System;
using System.Collections.Generic;

public record PersonRecord(string LastName, string FirstName, string MiddleName, string Address, string Phone, int Age);

class Program
{
    static void Main()
    {
        List<PersonRecord> people = new List<PersonRecord>
        {
            new("Іванов", "Петро", "Іванович", "вул. Центральна, 1", "111-11-11", 25),
            new("Сидоренко", "Олена", "Вікторівна", "вул. Лісова, 5", "222-22-22", 30),
            new("Коваль", "Олег", "Миколайович", "вул. Шевченка, 10", "333-33-33", 25)
        };

        int ageToRemove = 25;
        string phoneToFind = "222-22-22";

        people.RemoveAll(p => p.Age == ageToRemove);

        PersonRecord newPerson = new("Новак", "Анна", "Ігорівна", "вул. Нова, 7", "444-44-44", 28);

        int index = people.FindIndex(p => p.Phone == phoneToFind);
        if (index != -1)
            people.Insert(index + 1, newPerson);

        Console.WriteLine("Список людей після змін:");
        foreach (var p in people)
            Console.WriteLine($"{p.LastName} {p.FirstName} {p.MiddleName}, {p.Address}, {p.Phone}, {p.Age} років");
    }
}
