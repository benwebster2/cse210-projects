using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        string choice = "";

        Console.WriteLine("What's up? Start writing in your journal!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What do you want to do? ");
            choice = Console.ReadLine();

            if (choice == "1") 
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                
                newEntry._prompt = prompt;
                newEntry._entry = response;

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2") 
            {
                Console.WriteLine();
                theJournal.DisplayAll();
            }
            else if (choice == "3") 
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4") 
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
        }

        Console.WriteLine("Goodbye!");
    }
}