using System;
using System.Collections.Generic;

// Public class to be accessible in other parts of the program
public class ListingActivity : Activity
{
    // Private fields to store the list of prompts and a random number generator
    private List<string> _goodThingsList = new List<string>();
    private Random _random = new Random();

    // Constructor for ListingActivity with default parameters
    public ListingActivity(string activityName, string activityDescription, string activityFinalMessage) : base(activityName, activityDescription, activityFinalMessage)
    {
        // Initialize the list and random number generator
        _goodThingsList = new List<string>();
        _random = new Random();
    }

    // Getter method to retrieve all prompts in the list
    public List<string> GetAllListingPrompts()
    {
        return _goodThingsList;
    }

    // Setter method to set the list of prompts
    public void SetAllReflectionPhasesList(List<string> goodThingsPrompts)
    {
        _goodThingsList = goodThingsPrompts;
    }

    // Method to add a new prompt to the list
    public void AddPhaseToGoodThingsList(string goodThingsPrompts)
    {
        _goodThingsList.Add(goodThingsPrompts);
    }

    // Method to randomly select and return a prompt from the list
    public string GetRandomChoosenGoodThingsPrompts()
    {
        // Get a random index within the range of the list
        int indexOfList = _random.Next(_goodThingsList.Count);
        // Return the prompt at the randomly chosen index
        return _goodThingsList[indexOfList];
    }

    // Method to conduct a listing activity with a countdown
    public int GetCooldownListingActivity(int seconds, List<string> listToUsePhrases)
    {
        // Update the list of prompts to use
        _goodThingsList = listToUsePhrases;
        int original = seconds;
        // Calculate the new end time based on the original time
        DateTime newTime = DateTime.Now.AddSeconds(original);

        // Print initial messages
        Console.WriteLine("Let's start...");
        ShowSpinnerWithText(" Press enter to initiate the activity");
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine();

        // Print a random prompt from the list
        Random rand = new Random();
        Console.WriteLine($"---- {listToUsePhrases[rand.Next(listToUsePhrases.Count)]} ----");
        Console.WriteLine();

        // Countdown from 3 to 0 with text displayed
        Console.Write("You may begin in: ");
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
        Console.WriteLine();

        // Prompt the user for responses until the time runs out
        List<string> responses = new List<string>();
        while (DateTime.Now <= newTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (string.IsNullOrEmpty(response))
            {
                break;
            }
            responses.Add(response);
        }

        // Final output
        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items!");

        return original;
    }
}
