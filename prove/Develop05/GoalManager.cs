using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> bwGoals;
    private int bwScore;

    public GoalManager()
    {
        bwGoals = new List<Goal>();
        bwScore = 0;
    }

    public void Start()
    {
        bool bwQuit = false;
        while (!bwQuit)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string bwChoice = Console.ReadLine();

            switch (bwChoice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": bwQuit = true; break;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int bwLevel = (bwScore / 1000) + 1;
        string bwTitle = "Novice";
        if (bwLevel >= 13) bwTitle = "Ninja Unicorn";
        else if (bwLevel >= 10) bwTitle = "Jedi Master";
        else if (bwLevel >= 7) bwTitle = "Champion";
        else if (bwLevel >= 4) bwTitle = "Disciple";

        Console.WriteLine($"\nYou have {bwScore} points.");
        Console.WriteLine($"Rank: Level {bwLevel} {bwTitle}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int bwI = 0; bwI < bwGoals.Count; bwI++)
        {
            Console.WriteLine($"  {bwI + 1}. {bwGoals[bwI].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int bwI = 0; bwI < bwGoals.Count; bwI++)
        {
            Console.WriteLine($"  {bwI + 1}. {bwGoals[bwI].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bad Habit)");
        Console.Write("Which type of goal would you like to create? ");
        string bwType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string bwName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string bwDesc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string bwPoints = Console.ReadLine();

        if (bwType == "1")
        {
            bwGoals.Add(new SimpleGoal(bwName, bwDesc, bwPoints));
        }
        else if (bwType == "2")
        {
            bwGoals.Add(new EternalGoal(bwName, bwDesc, bwPoints));
        }
        else if (bwType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int bwTarget = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bwBonus = int.Parse(Console.ReadLine());
            bwGoals.Add(new ChecklistGoal(bwName, bwDesc, bwPoints, bwTarget, bwBonus));
        }
        else if (bwType == "4")
        {
            bwGoals.Add(new NegativeGoal(bwName, bwDesc, bwPoints));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int bwIndex) && bwIndex > 0 && bwIndex <= bwGoals.Count)
        {
            Goal bwGoal = bwGoals[bwIndex - 1];
            bwGoal.RecordEvent();
            
            if (bwGoal is NegativeGoal)
            {
                bwScore -= bwGoal.GetPoints();
                Console.WriteLine($"Oh no! You lost {bwGoal.GetPoints()} points.");
            }
            else
            {
                int bwEarned = bwGoal.GetPoints();
                
                if (bwGoal is ChecklistGoal bwChecklist && bwChecklist.IsComplete())
                {
                    bwEarned += bwChecklist.GetBonus();
                }
                
                bwScore += bwEarned;
                Console.WriteLine($"Congratulations! You have earned {bwEarned} points!");
            }
            Console.WriteLine($"You now have {bwScore} points.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string bwFilename = Console.ReadLine();

        using (StreamWriter bwOutputFile = new StreamWriter(bwFilename))
        {
            bwOutputFile.WriteLine(bwScore);
            foreach (Goal bwGoal in bwGoals)
            {
                bwOutputFile.WriteLine(bwGoal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string bwFilename = Console.ReadLine();

        if (File.Exists(bwFilename))
        {
            bwGoals.Clear();
            string[] bwLines = File.ReadAllLines(bwFilename);
            bwScore = int.Parse(bwLines[0]);

            for (int bwI = 1; bwI < bwLines.Length; bwI++)
            {
                string[] bwParts = bwLines[bwI].Split(':');
                string bwType = bwParts[0];
                string[] bwDetails = bwParts[1].Split(',');

                if (bwType == "SimpleGoal")
                {
                    SimpleGoal bwSg = new SimpleGoal(bwDetails[0], bwDetails[1], bwDetails[2]);
                    if (bool.Parse(bwDetails[3])) bwSg.RecordEvent();
                    bwGoals.Add(bwSg);
                }
                else if (bwType == "EternalGoal")
                {
                    bwGoals.Add(new EternalGoal(bwDetails[0], bwDetails[1], bwDetails[2]));
                }
                else if (bwType == "ChecklistGoal")
                {
                    ChecklistGoal bwCg = new ChecklistGoal(bwDetails[0], bwDetails[1], bwDetails[2], int.Parse(bwDetails[4]), int.Parse(bwDetails[5]));
                    bwCg.SetAmountCompleted(int.Parse(bwDetails[3]));
                    bwGoals.Add(bwCg);
                }
                else if (bwType == "NegativeGoal")
                {
                    bwGoals.Add(new NegativeGoal(bwDetails[0], bwDetails[1], bwDetails[2]));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
