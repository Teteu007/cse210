using System;
//Public class to can use in "other window"
public class CheckListGoal : Goal // SimpleGoal child class of Goal
{
    //Protect class inside the propieties to not affect the working of the program (only the inherit class)
    //Protect class inside the propieties to not affect the working of the program (only the inherit class)
    //protected string _title;
    //protected string _description;
    //protected int _pointsToComplete;
    //protected List<string> _listOfGoals = new List<string>();

    //This class propieties
    private int _currentlyCounter;
    private int _verificationCounter;
    private int _bonusGoalCompleted;
    private bool _checked = false;

    //------------------ Constructors section (templates)--------------

    //The default CheckList when we create (all the parameters from Goal)
     public CheckListGoal(string goalName, string goalDescription, int pointsArchieved, int verificationCounter, int bonusGoalCompleted, int currentCounter = 0, bool Goalchecked = false) : base(goalName, goalDescription, pointsArchieved)
    {
        //The normal propieties, the check-counter and the bonus when complete the goal
        _title = goalName;
        _description = goalDescription;
        _pointsToComplete = pointsArchieved;
        _verificationCounter = verificationCounter;
        _bonusGoalCompleted = bonusGoalCompleted;
        _currentlyCounter = currentCounter;
        _checked = Goalchecked;
    }
    //----------- Constructors section (templates)--------------
    //------------- (Methods - Behaviors) -----------------------
    //----------------- Getter & Setter section -----------------
    public int GetVerificationCounter()
    {
        return _verificationCounter;
    }
    public void SetVerificationCounter(int verificationCounterToSet)
    {
        _verificationCounter = verificationCounterToSet;
    }
    public int GetBonusGoalCompleted()
    {
        return _bonusGoalCompleted;
    }
    public void SetBonusGoalCompleted(int bonusGoalCompletedToSet)
    {
        _bonusGoalCompleted = bonusGoalCompletedToSet;

    }
    public int GetCurrentlyCounter()
    {
        return _currentlyCounter;
    }
    public void SetCurrentlyCounter(int currenlyCounterToSet)
    {
        _currentlyCounter = currenlyCounterToSet;

    }      //----------------- Getter & Setter section -----------------
    //-------------------------- Methods ------------------------------

    // Override auto-implemented property with ordinary property
    // to provide specialized accessor behavior.

    //Method to set this value to a list
    public override string GetGoalInformation()
    {
        if (_checked)
        {
            return $"[X] {_title} ({_description}) -- Currently completed {GetCurrentlyCounter()}/{_verificationCounter}";
        }
        else
        {
            return $"[ ] {_title} ({_description}) -- Currently completed {GetCurrentlyCounter()}/{_verificationCounter}";
        }
    }

    //Method to remplace the other information when the user complete 
    //Add the points to the total
    public override int GetGoalCompleted(int userPoints)
    {
        //For each "check" +1 to the counter
        _currentlyCounter = _currentlyCounter + 1;
        int currentCounter = _currentlyCounter;
        SetCurrentlyCounter(currentCounter);

        string goalInformation = GetGoalInformation();
        //$"[ ] {_title} ({_description}) -- Currently completed {GetCurrentlyCounter()}/{_verificationCounter}"

        int index = _listOfGoals.IndexOf(goalInformation);
        string newGoalInformation;

        //When the counter is the same to the final check-counter
        if (_currentlyCounter == _verificationCounter)
        {
            //Change checked to true
            _checked = true;
            newGoalInformation = GetGoalInformation();

            //Add the bonus to the user's points
            userPoints = userPoints + _bonusGoalCompleted;
            //userPoints is the global variable userPoints
            userPoints = userPoints + _pointsToComplete;
        }
        else if (_currentlyCounter > _verificationCounter)
        {
            _currentlyCounter = _currentlyCounter - 1;
        }
        else
        {
            newGoalInformation = goalInformation;
            //$"[ ] {_title} ({_description}) -- Currently completed {GetCurrentlyCounter()}/{_verificationCounter}"
            //userPoints is the global variable userPoints
            userPoints = userPoints + _pointsToComplete;
        }

        return userPoints;

    }

    //Method to convert the object in a string (to save in an external file)
    public override string GetStringRepresentation()
    {
        return "CheckListGoal:" + _title + "," + _description + "," + _pointsToComplete + "," + _verificationCounter + "," + _bonusGoalCompleted + "," + _currentlyCounter;
    }
}