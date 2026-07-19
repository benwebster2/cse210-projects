using System;

class GapEngine
{
    private string bwCurrentLocation;
    private bool bwIsSystemReady;
    private int bwFuelRemaining;
    private int bwFuelCostPerJump;

    public GapEngine(string bwStartLocation)
    {
        bwCurrentLocation = bwStartLocation;
        bwIsSystemReady = true;
        bwFuelRemaining = 100;
        bwFuelCostPerJump = 15;
    }

    public void TravelTo(string bwDestination)
    {
        if (bwIsSystemReady)
        {
            if (bwDestination == "Fueling Station")
            {
                bwCurrentLocation = bwDestination;
                bwFuelRemaining = 100;
                Console.WriteLine($"\n[SUCCESS] Arrived at the {bwCurrentLocation}. The Forager has been fully refueled.");
                return;
            }

            if (bwFuelRemaining >= bwFuelCostPerJump)
            {
                CalculateSpacetimeTrajectory(bwDestination);
                InitializeGapCore();
                VentPlasmaDrive();
                
                bwFuelRemaining -= bwFuelCostPerJump;
                bwCurrentLocation = bwDestination;
                
                Console.WriteLine($"\n[SUCCESS] GAP fold complete. The Forager has arrived at {bwCurrentLocation}.");
                Console.WriteLine($"[STATUS] Fuel remaining: {bwFuelRemaining}%");
            }
            else
            {
                Console.WriteLine("\nRunning on fumes, your ship had to make a journey to the nearest fueling station before you had nothing left. Of course, you had to divert course from your intended planet, but now you have the fuel to resume your journey.");
                bwCurrentLocation = "Fueling Station";
                bwFuelRemaining = 100;
            }
        }
    }

    private void CalculateSpacetimeTrajectory(string bwTarget)
    {
        Console.WriteLine($"\nMapping quantum coordinates to: {bwTarget}...");
    }

    private void InitializeGapCore()
    {
        Console.WriteLine("Powering up the GAP rift engine...");
    }

    private void VentPlasmaDrive()
    {
        Console.WriteLine("Stabilizing warp fields and venting excess plasma radiation...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GapEngine bwEngineInstance = new GapEngine("Rexburg Station");
        string bwMenuSelection = "";

        while (bwMenuSelection != "12")
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("   THE FORAGER: GAP NAVIGATION   ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Bryantia (Marizal Corp HQ)");
            Console.WriteLine("2. Nilreb (Holders of Fate Stronghold)");
            Console.WriteLine("3. Binding (Planet of Monsters)");
            Console.WriteLine("4. Vidge (Site of the Collapse)");
            Console.WriteLine("5. Saben (Blackroot Neon City)");
            Console.WriteLine("6. Pativ City (Asteroid Outlaw Haven)");
            Console.WriteLine("7. Comet's End (Remains of Earth)");
            Console.WriteLine("8. Zarena (Vacation Planet)");
            Console.WriteLine("9. Pharaoh (Extreme Desert Planet)");
            Console.WriteLine("10. Tainward (Vitenon Mountain World)");
            Console.WriteLine("11. Fueling Station (Manual Refuel)");
            Console.WriteLine("12. Disengage Navigation (Exit)");
            Console.Write("Enter planetary destination coordinates: ");
            bwMenuSelection = Console.ReadLine();

            if (bwMenuSelection == "1")
            {
                bwEngineInstance.TravelTo("Bryantia");
            }
            else if (bwMenuSelection == "2")
            {
                bwEngineInstance.TravelTo("Nilreb");
            }
            else if (bwMenuSelection == "3")
            {
                bwEngineInstance.TravelTo("Binding");
            }
            else if (bwMenuSelection == "4")
            {
                bwEngineInstance.TravelTo("Vidge");
            }
            else if (bwMenuSelection == "5")
            {
                bwEngineInstance.TravelTo("Saben");
            }
            else if (bwMenuSelection == "6")
            {
                bwEngineInstance.TravelTo("Pativ City");
            }
            else if (bwMenuSelection == "7")
            {
                bwEngineInstance.TravelTo("Comet's End");
            }
            else if (bwMenuSelection == "8")
            {
                bwEngineInstance.TravelTo("Zarena");
            }
            else if (bwMenuSelection == "9")
            {
                bwEngineInstance.TravelTo("Pharaoh");
            }
            else if (bwMenuSelection == "10")
            {
                bwEngineInstance.TravelTo("Tainward");
            }
            else if (bwMenuSelection == "11")
            {
                bwEngineInstance.TravelTo("Fueling Station");
            }
        }
    }
}