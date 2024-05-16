using System;
using System.Collections.Generic;
using System.Threading;

// Public class to be accessible in other parts of the program
public class ReflectionActivity : Activity
{
    // Private fields to store the list of phrases and a random number generator
    private List<string> _listOfPhrases = new List<string>();
    private Random _random = new Random();

    // Constructor for ReflectionActivity with default parameters
    public ReflectionActivity(string activityName, string activityDescription, string activityFinalMessage) : base(activityName, activityDescription, activityFinalMessage)
    {
        // Initialize the list and random number generator
        _listOfPhrases = new List<string>();
        _random = new Random();
    }

    // Getter method to retrieve all phrases in the list
    public List<string> GetAllReflectionPhases()
    {
        return _listOfPhrases;
    }

    // Setter method to set the list of phrases
    public void SetAllReflectionPhasesList(List<string> phase)
    {
        _listOfPhrases = phase;
    }

    // Method to add a new phrase to the list
    public void AddPhaseToList(string phase)
    {
        _listOfPhrases.Add(phase);
    }

    // Method to randomly select and return a phrase from the list
    public string GetRandomChoosenPhrase()
    {
        // Get a random index within the range of the list
        int indexOfList = _random.Next(_listOfPhrases.Count);
        // Return the phrase at the randomly chosen index
        return _listOfPhrases[indexOfList];
    }

    // Method to conduct a reflection activity with a countdown
    public int GetCooldownReflectionActivity(int seconds, List<string> listToUsePhrases, List<string> listaToUseQuestions)
    {
        // Update the list of phrases to use
        _listOfPhrases = listToUsePhrases;
        int original = seconds;
        DateTime newTime = DateTime.Now.AddSeconds(original);

        // Print initial messages
        Console.WriteLine("Let's start...");
        ShowSpinnerWithText(" Press enter to initiate the activity");
        Console.Clear();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();

        // Print a random phrase from the list
        Random rand = new Random();
        int index = rand.Next(0, listToUsePhrases.Count);
        Console.WriteLine($"---- {listToUsePhrases[index]} ----");

        // Ask user to start the reflection activity
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press 'Enter' to continue.");
        Console.Write("");
        string enterKey = Console.ReadLine();

        // If the user presses 'Enter'
        if (enterKey == "")
        {
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");

            // Countdown from 3 to 0 with text in the left
            for (int i = 3; i > 0; i--)
            {
                Console.Write($"\rYou may begin in: {i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            // Loop through each question
            foreach (string question in listaToUseQuestions)
            {
                // Print the question
                Console.WriteLine(question);

                // Check if time is up
                if (DateTime.Now >= newTime)
                {
                    break;
                }
            }
        }

        return original;
    }
}
