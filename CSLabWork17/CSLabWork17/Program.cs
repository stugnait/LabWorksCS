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

                    Console.WriteLine("Масив до модифікації: " + string.Join(", ", array));
                    Console.WriteLine("Максимальний елемент: " + maxElement);
                    Console.WriteLine("Модифікований масив: " + string.Join(", ", modifiedArray));

                    
                    
                    break;
            }
        }

    }
}
