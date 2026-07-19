using System;
using System.Collections.Generic;

class Character
{
    protected string bwName;
    protected int bwResolvePoints;

    public Character(string bwCharacterName)
    {
        bwName = bwCharacterName;
        bwResolvePoints = 100;
    }

    public string GetName()
    {
        return bwName;
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"-> [{bwName}] Current Resolve Stamina: {bwResolvePoints}/100");
    }

    public virtual void HandleCrisis(string bwCrisisType)
    {
        Console.WriteLine($"{bwName} prepares baseline defensive countermeasures for: {bwCrisisType}.");
    }

    public virtual void PerformRestoration()
    {
        bwResolvePoints = 100;
        Console.WriteLine($"[{bwName}] Emergency rest protocols complete. Systems refreshed.");
    }
}

class Soldier : Character
{
    public Soldier(string bwCharacterName) : base(bwCharacterName) { }

    public override void HandleCrisis(string bwCrisisType)
    {
        if (bwCrisisType == "AMBUSH")
        {
            bwResolvePoints -= 25;
            Console.WriteLine($"[{bwName}] readies her fragment weapon and takes cover behind whatever is close by. Trying to stay calm, she'll wait for her enemy to make the first move.");
        }
        else if (bwCrisisType == "STORM")
        {
            bwResolvePoints -= 10;
            Console.WriteLine($"[{bwName}] knows that since Winter is in charge of piloting the ship, she needs to take hold of the guns and shoot anything about to hit the Forager.");
        }
        else if (bwCrisisType == "INFILTRATION")
        {
            bwResolvePoints -= 15;
            Console.WriteLine($"[{bwName}] had infilatred a Reap Cycle base before, but she never did so by disguising herself as one of them. She tried to not look suspicious and emulated the patterns of Covrusites she had seen before.");
        }
    }
}

class Hunter : Character
{
    public Hunter(string bwCharacterName) : base(bwCharacterName) { }

    public override void HandleCrisis(string bwCrisisType)
    {
        if (bwCrisisType == "AMBUSH")
        {
            bwResolvePoints -= 5;
            Console.WriteLine($"[{bwName}] activates his Triconian energy shield to make his own cover against the ambush attempt.");
        }
        else if (bwCrisisType == "STORM")
        {
            bwResolvePoints -= 20;
            Console.WriteLine($"[{bwName}] didn't know what to do with himself to help get them out of the storm. So he held on for dear life and hoped Winter wouldn't screw this up.");
        }
        else if (bwCrisisType == "INFILTRATION")
        {
            bwResolvePoints -= 0;
            Console.WriteLine($"[{bwName}] never thought he'd disguise himself as a Corvusite, never again after he was freed from their control. But he had to trust in Summit's plan, even if he didn't trust her.");
        }
    }
}

class Pilot : Character
{
    public Pilot(string bwCharacterName) : base(bwCharacterName) { }

    public override void HandleCrisis(string bwCrisisType)
    {
        if (bwCrisisType == "AMBUSH")
        {
            bwResolvePoints -= 30;
            Console.WriteLine($"[{bwName}] cracks a loud joke under heavy pressure(which Grace quickly tells her to shut up), drops her half-smoked cigarette, and gets her eye-stalks out and ready.");
        }
        else if (bwCrisisType == "STORM")
        {
            bwResolvePoints -= 15;
            Console.WriteLine($"[{bwName}] had never been in a situation like this before, but she knew this storm was no match for her. A storm had taken away her family before, she wasn't going to let that happen again.");
        }
        else if (bwCrisisType == "INFILTRATION")
        {
            bwResolvePoints -= 20;
            Console.WriteLine($"[{bwName}] was watching Grace and Scal on the cams that she had hacked, knowing she couldn't pass a Corvusite. She wish she could help more but at the same time, was perfectly fine not walking amongst Corvusites.");
        }
    }
}

class Doctor : Character
{
    public Doctor(string bwCharacterName) : base(bwCharacterName) { }

    public override void HandleCrisis(string bwCrisisType)
    {
        if (bwCrisisType == "AMBUSH")
        {
            bwResolvePoints -= 10;
            Console.WriteLine($"[{bwName}] followed Grace's lead and took cover behind the nearest wall. He knew he wasn't much of a fighter, but he could help patch up any injuries that might occur.");
        }
        else if (bwCrisisType == "STORM")
        {
            bwResolvePoints -= 5;
            Console.WriteLine($"[{bwName}] immedietlty knew that navigating a particle storm would be more than he bargained for. He made sure to engage his stabliziers and gravity boots and would provide medical assistance when needed.");
        }
        else if (bwCrisisType == "INFILTRATION")
        {
            bwResolvePoints -= 25;
            Console.WriteLine($"[{bwName}] uses his massive 6'6 frame to shield wounded crew members, routing auxiliary battery power directly into automated door locks.");
        }
    }
}

