namespace CSLabWork15;

public class Company
{
    public string name;

    public Company(string name)
    {
        this.name = name;
    }

    public void Edit(string change)
    {
        this.name = change;

    }

}

public static class Functions
{
    public static bool ElementIsAbsence(LinkedList<Company> linkedList, string check)
    {
        foreach (Company company in linkedList)
        {
            if (company.name.Equals(check))
            {
                return false;
            }

        }

        return true;

    }
    public static void SortList<T>(LinkedList<T> list)
    {
        List<T> sortedList = list.ToList();
        sortedList.Sort();
        list.Clear();
        foreach (var item in sortedList)
        {
            list.AddLast(item);
        }
        Console.WriteLine("Список був відсортований.");
    }

    public static void SaveListToFile<T>(LinkedList<T> list)
    {
        Console.WriteLine("Введіть ім'я файлу для збереження:");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (var item in list)
                {
                    file.WriteLine(item);
                }
                Console.WriteLine("Список був збережений у файл.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при збереженні у файл: {ex.Message}");
        }
    }

    public static void LoadListFromFile(LinkedList<Company> list)
    {
        Console.WriteLine("Введіть ім'я файлу для завантаження:");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                list.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    list.AddLast(new Company(line));
                }
                Console.WriteLine("Список був завантажений із файлу.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантаженні із файлу: {ex.Message}");
        }
    }
}
