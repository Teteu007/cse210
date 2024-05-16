using System;

// Public class to be accessible in other parts of the program
public class BreathingActivity : Activity
{
    // Private field to store cooldown time
    private DateTime _cooldownTime;

    // Constructor with default cooldown time of 0 seconds
    public BreathingActivity(string activityName, string activityDescription, string activityFinalMessage) : base(activityName, activityDescription, activityFinalMessage)
    {
        // Initialize cooldown time to current time
        DateTime startTime = DateTime.Now;
        _cooldownTime = startTime.AddSeconds(0);
    }

    // Constructor with customizable cooldown time
    public BreathingActivity(string activityName, string activityDescription, string activityFinalMessage, int cooldownTimeActivity) : base(activityName, activityDescription, activityFinalMessage)
    {
        // Pad cooldown time string to ensure at least 3 digits
        string cooldownTimeString = cooldownTimeActivity.ToString().PadRight(3, '0');
        // Initialize cooldown time to current time plus parsed cooldown time
        DateTime startTime = DateTime.Now;
        _cooldownTime = startTime.AddSeconds(int.Parse(cooldownTimeString));
    }

    // Getter method to retrieve cooldown time
    public DateTime GetCooldown()
    {
        // Return the value of _cooldownTime
        return _cooldownTime;
    }

    // Setter method to set cooldown time
    public void SetCooldown(DateTime settedCooldown)
    {
        // Pad cooldown time string to ensure at least 3 digits
        string cooldownTimeString = settedCooldown.ToString().PadRight(3, '0');
        // Set cooldown time to current time plus parsed cooldown time
        DateTime startTime = DateTime.Now;
        _cooldownTime = startTime.AddSeconds(int.Parse(cooldownTimeString));
    }

    // Method to simulate breathing activity with a countdown
    public int GetCooldownBreatheActivity(int seconds)
    {
        Console.WriteLine("Let's start...");
        ShowSpinnerWithText(" Press enter to initiate the activity");

        const int breatheInDuration = 6;
        const int breatheOutDuration = 3;

        int remainingSeconds = seconds;
        bool isBreathingIn = true;
        while (remainingSeconds > 0)
        {
            Console.Clear();

            int countdown = isBreathingIn ? breatheInDuration : breatheOutDuration;
            string message = isBreathingIn ? "Breathe in..." : "Now breathe out...";

            while (countdown > 0 && remainingSeconds > 0)
            {
                Console.Clear();
                Console.WriteLine($"{message} {countdown}");

                Thread.Sleep(1000);

                countdown--;
                remainingSeconds--;
            }

            isBreathingIn = !isBreathingIn;
        }

        return seconds;
    }
}
