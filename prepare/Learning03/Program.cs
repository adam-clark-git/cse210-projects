using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("");
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(2);
        Fraction frac3 = new Fraction(2,3);
        frac1.setDenominator(5);
        frac1.setNumerator(8);
        frac2.getDenominator();
        frac2.getNumerator();
        Console.WriteLine(frac3.GetDecimalValue() + "\n" + frac3.GetFractionString());
        Console.WriteLine(frac2.GetFractionString() + "\n" + frac2.GetDecimalValue());
        Console.WriteLine(frac1.GetDecimalValue() + "\n" + frac1.GetFractionString());
    }
}