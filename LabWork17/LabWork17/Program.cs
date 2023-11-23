using System;

namespace LabWork17 // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        // Функція вищого порядку, яка приймає дві функції
        static Func<T1, T3> HigherOrderFunction<T1, T2, T3>(Func<T1, T2> func1, Func<T2, T3> func2)
        {
            return x => func2(func1(x));
        }

        // Приклад функції, яка додає 5 до числа
        static int AddFive(int x)
        {
            return x + 5;
        }

        // Приклад функції, яка подвоює число
        static int Double(int x)
        {
            return x * 2;
        }

        static void Main()
        { 
            Console.WriteLine("1,2,3,4, 5 - exit");
            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:
            
                    // Використовуємо функцію вищого порядку
                    var combinedFunction = HigherOrderFunction<int, int, int>(AddFive, Double);
        
                    // Тестуємо комбіновану функцію
                    int result = combinedFunction(10);
                    Console.WriteLine("Combined Function Result: " + result);
        
                    // Версія функції в форматі каррінгу
                    Func<int, int> curryFunction = Curry<int,int>(AddFive);
                    curryFunction = curryFunction.AndThen(Double);
        
                    // Тестуємо функцію в форматі каррінгу
                    int curryResult = curryFunction(10);
                    Console.WriteLine("Currying Function Result: " + curryResult);
                    break;
                case 2:
                    
            }
            
        }

        // Функція для перетворення функції в форматі каррінгу
        static Func<T1, T2> Curry<T1, T2>(this Func<T1, T2> func)
        {
            return x => func(x);
        }

        // Метод для об'єднання двох функцій
        static Func<T, TResult> AndThen<T, TIntermediate, TResult>(this Func<T, TIntermediate> func1, Func<TIntermediate, TResult> func2)
        {
            return x => func2(func1(x));
        }
    }
}   
