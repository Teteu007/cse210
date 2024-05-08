using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator != 0)
            this.denominator = denominator;
        else
            Console.WriteLine("Denominator cannot be zero.");
    }

    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator != 0)
            this.denominator = denominator;
        else
            Console.WriteLine("Denominator cannot be zero.");
    }

    public string GetFractionString()
    {
        return numerator + "/" + denominator;
    }

    public double GetDecimalValue()
    {
        double result = (double)numerator / denominator;
        // Arredonda o resultado para 2 casas decimais
        result = Math.Round(result, 2);
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();       // 1/1
        Fraction fraction2 = new Fraction(5);      // 5/1
        Fraction fraction3 = new Fraction(3, 4);   // 3/4
        Fraction fraction4 = new Fraction(1, 3);   // 1/3

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}
