using System;

public class Reference
{
    // Private fields to store book name, chapter number, verse number, and end verse number
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a scripture reference with single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // Default value for endVerse
    }

    // Constructor for a scripture reference with a range of verses
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Method to get the textual representation of the scripture reference
    public string GetReferenceText()
    {
        // Check if the scripture reference represents a range of verses
        if (this.GetEndVerse() != 0)
        {
            return ($"{this.GetBook()} {this.GetChapter()}:{this.GetVerse()}-{this.GetEndVerse()}");
        }
        else
        {
            return ($"{this.GetBook()} {this.GetChapter()}:{this.GetVerse()}");
        }
    }

    // Getter method for the book name
    public string GetBook()
    {
        return _book;
    }

    // Getter method for the chapter number
    public int GetChapter()
    {
        return _chapter;
    }

    // Getter method for the starting verse number
    public int GetVerse()
    {
        return _verse;
    }

    // Getter method for the ending verse number
    public int GetEndVerse()
    {
        return _endVerse;
    }

    // Setter method for the book name
    public void SetBook(string book)
    {
        _book = book;
    }

    // Setter method for the chapter number
    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    // Setter method for the starting verse number
    public void SetVerse(int verse)
    {
        _verse = verse;
    }

    // Setter method for the ending verse number
    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }
}
