struct AEROFLOT
{
    public string CITY;
    public int NUM;
    public string TYPE;
}

class Program
{
    static void Main()
    {
        LinkedList<AEROFLOT> airList = new LinkedList<AEROFLOT>(); // Створення LinkedList для зберігання об'єктів типу AEROFLOT

        Console.WriteLine("Введіть кількість рейсів:");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            AEROFLOT flight = new AEROFLOT();

            Console.WriteLine($"Введіть дані для рейсу {i + 1}:");
            Console.Write("Назва населеного пункту призначення: ");
            flight.CITY = Console.ReadLine();

            Console.Write("Номер рейсу: ");
            flight.NUM = int.Parse(Console.ReadLine());

            Console.Write("Тип літака: ");
            flight.TYPE = Console.ReadLine();

            airList.AddLast(flight);
        }

        airList = new LinkedList<AEROFLOT>(airList.OrderBy(flight => flight.CITY));

        Console.Write("Введіть тип літака для виведення відповідних рейсів: ");
        string inputType = Console.ReadLine();

        bool found = false;

        foreach (AEROFLOT flight in airList)
        {
            if (flight.TYPE == inputType)
            {
                Console.WriteLine($"Пункт призначення: {flight.CITY}, Номер рейсу: {flight.NUM}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Рейсів з літаком типу {inputType} не знайдено.");
        }

        airList.Clear();

        using (StreamWriter writer = new StreamWriter("airlist.txt"))
        {
            foreach (AEROFLOT flight in airList)
            {
                writer.WriteLine($"{flight.CITY},{flight.NUM},{flight.TYPE}");
            }
        }
        
        using (FileStream fileStream = new FileStream("airlist.bin", FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fileStream))
        {
            foreach (AEROFLOT flight in airList)
            {
                writer.Write(flight.CITY);
                writer.Write(flight.NUM);
                writer.Write(flight.TYPE);
            }
        }
    }
}
