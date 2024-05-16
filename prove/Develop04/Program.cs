using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime start = DateTime.Now;
        bool quitProgramm = false;
        while (quitProgramm != true)

        {
            Console.Clear();
            Console.WriteLine($"Current session started at {start.ToString("HH:mm:ss")}");
            TimeSpan elapsedTime = DateTime.Now - start;

            /* Function to calculate the time used in the activity */
            string elapsedHours = ((int)elapsedTime.TotalHours).ToString("00");
            string elapsedMinutes = elapsedTime.Minutes.ToString("00");
            string elapsedSeconds = elapsedTime.Seconds.ToString("00");
            string elapsedTimeString = $"{elapsedHours}:{elapsedMinutes}:{elapsedSeconds}";
            Console.WriteLine($"Elapsed time: {elapsedTimeString}");

            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select a choise from the menu: ");
            string option = Console.ReadLine();

            switch (option)
            {
                //1. Start breathing activity
                case "1":
                    Console.Clear();
                    //------------------------------ User decide for Breathe Activity -----------------------
                    BreathingActivity breatheActivity = new("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", "Final Message");
                    //Display the started Breathing Activity menu (name & description)
                    Console.WriteLine(breatheActivity.GetActivityNameDisplay());
                    Console.WriteLine();
                    Console.WriteLine(breatheActivity.GetActivityDescriptionDisplay());
                    Console.WriteLine();
                    string durationStringBreathe = breatheActivity.GetActivityDurationDisplay();
                    int durationNumberBreathe = int.Parse(durationStringBreathe);
                    //Save the variable as a copy (to use the cooldown without affect the original)
                    int copyOfDurationBA = durationNumberBreathe;
                    Console.Clear();
                    breatheActivity.GetCooldownBreatheActivity(copyOfDurationBA);
                    //Final output (reset the value of the activity's duration)
                    breatheActivity.SetActivityDuration(durationNumberBreathe);
                    Console.WriteLine(breatheActivity.GetFinalActivityMessageDisplay());
                    breatheActivity.ShowSpinnerWithText("");
                    Console.Clear();
                    //------------------------------ User decide for Breathe Activity -----------------------


                    break;

                //2. Start reflecting activity
                case "2":
                    Console.Clear();
                    //------------------------------ User decide for Reflection Activity --------------------
                    ReflectionActivity reflectionActivity = new("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", "Final Message");
                    //Create a list to save the phases, then choose one random
                    ReflectionActivity phrasesReflectionList = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", "Final Message");
                    phrasesReflectionList.AddPhaseToList("Think of a time when you stood up for someone else.");
                    phrasesReflectionList.AddPhaseToList("Think of a time when you did something really difficult.");
                    phrasesReflectionList.AddPhaseToList("Think of a time when you helped someone in need.");
                    phrasesReflectionList.AddPhaseToList("Think of a time when you did something truly selfless.");
                    //List to save the phrases into.
                    List<string> listaToUsePhrases = new List<string> { };
                    listaToUsePhrases.AddRange(phrasesReflectionList.GetAllReflectionPhases());
                    //Create a list to save the questions, then
                    ReflectionActivity questionsReflectionList = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", "Final Message");
                    questionsReflectionList.AddPhaseToList("Why was this experience meaningful to you?");
                    questionsReflectionList.AddPhaseToList("Have you ever done anything like this before?");
                    questionsReflectionList.AddPhaseToList("How did you get started?");
                    questionsReflectionList.AddPhaseToList("How did you feel when it was complete?");
                    questionsReflectionList.AddPhaseToList("What made this time different than other times when you were not as successful?");
                    questionsReflectionList.AddPhaseToList("What is your favorite thing about this experience?");
                    questionsReflectionList.AddPhaseToList("What could you learn from this experience that applies to other situations?");
                    questionsReflectionList.AddPhaseToList("What did you learn about yourself through this experience?");
                    questionsReflectionList.AddPhaseToList("How can you keep this experience in mind in the future?");
                    //List to save the phrases into.
                    List<string> listaToUseQuestions = new List<string> { };
                    listaToUseQuestions.AddRange(questionsReflectionList.GetAllReflectionPhases());

                    //Display the started Breathing Activity menu (name & description)
                    Console.WriteLine(reflectionActivity.GetActivityNameDisplay());
                    Console.WriteLine();
                    Console.WriteLine(reflectionActivity.GetActivityDescriptionDisplay());
                    Console.WriteLine();
                    string durationStringReflection = reflectionActivity.GetActivityDurationDisplay();
                    int durationNumberReflection = int.Parse(durationStringReflection);
                    //Save the variable as a copy (to use the cooldown without affect the original)
                    int copyOfDurationRA = durationNumberReflection;
                    reflectionActivity.GetCooldownReflectionActivity(copyOfDurationRA, listaToUsePhrases, listaToUseQuestions);
                    Console.WriteLine();
                    //Final output (reset the value of the activity's duration)
                    reflectionActivity.SetActivityDuration(durationNumberReflection);
                    Console.WriteLine(reflectionActivity.GetFinalActivityMessageDisplay());
                    reflectionActivity.ShowSpinnerWithText("");
                    Console.Clear();
                    //------------------------------ User decide for Reflection Activity --------------------
                    break;

                //3. Start listing activity
                case "3":
                    Console.Clear();
                    //------------------------------ User decide for Listing Activity -----------------------
                    ListingActivity listingActivity = new("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Final Message");
                    //Create a list to save the phases, then choose one random
                    ListingActivity listingGoodThingsPrompts = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Final Message");
                    listingGoodThingsPrompts.AddPhaseToGoodThingsList("Who are people that you appreciate? ");
                    listingGoodThingsPrompts.AddPhaseToGoodThingsList("What are personal strengths of yours? ");
                    listingGoodThingsPrompts.AddPhaseToGoodThingsList("Who are people that you have helped this week? ");
                    listingGoodThingsPrompts.AddPhaseToGoodThingsList("When have you felt the Holy Ghost this month? ");
                    listingGoodThingsPrompts.AddPhaseToGoodThingsList("Who are some of your personal heroes? ");
                    //List to save the prompts into.
                    List<string> listaToUseQuestionPromps = new List<string> { };
                    listaToUseQuestionPromps.AddRange(listingGoodThingsPrompts.GetAllListingPrompts());

                    //Display the started Breathing Activity menu (name & description)
                    Console.WriteLine(listingActivity.GetActivityNameDisplay());
                    Console.WriteLine();
                    Console.WriteLine(listingActivity.GetActivityDescriptionDisplay());
                    Console.WriteLine();
                    string durationStringListing = listingActivity.GetActivityDurationDisplay();
                    int durationNumberListing = int.Parse(durationStringListing);
                    //Save the variable as a copy (to use the cooldown without affect the original)
                    int copyOfDurationLA = durationNumberListing;
                    listingActivity.GetCooldownListingActivity(copyOfDurationLA, listaToUseQuestionPromps);
                    Console.WriteLine();
                    //Final output (reset the value of the activity's duration)
                    listingActivity.SetActivityDuration(durationNumberListing);
                    listingActivity.ShowSpinnerWithText("");
                    Console.WriteLine(listingActivity.GetFinalActivityMessageDisplay());
                    listingActivity.ShowSpinnerWithText("");
                    Console.Clear();
                    //------------------------------ User decide for Listing Activity -----------------------
                    break;

                //4. Quit
                case "4":
                    //---------------------------- User decide for finish the program -----------------------
                    quitProgramm = true;
                    DateTime end = DateTime.Now;
                    //Display the final message with the time used in the program (since the beggining to the end)
                    Console.Clear();
                    Console.WriteLine($"Current session started at {start.ToString("HH:mm:ss")}");
                    Console.WriteLine($"Current session end at {end.ToString("HH:mm:ss")}");
                    Console.WriteLine($"Elapsed time: {elapsedTimeString}");
                    Console.WriteLine();
                    //---------------------------- User decide for finish the program -----------------------
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong. Please try again. ");
                    break;

            }
        }


    }
}