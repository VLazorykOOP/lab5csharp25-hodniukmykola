using System;
using System.Collections.Generic;

struct Person
{
    public string LastName;
    public string FirstName;
    public string MiddleName;
    public string Address;
    public string Phone;
    public int Age;

    public void Show()
    {
        Console.WriteLine($"{LastName} {FirstName} {MiddleName}, {Address}, {Phone}, {Age} років");
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { LastName = "Іванов", FirstName = "Петро", MiddleName = "Іванович", Address = "вул. Центральна, 1", Phone = "111-11-11", Age = 25 },
            new Person { LastName = "Сидоренко", FirstName = "Олена", MiddleName = "Вікторівна", Address = "вул. Лісова, 5", Phone = "222-22-22", Age = 30 },
            new Person { LastName = "Коваль", FirstName = "Олег", MiddleName = "Миколайович", Address = "вул. Шевченка, 10", Phone = "333-33-33", Age = 25 }
        };

        int ageToRemove = 25;
        string phoneToFind = "222-22-22";

        people.RemoveAll(p => p.Age == ageToRemove);

        Person newPerson = new Person
        {
            LastName = "Новак",
            FirstName = "Анна",
            MiddleName = "Ігорівна",
            Address = "вул. Нова, 7",
            Phone = "444-44-44",
            Age = 28
        };

        int index = people.FindIndex(p => p.Phone == phoneToFind);
        if (index != -1)
        {
            people.Insert(index + 1, newPerson);
        }

        Console.WriteLine("Список людей після змін:");
        foreach (var person in people)
            person.Show();
    }
}
