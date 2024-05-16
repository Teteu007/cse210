using System;
//Public class to can use in "other window"

public class Activity
{

    //Protect class inside the propieties to not affect the working of the program (only the inherit class)
    protected string _activityName;
    protected int _activityDuration;
    protected string _activityDescription;
    protected string _finalActivityMessage;

    //----------- Constructor section (templates)--------------

    //Create a Activity
    public Activity(string activityName, string activityDescription, string activityFinalMessage)
    {
        //All the values 
        _activityName = activityName;
        _activityDescription = activityDescription;
        _finalActivityMessage = activityFinalMessage;
    }

    //------------- Constructor section - end ------------------

    //------------- (Methods - Behaviors) -----------------------
    //----------------- Getter & Setter section -----------------
    public string GetActivityName()
    {
        //See the value of _activityName
        return _activityName;
    }

    public void SetActivityName(string activityName)
    {
        //Put the value of _activityName
        _activityName = activityName;
    }

    public int GetActivityDuration()
    {
        //See the value of _activityDuration
        return _activityDuration;
    }

    public void SetActivityDuration(int activityDuration)
    {
        //Put the value of _activityDuration
        _activityDuration = activityDuration;
    }
    public string GetActivityDescription()
    {
        //See the value of _activityDescription
        return _activityDescription;
    }

    public void SetActivityDescription(string activityDescription)
    {
        //Put the value of _activityDescription
        _activityDescription = activityDescription;
    }

    public string GetFinalActivityMessage()
    {
        //See the value of _finalActivityMessage
        return _finalActivityMessage;
    }

    public void SetFinalActivityMessage(string finalActivityMessage)
    {
        //Put the value of _finalActivityMessage
        _finalActivityMessage = finalActivityMessage;
    }
    //--------------- Getter & Setter section - end -------------
    //-------------------- Methods ------------------------------
    public string GetActivityNameDisplay()
    {
        return $"Welcome to the {_activityName}.";
    }
    public string GetActivityDescriptionDisplay()
    {
        return $"{_activityDescription}";
    }
    public string GetActivityDurationDisplay()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        string duration = "0";
        string result = Console.ReadLine();
        if (!string.IsNullOrEmpty(result))
        {
            duration = result;
        }
        return duration;
    }


    public string GetFinalActivityMessageDisplay()
    {
        Console.WriteLine("Well done.");
        Console.WriteLine();
        Convert.ToString(_activityDuration);
        return $"You have completed another {_activityDuration} seconds of the {_activityName}.";
    }
    //Method to show a spinner with text
    public void ShowSpinnerWithText(string text, string position = "left")
    {
        int x = Console.CursorLeft;
        int y = Console.CursorTop;

        string[] spinnerFrames = new string[] { "| ", "/ ", "— ", "\\ " };
        int spinnerIndex = 0;

        while (true)
        {
            Console.SetCursorPosition(x, y);

            if (position == "left")
            {
                Console.Write(spinnerFrames[spinnerIndex] + text);
            }
            else if (position == "right")
            {
                Console.Write(text + " " + spinnerFrames[spinnerIndex]);
            }

            spinnerIndex = (spinnerIndex + 1) % spinnerFrames.Length;

            Thread.Sleep(400);

            if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x + text.Length, y);
                Console.Write("   ");
                Console.WriteLine();
                break;
            }
        }
    }

}