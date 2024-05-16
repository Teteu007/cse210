using System;

public class Word
{
    // Private fields to store the word and its visibility status
    private string _word;
    private bool _visibility;

    // Private constructor to prevent instantiation without parameters
    private Word()
    {
        _word = null; // Default word value
        _visibility = true; // Default visibility status
    }

    // Constructor with parameters to initialize word and visibility
    public Word(string word, bool visibility = true)
    {
        _word = word;
        _visibility = visibility;
    }

    // Method to hide the word by setting visibility to false and replacing with underscores
    public void Hide()
    {
        _visibility = false;
        // Replace characters with underscores based on punctuation
        string blanks = new string('_', _word.Length);
        _word = _word.EndsWith(".") ? blanks = blanks.Remove(0, 1) + ".":
                _word.EndsWith(",") ? blanks = blanks.Remove(0, 1) + ",":
                _word.EndsWith(":") ? blanks = blanks.Remove(0, 1) + ":":
                _word.EndsWith(";") ? blanks = blanks.Remove(0, 1) + ";":
                blanks;
    }

    // Getter method for retrieving the word
    public string GetWord()
    {
        return _word;
    }

    // Getter method for retrieving the visibility status
    public bool GetVisibility()
    {
        return _visibility;
    }

    // Setter method for setting the word
    public void SetWord(string word)
    {
        _word = word;
    }

    // Setter method for setting the visibility status
    public void SetVisibility(bool visibility)
    {
        _visibility = visibility;
    }
}
