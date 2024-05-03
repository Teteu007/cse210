using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void WriteNewEntry()
    {
        Console.WriteLine("Write a new entry:");
        Random rnd = new Random();
        string[] prompts = {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could do one thing today, what would it be?",
            "How did you handle an emotional challenge today?",
            "Were there any moments of gratitude you experienced today?",
            "Did you feel inspired by something or someone today?",
            "Is there anything you're looking forward to doing tomorrow?"

        };
        string prompt = prompts[rnd.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        entries.Add(new JournalEntry { Prompt = prompt, Response = response, Date = DateTime.Now });
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date.ToShortDateString()}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournal(string fileName)
    {
        if (Path.GetExtension(fileName).ToLower() == ".csv")
            SaveAsCSV(fileName);
        else
            Console.WriteLine("Unsupported file format. Please use the .csv extension.");
    }

    private void SaveAsCSV(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Date,Prompt,Response");
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date.ToShortDateString()},\"{entry.Prompt}\",\"{entry.Response}\"");
                }
            }
            Console.WriteLine("Journal saved successfully in CSV format!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the Journal: {ex.Message}");
        }
    }

    public void LoadJournal(string fileName)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    DateTime date = DateTime.Parse(parts[0].Trim());
                    string prompt = parts[1].Trim().Trim('"');
                    string response = parts[2].Trim().Trim('"');
                    entries.Add(new JournalEntry { Prompt = prompt, Response = response, Date = date });
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("That file does not exist. Please enter the name of an existing file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the Journal: {ex.Message}");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Journal Journal = new Journal();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save the Journal to a file");
            Console.WriteLine("4. Load the Journal from a file");
            Console.WriteLine("5. Exit");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid option. Please choose a valid option.");
            }

            switch (choice)
            {
                case 1:
                    Journal.WriteNewEntry();
                    break;
                case 2:
                    Journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter the file name to save to: ");
                    string saveFileName = Console.ReadLine();
                    Journal.SaveJournal(saveFileName);
                    break;
                case 4:
                    string loadFileName;
                    do
                    {
                        Console.Write("Enter the file name to load from: ");
                        loadFileName = Console.ReadLine();
                        Journal.LoadJournal(loadFileName);
                    } while (!File.Exists(loadFileName));
                    break;
                case 5:
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That option does not exist. Please enter an existing option.");
                    break;
            }
        }
    }
}
