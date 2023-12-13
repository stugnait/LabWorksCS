using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість учасників:");
        int n = int.Parse(Console.ReadLine());

        LinkedList<string> participants = new LinkedList<string>(new[]
        {
            "Сидоренко", "Іванов", "Петров", "Коваленко", "Ковальчук",
            "Шевченко", "Мельник", "Козак", "Григоренко", "Ткаченко",
            "Шевцов", "Василенко", "Лисенко", "Литвиненко", "Левченко",
            "Чернов", "Яковенко", "Марченко", "Кучер", "Жуков"
        });

        Console.WriteLine("Введіть число p:");
        int p = int.Parse(Console.ReadLine());

        var currentNode = participants.First;

        while (participants.Count > 1)
        {
            for (int i = 0; i < p - 1; i++)
            {
                currentNode = currentNode.Next ?? participants.First;
            }

            var nextNode = currentNode.Next ?? participants.First;
            
            Console.WriteLine($"Вилучено: {currentNode.Value}");
            
            participants.Remove(currentNode);
            currentNode = nextNode;
        }

        Console.WriteLine($"Останній учасник: {participants.First.Value}");
    }
}