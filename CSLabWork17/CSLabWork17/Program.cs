using System;

class Program
{
    static int Add(int x, int y)
    {
        return x + y;
    }

    static int Multiply(int x, int y)
    {
        return x * y;
    }

    static int Subtract(int x, int y)
    {
        return x - y;
    }

    static int Divide(int x, int y)
    {
        return x / y;
    }

    static int Calculate(Func<int, int, int> operation, int x, int y)
    {
        return operation(x, y);
    }

    static Func<int, Func<int, int>> Curry(Func<int, int, int> operation)
    {
        return delegate(int x)
        {
            return delegate(int y)
            {
                return operation(x, y);
            };
        };
    }
    
    public static string fileName = @"C:\Users\itesl\LabWorksCS\CSLabWork17\CSLabWork17\File.txt";
    
    struct AEROFLOT
    {
        public string CITY;
        public int NUM;
        public string TYPE;
    }
    
    static void Main()
    {
        while (true)
        {
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.WriteLine(Calculate(Add, 3, 4));

                    var curriedAdd = Curry(Add);
                    Console.WriteLine(curriedAdd(3)(4));
                    break;
                case 2:
                    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                    int maxElement = array.Aggregate((max, next) => next > max ? next : max);

                    var modifiedArray = array
                        .Where(x => x % 2 == 0)
                        .Select(x => maxElement)
                        .ToArray();

                    Console.WriteLine(string.Join(", ", array));
                    Console.WriteLine(maxElement);
                    Console.WriteLine(string.Join(", ", modifiedArray));
                    break;
                case 3:
                    Console.Write("Введіть кількість рейсів N: ");
                    int N = int.Parse(Console.ReadLine());

                    AEROFLOT[] AIR = new AEROFLOT[N];

                    for (int i = 0; i < N; i++)
                    {
                        Console.WriteLine($"Рейс {i + 1}:");
                        Console.Write("Назва населеного пункту призначення: ");
                        AIR[i].CITY = Console.ReadLine();

                        Console.Write("Номер рейсу: ");
                        AIR[i].NUM = int.Parse(Console.ReadLine());

                        Console.Write("Тип літака: ");
                        AIR[i].TYPE = Console.ReadLine();
                    }

                    AIR = AIR.OrderBy(x => x.CITY).ToArray();

                    Console.WriteLine("\nВідсортовані записи за назвами пунктів призначення:");
                    foreach (var flight in AIR)
                    {
                    Console.WriteLine($"Місто: {flight.CITY}, Номер рейсу: {flight.NUM}, Тип літака: {flight.TYPE}");
                    }
                    
                    Console.Write("\nВведіть тип літака для пошуку: ");
                    string searchType = Console.ReadLine();

                    var filteredFlights = AIR.Where(x => x.TYPE.Equals(searchType, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (filteredFlights.Any())
                    {
                        Console.WriteLine($"\nРейси літаків типу {searchType}:\n");
                        foreach (var flight in filteredFlights)
                        {
                            Console.WriteLine($"Місто: {flight.CITY}, Номер рейсу: {flight.NUM}");
                        }
                    }
                    else
                    {
                      Console.WriteLine($"Рейсів літаків типу {searchType} не знайдено.");
                    }


                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        foreach (var flight in AIR)
                        {
                                writer.WriteLine($"{flight.CITY},{flight.NUM},{flight.TYPE}");
                        }
                    }
                    break;
            }
        }

    }
}
