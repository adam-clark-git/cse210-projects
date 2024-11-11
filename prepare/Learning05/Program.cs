using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        List<Shape> shapeList = [new Circle(2, "blue"), new Rectangle(5, 10, "red"), new Square(3, "purple"), new Shape("green")];
        foreach (Shape currentShape in shapeList)
        {
            Console.WriteLine(currentShape.GetColor());
            Console.WriteLine(currentShape.GetArea() + "\n");
        }

    }
}