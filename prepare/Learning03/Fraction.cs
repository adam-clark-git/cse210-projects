using System;

class Fraction
{
    private int _Numerator;
    private int _Denominator;
    public Fraction()
    {
        _Numerator = 1;
        _Denominator = 1;
    }
    public Fraction(int numerator)
    {
        _Numerator = numerator;
        _Denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _Numerator = numerator;
        _Denominator = denominator;
    }

    public int getNumerator()
    {
        return _Numerator;
    }
    public void setNumerator(int numerator)
    {
        _Numerator = numerator;
    }

    public int getDenominator()
    {
        return _Denominator;
    }
    public void setDenominator(int denominator)
    {
        _Denominator = denominator;
    }


    public double GetDecimalValue()
    {
        return (double) _Numerator / _Denominator;
    }
    public String GetFractionString()
    {
        return (_Numerator + "/" +  _Denominator);
    }

}