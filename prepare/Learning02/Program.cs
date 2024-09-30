using System;

class Program
{
    static void Main(string[] args)
    {
        Job csWork = new Job();
        csWork._title = "Data Scientist";
        csWork._company = "Google";
        csWork._startYear = 2022;
        csWork._endYear = 2024;

        Job csWork2 = new Job("Apple", "Moral Support", 2019, 2021);
        
        Resume man1 = new Resume("Jimmy", [csWork,csWork2]);
        man1.Display();
    }
}