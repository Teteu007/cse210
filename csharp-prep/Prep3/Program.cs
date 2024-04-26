using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        do
        {
            // Generate a random number 
            int magicNumber = random.Next(1, 101);
            int guess;
            int attempts = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

            // loop
            do
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            // Informing the user of the number
            Console.WriteLine($"It took you {attempts} attempts to guess the magic number.");

            // Asking
            Console.Write("Do you want to play again? (yes/no): ");
        } while (Console.ReadLine().ToLower() == "yes");
    }
}