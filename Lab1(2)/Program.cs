using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Program {

    static void Main() {
        StartsTask1();
        StartsTask2();
        StartsTask3();
    }
    static int CorrectValue() {
        while (true) {
            string stringValue = Console.ReadLine();
            int parsedValue;
            bool result = int.TryParse(stringValue, out parsedValue);
            if (result == true) {
                return parsedValue;
            }
            else {
                Console.WriteLine("Помилка! Спробуйте ще раз!");
            }
        }
    }

    static void StartsTask1() { 
        Console.WriteLine("Завдання №1");
        Console.WriteLine("Введіть кількість елементів у рядку:");
        int elements = CorrectValue();
        Console.WriteLine("Введіть загальну кількість елементів:");
        int allElements = CorrectValue();
        List<int> elementsList = new List<int>();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Список по спиралі має вигляд:");
        for (int i = 0; i < allElements; i++) {
            elementsList.Add(i);
        }

        for (int i = 0; i < elementsList.Count; i += elements) {
            int startElement = i;
            int endElement = Math.Min(i + elements, elementsList.Count);

            if (i / elements % 2 == 1) {
                for (int j = endElement - 1; j >= startElement; j--) {
                    Console.Write(elementsList[j] + " ");
                }
            }
            else {
                for (int j = startElement; j < endElement; j++) {
                    Console.Write(elementsList[j] + " ");
                }
            }
            Console.WriteLine();
        }

    }

    static void StartsTask2() {
        Console.Clear();
        Console.WriteLine("Завдання №2");
        string jsonDictionary = @"[{ 'id': 1, 'success': true, 'name': 'Oleh' }, { 'id': 2, 'success': false, 'name': 'Roma' }, { 'id': 3, 'success': true, 'name': 'Sasha' }]";
        Console.WriteLine("Вхідний словник має вигляд:");
        Console.WriteLine(jsonDictionary);
        List<Dictionary<string, object>> peoplesList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonDictionary);
        int count = 0;

        foreach (var i in peoplesList) {
            if (i.ContainsKey("success") && (bool)i["success"]) {
                count++;
            }
        }
        Console.WriteLine(jsonDictionary);
        Console.WriteLine("Кількість словників, що мають в собі success==true: " + count);
        Console.ReadKey();
    }

    static void StartsTask3() {
        Console.WriteLine("Завдання №3");
        int[] numbers = { 3, 7, 5, 5, 6, 8, 11, 3, 1, 1, 5 };

        var result = numbers.Where(x => x % 2 != 0)
                            .Distinct();
        
        foreach (int number in result) {
            Console.Write(number + " ");
        }
    }
}