class Reapmaster : Character
{
    public Reapmaster(string bwCharacterName) : base(bwCharacterName) { }

    public override void HandleCrisis(string bwCrisisType)
    {
        if (bwCrisisType == "AMBUSH")
        {
            bwResolvePoints += 10;
            Console.WriteLine($"[{bwName}] was ready for a rematch against Grace and her crew. She wondered who she would behead first once they were all defeated, but knew she had to be cautious around this crew and their tricks.");
        }
        else if (bwCrisisType == "STORM")
        {
            bwResolvePoints -= 15;
            Console.WriteLine($"[{bwName}] wasn't as skilled of a pilot as she would have liked to be. She would do what she could to navigate this particle storm, refusing to believe she would die here.");
        }
        else if (bwCrisisType == "INFILTRATION")
        {
            bwResolvePoints -= 5;
            Console.WriteLine($"[{bwName}] knew that the crew had infinilatred her ship the second they boarded. For now, she would let them think they had the element of surprise, and kill them once they got too far.");
        }
    }

    public override void PerformRestoration()
    {
        bwResolvePoints = 120;
        Console.WriteLine($"[{bwName}] draws supreme focus from dark sector remnants. Resolve capacity overcharged to 120.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Character> bwTargetRoster = new List<Character>();
        bwTargetRoster.Add(new Soldier("Grace Summit"));
        bwTargetRoster.Add(new Hunter("Scal Brines"));
        bwTargetRoster.Add(new Pilot("Winter Ecken"));
        bwTargetRoster.Add(new Doctor("ZK-33 (Zeke)"));
        bwTargetRoster.Add(new Reapmaster("Reapmaster Indra"));

        string bwMenuInput = "";

        while (bwMenuInput != "6")
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("  CRISIS SCENARIO SIMULATION MATRIX ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Review Crew Condition Ratings");
            Console.WriteLine("2. Inject Tactical Scenario: Reap Cycle Ambush");
            Console.WriteLine("3. Inject Tactical Scenario: Vidge Particle Storm");
            Console.WriteLine("4. Inject Tactical Scenario: Corvusite Infiltration");
            Console.WriteLine("5. Execute Crew Re-Refit & Maintenance");
            Console.WriteLine("6. Terminate Operational Grid (Exit)");
            Console.Write("Deploy directive index: ");
            bwMenuInput = Console.ReadLine();

            if (bwMenuInput == "1")
            {
                Console.WriteLine("\n--- CURRENT STAMINA RATINGS ---");
                foreach (Character bwIndividual in bwTargetRoster)
                {
                    bwIndividual.DisplayStatus();
                }
            }
            else if (bwMenuInput == "2")
            {
                Console.WriteLine("\n*** ALERT: ORCHESTRATING REAP CYCLE AMBUSH INTERCEPT ***\n");
                foreach (Character bwIndividual in bwTargetRoster)
                {
                    bwIndividual.HandleCrisis("AMBUSH");
                    Console.WriteLine();
                }
            }
            else if (bwMenuInput == "3")
            {
                Console.WriteLine("\n*** ALERT: ENCOUNTERING ANTICYCLONIC PARTICLE STORM ***\n");
                foreach (Character bwIndividual in bwTargetRoster)
                {
                    bwIndividual.HandleCrisis("STORM");
                    Console.WriteLine();
                }
            }
            else if (bwMenuInput == "4")
            {
                Console.WriteLine("\n*** ALERT: HOSTILE CORVUSITE INFANTRY DETECTED ONBOARD ***\n");
                foreach (Character bwIndividual in bwTargetRoster)
                {
                    bwIndividual.HandleCrisis("INFILTRATION");
                    Console.WriteLine();
                }
            }
            else if (bwMenuInput == "5")
            {
                Console.WriteLine("\n*** EXECUTING ALL STATION MEDICAL RESTORATION CYCLES ***\n");
                foreach (Character bwIndividual in bwTargetRoster)
                {
                    bwIndividual.PerformRestoration();
                }
            }
        }
    }
}