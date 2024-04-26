using System;

class Program
{
    static void Main(string[] args)
    {
        // Asking percentage
        Console.WriteLine("Please enter the percentage:");
        double percentage = Convert.ToDouble(Console.ReadLine());

        // letter grade

        char LetterGrade;
        if (percentage >= 90)
        {
            LetterGrade = 'A' ;
        }
        else if (percentage >= 80)
        {
            LetterGrade = 'B';
        }
        else if (percentage >= 70)
        {
            LetterGrade = 'C';
        }
        else if (percentage >= 60)
        {
            LetterGrade = 'D';
        }
        else
        {
            LetterGrade = 'F';
        }

        // Cheking student
        bool passed = percentage >= 70;

        Console.WriteLine($"Your letter grade is: {LetterGrade}");
        if (passed)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }

        // Stretch Challenge

        char sign = ' ';
        int LastDigit = (int)percentage % 10;
        if (LastDigit >= 7 && LetterGrade != 'F')
        {
            sign = '+';
        }
        else if (LastDigit < 3 && LetterGrade != 'F')
        {
            sign = '-';
        }

        // Adjusting

        if (LetterGrade == 'A' && sign == '-')
        {
            LetterGrade = 'B';
            sign = '-';
        }
        else if (LetterGrade == 'F')
        {
            sign = ' ';
        }

        //Priting
        Console.WriteLine($"Your letter grade with sign is : {LetterGrade}{sign}");

    }
}