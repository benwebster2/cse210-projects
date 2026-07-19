using System;

class Spacecraft
{
    protected string bwDesignation;
    protected int bwHullIntegrity;
    protected int bwShieldLevel;
    protected string bwPropulsionType;

    public Spacecraft(string bwCraftName, int bwCraftHull, int bwCraftShield, string bwDriveSystem)
    {
        bwDesignation = bwCraftName;
        bwHullIntegrity = bwCraftHull;
        bwShieldLevel = bwCraftShield;
        bwPropulsionType = bwDriveSystem;
    }

    public void SufferDamage(int bwDamageAmount)
    {
        if (bwShieldLevel >= bwDamageAmount)
        {
            bwShieldLevel -= bwDamageAmount;
            Console.WriteLine($"[{bwDesignation}] Shields absorbed the hit! Shields dropped to {bwShieldLevel}%.");
        }
        else
        {
            int bwPenetratingDamage = bwDamageAmount - bwShieldLevel;
            bwShieldLevel = 0;
            bwHullIntegrity -= bwPenetratingDamage;
            if (bwHullIntegrity < 0)
            {
                bwHullIntegrity = 0;
            }
            Console.WriteLine($"[{bwDesignation}] Shields collapsed! Hull integrity damaged down to {bwHullIntegrity}%.");
        }
    }

    public void RestoreShieldArrays()
    {
        bwShieldLevel = 100;
        Console.WriteLine($"\n[{bwDesignation}] Diverting power to shields. Deflector grid restored to 100%.");
    }

    public void BroadcastCommsStatus()
    {
        Console.WriteLine($"\n--- VITAL SIGNALS: {bwDesignation} ---");
        Console.WriteLine($"Hull Structural Integrity: {bwHullIntegrity}%");
        Console.WriteLine($"Active Shield Capacity:    {bwShieldLevel}%");
        Console.WriteLine($"Core Propulsion Drive:     {bwPropulsionType}");
    }
}

class StealthShip : Spacecraft
{
    private int bwStealthCamouflageDuration;
    private int bwIntelFragmentsHarvested;

    public StealthShip(string bwCraftName, int bwCraftHull, int bwCraftShield, string bwDriveSystem, int bwCloakTime) : base(bwCraftName, bwCraftHull, bwCraftShield, bwDriveSystem)
    {
        bwStealthCamouflageDuration = bwCloakTime;
        bwIntelFragmentsHarvested = 0;
    }

    public void EngageCloakingMatrix()
    {
        Console.WriteLine($"\n[{bwDesignation}] Cloaking matrix online. Masking thermal footprint for {bwStealthCamouflageDuration} seconds.");
    }

    public void HarvestReapCycleData()
    {
        bwIntelFragmentsHarvested += 20;
        Console.WriteLine($"\n[{bwDesignation}] Camille Newport intercepted Corvusite frequencies. Intel Database at {bwIntelFragmentsHarvested}% compilation.");
    }
}

class CommandShuttle : Spacecraft
{
    private int bwEscortSquadronCount;
    private int bwSuperlaserCharges;

    public CommandShuttle(string bwCraftName, int bwCraftHull, int bwCraftShield, string bwDriveSystem, int bwEscorts) : base(bwCraftName, bwCraftHull, bwCraftShield, bwDriveSystem)
    {
        bwEscortSquadronCount = bwEscorts;
        bwSuperlaserCharges = 3;
    }

    public void LaunchMeteoriteFighters()
    {
        if (bwEscortSquadronCount > 0)
        {
            bwEscortSquadronCount--;
            Console.WriteLine($"\n[{bwDesignation}] Reapmaster Indra ordered flight wings to launch. Hangar bays holding {bwEscortSquadronCount} squadrons.");
        }
        else
        {
            Console.WriteLine($"\n[{bwDesignation}] Deployment aborted. All auxiliary fighter hangars empty.");
        }
    }

    public void FireHeavySuperlaser(Spacecraft bwTargetShip)
    {
        if (bwSuperlaserCharges > 0)
        {
            bwSuperlaserCharges--;
            Console.WriteLine($"\n[{bwDesignation}] Charging dark matter nodes... Superlaser fired directly at target!");
            bwTargetShip.SufferDamage(45);
        }
        else
        {
            Console.WriteLine($"\n[{bwDesignation}] Superlaser arrays depleted. Insufficient auxiliary power.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StealthShip bwForager = new StealthShip("The Forager", 95, 80, "Custom GAP Drive V2", 600);
        CommandShuttle bwNightmare = new CommandShuttle("The Eternal Nightmare", 100, 100, "Imperial Hypercore", 8);
        string bwConsoleInput = "";

        while (bwConsoleInput != "7")
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("    TACTICAL SECTOR ENGAGEMENT   ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. View Fleet Status Reports");
            Console.WriteLine("2. [The Forager] Toggle Stealth Cloak");
            Console.WriteLine("3. [The Forager] Hack Reap Cycle Communications");
            Console.WriteLine("4. [The Forager] Reboot Deflector Shields");
            Console.WriteLine("5. [Eternal Nightmare] Deploy Escort Squadron");
            Console.WriteLine("6. [Eternal Nightmare] Fire Superlaser at The Forager");
            Console.WriteLine("7. Sever Comms Array (Exit)");
            Console.Write("Input tactical directive: ");
            bwConsoleInput = Console.ReadLine();

            if (bwConsoleInput == "1")
            {
                bwForager.BroadcastCommsStatus();
                bwNightmare.BroadcastCommsStatus();
            }
            else if (bwConsoleInput == "2")
            {
                bwForager.EngageCloakingMatrix();
            }
            else if (bwConsoleInput == "3")
            {
                bwForager.HarvestReapCycleData();
            }
            else if (bwConsoleInput == "4")
            {
                bwForager.RestoreShieldArrays();
            }
            else if (bwConsoleInput == "5")
            {
                bwNightmare.LaunchMeteoriteFighters();
            }
            else if (bwConsoleInput == "6")
            {
                bwNightmare.FireHeavySuperlaser(bwForager);
            }
        }
    }
}