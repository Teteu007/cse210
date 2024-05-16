using System;

public class Scripture
{
    // Private fields to store the words and reference of the scripture
    private List<Word> _words = new List<Word>();
    private Reference _reference;

    // Constructor to initialize the scripture with book, chapter, verse, and verse text
    public Scripture(string book, string chapter, string verse, string verseText)
    {
        // Check if the verse contains a range of verses
        if (verse.Contains("-"))
        {
            string[] multiVerse = verse.Split("-");
            _reference = new Reference(book, int.Parse(chapter), int.Parse(multiVerse[0]), int.Parse(multiVerse[1]));
        }
        else
        {
            _reference = new Reference(book, int.Parse(chapter), int.Parse(verse));
        }
        // Set the words of the scripture
        this.SetWords(verseText);
    }

    // Method to check if all words in the scripture are hidden
    public bool AllHidden()
    {
        foreach (Word word in _words)
        {
            if (word.GetVisibility())
            {
                return false;
            }
        }
        return true;
    }

    // Method to display the scripture with visible words
    public void DisplayScripture()
    {
        Console.Clear();
        Console.Write($"{GetRefrence()} -> ");
        foreach (Word word in GetWords())
        {
            Console.Write($"{word.GetWord()} ");
        }
        Console.WriteLine();
    }

    // Method to hide a certain number of words in the scripture
    public void HideWords(int wordCount = 1)
    {
        Random random = new Random();
        int randIndex = 0;
        int wordsRemoved = 0;
        do
        {
            randIndex = random.Next(0, _words.Count());
            if (_words[randIndex].GetVisibility())
            {
                _words[randIndex].Hide();
                wordsRemoved++;
            }
        }
        while (!AllHidden() && wordsRemoved != wordCount);
    }

    // Method to get the reference text of the scripture
    public string GetRefrence()
    {
        return _reference.GetReferenceText();
    }

    // Method to get the list of words in the scripture
    public List<Word> GetWords()
    {
        return _words;
    }

    // Method to set the reference of the scripture
    public void SetRefrence(Reference reference)
    {
        _reference = reference;
    }

    // Method to set the words of the scripture
    public void SetWords(string wordsString)
    {
        foreach (string word in wordsString.Split(" "))
        {
            Word newWordOBJ = new Word(word);
            _words.Add(newWordOBJ);
        }
    }
}
