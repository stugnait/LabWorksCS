using System;
using System;
using Microsoft.Recognizers.Text;
using System.Collections.Generic;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.Sequence;

namespace LabWork18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choose = Convert.ToInt32(Console.ReadLine());

            for (;;)
            {
                switch (choose)
                {
                    case 1:
                        First();
                        break;
                    case 2:
                        Second();
                        break;
                    case 3:
                        Third();
                        break;
                    case 4:
                        Fourth();
                        break;
                    default:
                        Console.WriteLine("Something went wrong....");
                        break;
                }
            }
        }

        static void First()
        {
            //I have twenty-five apples and three bananas
            Console.WriteLine("Введіть текст:");
            string text = Console.ReadLine();

            List<ModelResult> results = NumberRecognizer.RecognizeNumber(text, "en-us");

            foreach (var result in results)
            {
                Console.WriteLine($"Розпізнаний текст: {result.Text}");
                Console.WriteLine($"Початковий індекс у рядку: {result.Start}");
                Console.WriteLine($"Кінцевий індекс у рядку: {result.End}");
                Console.WriteLine($"Розпізнане значення: {result.Resolution["value"]}\n");
            }
        }
        static void Second()
        {
            //The tenth book, the twenty-first ruler, and the forty-fifth pencil
            Console.WriteLine("Введіть текст:");
            string text = Console.ReadLine();

            List<ModelResult> results = NumberRecognizer.RecognizeOrdinal(text, "en-us");

            foreach (var result in results)
            {
                Console.WriteLine($"Розпізнаний текст: {result.Text}");
                Console.WriteLine($"Розпізнане значення: {result.Resolution["value"]}\n");
            }
        }
        static void Third()
        {
            //I bought a shirt for $25, the size is 10, it weighs 2 kg, the temperature is 30 degrees Celsius, and the meeting is on January 15
            Console.WriteLine("Введіть текст:");
            string text = Console.ReadLine();

            // Розпізнавання валюти
            var currencyResults = NumberWithUnitRecognizer.RecognizeCurrency(text, "en-us");
            PrintResults("Валюта", currencyResults);

            // Розпізнавання розміру, ваги, відстані, маси
            var dimensionResults = NumberWithUnitRecognizer.RecognizeDimension(text, "en-us");
            PrintResults("Розмір, вага, відстань, маса", dimensionResults);

            // Розпізнавання температури
            var temperatureResults = NumberWithUnitRecognizer.RecognizeTemperature(text, "en-us");
            PrintResults("Температура", temperatureResults);

            // Розпізнавання дати і часу
            var dateTimeResults = DateTimeRecognizer.RecognizeDateTime(text, "en-us");
            PrintResults("Дата і час", dateTimeResults);
        }
        static void PrintResults(string category, List<ModelResult> results)
        {
            Console.WriteLine($"Результати розпізнавання для {category}:");
            foreach (var result in results)
            {
                Console.WriteLine($"Розпізнаний текст: {result.Text}");
                Console.WriteLine($"Початковий індекс у рядку: {result.Start}");
                Console.WriteLine($"Кінцевий індекс у рядку: {result.End}");
                Console.WriteLine($"Розпізнане значення: {result.Resolution["value"]}\n");
            }
        }
        static void Fourth()
        {
            //My phone number is +1 (123) 456-7890, my IP address is 192.168.1.1, my email is example@email.com, my website is http://www.example.com, and I love #programming
            Console.WriteLine("Введіть текст:");
            string text = Console.ReadLine();

            // Розпізнавання номера телефону
            var phoneNumberResults = SequenceRecognizer.RecognizePhoneNumber(text, "en-us");
            PrintResults4("Номер телефону", phoneNumberResults);

            // Розпізнавання IP-адреси
            var ipAddressResults = SequenceRecognizer.RecognizeIpAddress(text, "en-us");
            PrintResults4("IP-адреса", ipAddressResults);

            // Розпізнавання адреси електронної пошти
            var emailResults = SequenceRecognizer.RecognizeEmail(text, "en-us");
            PrintResults4("Email", emailResults);

            // Розпізнавання URL-адреси
            var urlResults = SequenceRecognizer.RecognizeURL(text, "en-us");
            PrintResults4("URL", urlResults);

            // Розпізнавання хеш-тегу
            var hashtagResults = SequenceRecognizer.RecognizeHashtag(text, "en-us");
            PrintResults4("Хеш-тег", hashtagResults);
        }
        
        
        static void PrintResults4(string category, List<ModelResult> results)
        {
            Console.WriteLine($"Результати розпізнавання для {category}:");
            foreach (var result in results)
            {
                Console.WriteLine($"Розпізнаний текст: {result.Text}");
                Console.WriteLine($"Розпізнане значення: {result.Resolution["value"]}\n");
            }
        }
    }
        
    

}