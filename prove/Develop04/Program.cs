using System;

class Program
{
    static void Main(string[] args)
    {
        string bwChoice = "";

        while (bwChoice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            bwChoice = Console.ReadLine();

            switch (bwChoice)
            {
                case "1":
                    BreathingActivity bwBreathing = new BreathingActivity();
                    bwBreathing.Run();
                    break;

                case "2":
                    ReflectionActivity bwReflection = new ReflectionActivity();
                    bwReflection.Run();
                    break;

                case "3":
                    ListingActivity bwListing = new ListingActivity();
                    bwListing.Run();
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}