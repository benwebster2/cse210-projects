using System;

class Program
{
    static void Main(string[] args)
    {
        Journal bwTheJournal = new Journal();
        PromptGenerator bwPromptGen = new PromptGenerator();
        string bwChoice = "";

        while (bwChoice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? "); 
            bwChoice = Console.ReadLine();

            if (bwChoice == "1") 
            {
                string bwPrompt = bwPromptGen.GetRandomPrompt();
                Console.WriteLine(bwPrompt);
                Console.Write("> "); 
                string bwResponse = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry.bwDate = DateTime.Now.ToShortDateString();
                newEntry.bwPrompt = bwPrompt;
                newEntry.bwEntryText = bwResponse;

                bwTheJournal.AddEntry(newEntry);
            }
            else if (bwChoice == "2") 
            {
                bwTheJournal.DisplayAll(); 
            }
            else if (bwChoice == "3") 
            {
                Console.WriteLine("What is the filename?");
                Console.Write(" "); 
                string bwFileName = Console.ReadLine();
                bwTheJournal.LoadFromFile(bwFileName);
            }
            else if (bwChoice == "4") 
            {
                Console.WriteLine("What is the filename?");
                Console.Write(" ");
                string bwFileName = Console.ReadLine();
                bwTheJournal.SaveToFile(bwFileName);
            }
        }
    }
}