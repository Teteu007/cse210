using System;
using System.IO;
using System.Linq;

class Scripture {
    public string Reference { get; }
    public string Text { get; }
    
    public Scripture(string reference, string text) {
        Reference = reference;
        Text = text;
    }
}

class ScriptureLibrary {
    private readonly Scripture[] scriptures;

    public ScriptureLibrary(string filePath) {
        string[] lines = File.ReadAllLines(filePath);
        scriptures = new Scripture[lines.Length / 2];

        for (int i = 0, j = 0; i < lines.Length; i += 2, j++) {
            scriptures[j] = new Scripture(lines[i], lines[i + 1]);
        }
    }

    public Scripture GetRandomScripture() {
        Random rand = new Random();
        return scriptures[rand.Next(scriptures.Length)];
    }
}

class WordHider {
    private readonly string[] words;
    private readonly Random rand;

    public WordHider(string text) {
        words = text.Split(' ');
        rand = new Random();
    }

    public string HideWord() {
        int index = rand.Next(words.Length);
        string word = words[index];
        words[index] = "_".PadLeft(word.Length, '_');
        return string.Join(" ", words);
    }

    public bool AllWordsHidden() {
        return words.All(word => word.All(ch => ch == '_'));
    }
}

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Welcome to the Scripture Memorizer!");

        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture currentScripture = library.GetRandomScripture();

        Console.WriteLine($"Reference: {currentScripture.Reference}");
        Console.WriteLine(currentScripture.Text);
        Console.WriteLine("Press Enter to start memorizing or 'quit' to exit.");

        string input = Console.ReadLine();
        if (input.ToLower() == "quit") return;

        WordHider wordHider = new WordHider(currentScripture.Text);

        while (true) {
            // Print multiple blank lines to "clear" the console visually
            for (int i = 0; i < Console.WindowHeight; i++) {
                Console.WriteLine();
            }

            string hiddenText = wordHider.HideWord();
            Console.WriteLine($"Reference: {currentScripture.Reference}");
            Console.WriteLine(hiddenText);

            if (wordHider.AllWordsHidden()) {
                Console.WriteLine("Congratulations! You've hidden all the words in the scripture.");
                break;
            }

            Console.WriteLine("Press Enter to hide another word or 'quit' to exit.");
            input = Console.ReadLine();
            if (input.ToLower() == "quit") break;
        }

        Console.WriteLine("Thank you for using the Scripture Memorizer!");
    }
} 
