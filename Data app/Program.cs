using System;
using System.Collections.Generic;
using System.IO;

class TextDatabase
{
    static List<string> textData = new List<string>();
    static string filePath = "textDatabase.txt";
    static string adminPassword = "QAZX1"; 


    static void Main()
    {
        LoadDataFromFile();

        while (true)
        {
            
            Console.WriteLine("1. Add Text");
            Console.WriteLine("");
            Console.WriteLine("2. View All Texts");
            Console.WriteLine("");
            Console.WriteLine("3. Clear All Texts (Password Required)");
            Console.WriteLine("");
            Console.WriteLine("4. Exit");

            

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    AddText();
                    break;
                case 2:
                    ViewAllTexts();
                    break;
                case 3:
                    ClearAllTexts();
                    break;
                case 4:
                    SaveDataToFile();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    Console.WriteLine("");
                    break;
            }
        }
    }

    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.WriteLine("");
            Console.Clear();
        }
        return choice;
    }

    static void AddText()
    {
        Console.WriteLine("Enter text:");
        Console.WriteLine("");
        string input = Console.ReadLine();
        textData.Add(input);
        Console.WriteLine("Text added successfully!");
        Console.WriteLine("");
        Console.Clear();
    }

    static void ViewAllTexts()
    {
        Console.Clear();
        Console.WriteLine("All Texts:");
        Console.WriteLine("");
        foreach (var text in textData)
        {
            Console.WriteLine(text);
            Console.WriteLine("");
        }
    }

    static void ClearAllTexts()
    {
        Console.WriteLine("Enter password to clear all texts:");
        Console.WriteLine("");
        string password = Console.ReadLine();

        if (password == adminPassword)
        {
            textData.Clear();
            Console.WriteLine("All texts cleared successfully!");
            Console.WriteLine("");
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Incorrect password.");
            Console.WriteLine("");
        }
    }

    static void LoadDataFromFile()
    {
        if (File.Exists(filePath))
        {
            textData = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SaveDataToFile()
    {
        File.WriteAllLines(filePath, textData);
        Console.WriteLine("Data saved to file.");
        Console.WriteLine("");
        Console.Clear();
    }
}
